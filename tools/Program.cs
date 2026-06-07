// CSharpen 辅助工具：跨平台的 save / restore / reset / submit / solution / list。
// 用法（在项目根目录运行）：
//   dotnet run --project tools -- save 01      保存当前进度（手动存档）
//   dotnet run --project tools -- restore 01   回到上次手动存档（需二次确认）
//   dotnet run --project tools -- reset 01     重置为最初空白模板（需二次确认）
//   dotnet run --project tools -- submit 01    跑该关测试，全绿则保存为「通过提交」
//   dotnet run --project tools -- solution 01  载入最后一次「通过提交」（需二次确认）
//   dotnet run --project tools -- list         列出关卡
//
// 任何「会覆盖当前 Solution.cs」的命令（restore / reset / solution）执行前都会
// 二次确认；加 --yes（或 -y）可跳过确认（脚本/自动化用）。
//
// 工作原理：每关有一个 Solution.cs 是你填空的文件，对应三种独立存档：
//   - .csharpen/templates/NN/  「原始空白模板」：首次接触该关时自动快照；reset 取这里。
//   - .csharpen/saves/NN/       「手动存档」：save 写入、restore 取回。
//   - .csharpen/passing/NN/     「通过提交」：submit 测试全绿时写入、solution 取回。
//   三者互不覆盖：restore / reset 永远不会动「通过提交」。

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

internal static class Program
{
    // 每关被管理的文件名。所有关卡统一用 Solution.cs。
    private const string ManagedFile = "Solution.cs";

    private static int Main(string[] args)
    {
        try
        {
            string root = FindProjectRoot();

            if (args.Length == 0)
            {
                PrintUsage();
                return 1;
            }

            string command = args[0].ToLowerInvariant();

            // 解析参数：--yes / -y 跳过二次确认；其余非选项参数作为位置参数（关号）。
            bool skipConfirm = false;
            var positional = new List<string>();
            for (int i = 1; i < args.Length; i++)
            {
                string a = args[i];
                if (a == "--yes" || a == "-y")
                {
                    skipConfirm = true;
                }
                else if (a.StartsWith("-", StringComparison.Ordinal))
                {
                    Console.Error.WriteLine($"未知选项：{a}");
                    return 1;
                }
                else
                {
                    positional.Add(a);
                }
            }

            if (command == "list")
            {
                ListLevels(root);
                return 0;
            }

            if (positional.Count == 0)
            {
                Console.Error.WriteLine($"命令 '{command}' 需要一个关号，例如：dotnet run --project tools -- {command} 01");
                return 1;
            }

            string level = NormalizeLevel(positional[0]);
            string levelDir = ResolveLevelDir(root, level);
            string solutionPath = Path.Combine(levelDir, ManagedFile);

            if (!File.Exists(solutionPath))
            {
                Console.Error.WriteLine($"找不到 {ManagedFile}：{solutionPath}");
                return 1;
            }

            // 确保原始模板已被记录（首次接触该关时自动快照）。
            EnsureTemplate(root, level, solutionPath);

            switch (command)
            {
                case "save":
                    Save(root, level, solutionPath);
                    break;
                case "restore":
                    Restore(root, level, solutionPath, skipConfirm);
                    break;
                case "reset":
                    Reset(root, level, solutionPath, skipConfirm);
                    break;
                case "submit":
                    Submit(root, level, levelDir, solutionPath);
                    break;
                case "solution":
                    LoadPassing(root, level, solutionPath, skipConfirm);
                    break;
                default:
                    Console.Error.WriteLine($"未知命令：{command}");
                    PrintUsage();
                    return 1;
            }

            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("出错了：" + ex.Message);
            return 1;
        }
    }

    private static void Save(string root, string level, string solutionPath)
    {
        string savePath = SavePath(root, level);
        Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);
        File.Copy(solutionPath, savePath, overwrite: true);
        Console.WriteLine($"✓ 已保存第 {level} 关的当前进度。");
        Console.WriteLine($"  之后用 'restore {level}' 可以回到这个版本。");
    }

    private static void Restore(string root, string level, string solutionPath, bool skipConfirm)
    {
        string savePath = SavePath(root, level);
        if (!File.Exists(savePath))
        {
            Console.Error.WriteLine($"第 {level} 关还没有保存过任何进度。");
            Console.Error.WriteLine($"先用 'save {level}' 保存，才能 restore。");
            return;
        }
        if (!Confirm($"restore 会用「上次手动存档」覆盖第 {level} 关当前的 {ManagedFile}，确定吗？", skipConfirm))
        {
            Console.WriteLine("已取消，未做任何改动。");
            return;
        }
        File.Copy(savePath, solutionPath, overwrite: true);
        Console.WriteLine($"✓ 已把第 {level} 关恢复到上次保存的版本。");
    }

    private static void Reset(string root, string level, string solutionPath, bool skipConfirm)
    {
        string templatePath = TemplatePath(root, level);
        if (!File.Exists(templatePath))
        {
            Console.Error.WriteLine($"找不到第 {level} 关的原始模板，无法重置。");
            return;
        }
        if (!Confirm($"reset 会用「最初空白模板」覆盖第 {level} 关当前的 {ManagedFile}，确定吗？", skipConfirm))
        {
            Console.WriteLine("已取消，未做任何改动。");
            return;
        }
        File.Copy(templatePath, solutionPath, overwrite: true);
        Console.WriteLine($"✓ 已把第 {level} 关重置为最初的空白模板。");
        Console.WriteLine("  （你的 save 存档和「通过提交」仍然保留，没有被删除。）");
    }

    // submit：跑该关测试，全绿才把当前 Solution.cs 存为「通过提交」。
    private static void Submit(string root, string level, string levelDir, string solutionPath)
    {
        Console.WriteLine($"正在运行第 {level} 关测试……");
        int exitCode = RunDotnetTest(levelDir);

        if (exitCode == 0)
        {
            string passingPath = PassingPath(root, level);
            Directory.CreateDirectory(Path.GetDirectoryName(passingPath)!);
            File.Copy(solutionPath, passingPath, overwrite: true);
            Console.WriteLine($"✓ 第 {level} 关测试全部通过，已保存为「通过提交」。");
            Console.WriteLine($"  以后可用 'solution {level}' 重新载入这份通过的代码。");
        }
        else
        {
            Console.Error.WriteLine($"✗ 第 {level} 关测试未全部通过，「通过提交」未更新。");
            Console.Error.WriteLine("  把测试做绿后再 submit。");
        }
    }

    // solution：用「最后一次通过提交」覆盖当前 Solution.cs（需确认）。
    private static void LoadPassing(string root, string level, string solutionPath, bool skipConfirm)
    {
        string passingPath = PassingPath(root, level);
        if (!File.Exists(passingPath))
        {
            Console.Error.WriteLine($"第 {level} 关还没有任何「通过提交」。");
            Console.Error.WriteLine($"先把测试做绿，再用 'submit {level}' 保存。");
            return;
        }
        if (!Confirm($"这会用「最后通过提交」覆盖第 {level} 关当前的 {ManagedFile}，确定吗？", skipConfirm))
        {
            Console.WriteLine("已取消，未做任何改动。");
            return;
        }
        File.Copy(passingPath, solutionPath, overwrite: true);
        Console.WriteLine($"✓ 已载入第 {level} 关的「最后通过提交」。");
    }

    // 首次接触某关时，把当前文件保存为不可变的原始模板。
    private static void EnsureTemplate(string root, string level, string solutionPath)
    {
        string templatePath = TemplatePath(root, level);
        if (!File.Exists(templatePath))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(templatePath)!);
            File.Copy(solutionPath, templatePath, overwrite: false);
        }
    }

    private static void ListLevels(string root)
    {
        string levelsDir = Path.Combine(root, "levels");
        if (!Directory.Exists(levelsDir))
        {
            Console.WriteLine("还没有任何关卡。");
            return;
        }

        var dirs = Directory.GetDirectories(levelsDir)
            .Select(Path.GetFileName)
            .Where(n => n is not null)
            .OrderBy(n => n)
            .ToList();

        Console.WriteLine("可用关卡：");
        foreach (var d in dirs)
        {
            string num = d!.Split('-')[0];
            string mark = "";
            if (File.Exists(PassingPath(root, num))) mark += "  [已通过]";
            if (File.Exists(SavePath(root, num))) mark += "  [有存档]";
            Console.WriteLine($"  {d}{mark}");
        }
    }

    // 在 levelDir 里运行 `dotnet test`，返回退出码（0 = 全部通过）。
    private static int RunDotnetTest(string levelDir)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            WorkingDirectory = levelDir,
            UseShellExecute = false, // 继承当前控制台，让测试输出直接显示给用户
        };
        psi.ArgumentList.Add("test");

        using var proc = Process.Start(psi);
        if (proc is null)
            throw new InvalidOperationException("无法启动 dotnet test。");

        proc.WaitForExit();
        return proc.ExitCode;
    }

    // 二次确认：输入 y / yes 才继续；其它（含直接回车、无输入）一律取消。
    private static bool Confirm(string prompt, bool skipConfirm)
    {
        if (skipConfirm)
            return true;

        Console.Write(prompt + " (y/N): ");
        string? answer = Console.ReadLine();
        if (answer is null)
            return false; // 非交互/EOF：保守起见当作取消

        answer = answer.Trim();
        return answer.Equals("y", StringComparison.OrdinalIgnoreCase)
            || answer.Equals("yes", StringComparison.OrdinalIgnoreCase);
    }

    // ---- 路径辅助 ----

    private static string TemplatePath(string root, string level) =>
        Path.Combine(root, ".csharpen", "templates", level, ManagedFile);

    private static string SavePath(string root, string level) =>
        Path.Combine(root, ".csharpen", "saves", level, ManagedFile);

    private static string PassingPath(string root, string level) =>
        Path.Combine(root, ".csharpen", "passing", level, ManagedFile);

    // 关号标准化："1" / "01" / "level01" -> "01"
    private static string NormalizeLevel(string raw)
    {
        string digits = new string(raw.Where(char.IsDigit).ToArray());
        if (digits.Length == 0)
            throw new ArgumentException($"无法识别的关号：'{raw}'");
        if (int.TryParse(digits, out int n))
            return n.ToString("D2");
        return digits;
    }

    // 根据关号找到 levels/ 下以该号开头的文件夹（例如 01 -> levels/01-basics）。
    private static string ResolveLevelDir(string root, string level)
    {
        string levelsDir = Path.Combine(root, "levels");
        if (!Directory.Exists(levelsDir))
            throw new DirectoryNotFoundException($"找不到 levels 文件夹：{levelsDir}");

        var match = Directory.GetDirectories(levelsDir)
            .FirstOrDefault(d => Path.GetFileName(d)!.StartsWith(level + "-", StringComparison.Ordinal));

        if (match is null)
            throw new DirectoryNotFoundException($"找不到第 {level} 关对应的文件夹（levels/{level}-*）。");

        return match;
    }

    // 向上查找包含 global.json 的目录作为项目根。
    private static string FindProjectRoot()
    {
        var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (dir is not null)
        {
            if (File.Exists(Path.Combine(dir.FullName, "global.json")))
                return dir.FullName;
            dir = dir.Parent;
        }
        // 退而求其次：用当前目录。
        return Directory.GetCurrentDirectory();
    }

    private static void PrintUsage()
    {
        Console.WriteLine("CSharpen 辅助工具");
        Console.WriteLine("用法（在项目根目录运行）：");
        Console.WriteLine("  dotnet run --project tools -- save <关号>      保存当前进度（手动存档）");
        Console.WriteLine("  dotnet run --project tools -- restore <关号>   回到上次手动存档（需确认）");
        Console.WriteLine("  dotnet run --project tools -- reset <关号>     重置为空白模板（需确认）");
        Console.WriteLine("  dotnet run --project tools -- submit <关号>    跑测试，全绿则存为「通过提交」");
        Console.WriteLine("  dotnet run --project tools -- solution <关号>  载入最后一次「通过提交」（需确认）");
        Console.WriteLine("  dotnet run --project tools -- list            列出所有关卡");
        Console.WriteLine();
        Console.WriteLine("选项：--yes / -y   跳过二次确认（脚本/自动化用）");
        Console.WriteLine();
        Console.WriteLine("例：dotnet run --project tools -- submit 01");
    }
}
