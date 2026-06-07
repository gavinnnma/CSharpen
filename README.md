# CSharpen — 从 C++ 到 C# 的闯关式学习项目

为有 C++ 基础、想系统学 C# 的人设计。一共 12 关，循序渐进。每关你都会**修改一个源文件填空**，然后用**单元测试**检查你写的代码对不对。绿了就过关，进下一关。

---

## 一、准备工作（只做一次）

1. **安装 .NET SDK**（建议 8.0 LTS；你现有的 7.0 也能跑）。
   - 检查是否已装：终端运行 `dotnet --version`，有版本号即可。
   - 下载：https://dotnet.microsoft.com/download
2. **安装 VS Code**：https://code.visualstudio.com
3. 用 VS Code 打开本文件夹（`CSharpen/`）。第一次打开时，右下角会提示安装推荐扩展（**C# Dev Kit**），点装上即可。它提供测试面板、智能补全和调试。

---

## 二、每一关怎么做

以第 1 关为例，每关都是同样的四步：

1. **读说明**：打开 `levels/01-basics/README.md`，了解这一关的 C# 概念和它跟 C++ 的区别。
2. **填代码**：打开同一文件夹下的 `Solution.cs`，找到 `// TODO`，把代码补完整。
3. **跑测试**：用下面任一方式运行该关测试，看是否变绿。
4. **过关**：全绿就进下一关。改坏了？用「重置 / 返回上次提交」（见第四节）。

### 运行测试的三种方式

- **测试面板（推荐）**：VS Code 左侧栏的烧瓶图标（Testing），展开后点某关的 ▶ 运行，绿勾/红叉一目了然。点测试名还能看失败原因。
- **命令任务**：`Cmd+Shift+P` → `Tasks: Run Task` → 选 `测试：当前关卡` 之类的任务。
- **命令行**：在某关文件夹里运行 `dotnet test`。

---

## 三、关卡路线图

| 关 | 主题 | 对照 C++ 的关键差异 |
|----|------|----------------------|
| 01 | 基本类型与变量 | `var` vs `auto`、值类型、`Console.WriteLine` |
| 02 | 方法与参数 | `out` / `ref`、可选参数、重载 |
| 03 | 字符串 | 不可变字符串、插值 `$"..."`、常用方法 |
| 04 | 类与属性 | 属性 vs getter/setter、自动属性、`this` |
| 05 | 继承与多态 | `virtual` / `override` / `abstract` / `base` |
| 06 | 接口 | `interface`、显式实现、多接口 |
| 07 | 集合 | `List` / `Dictionary` / `foreach` vs STL |
| 08 | 泛型 | 泛型类与方法、约束 vs templates |
| 09 | LINQ | `Where` / `Select` / `OrderBy`（C++ 没有的强项）|
| 10 | 异常处理 | `try/catch/finally`、`using` vs RAII |
| 11 | 委托与 Lambda | `Func` / `Action`、事件 vs 函数指针 |
| 12 | 异步编程 | `async` / `await` / `Task` |

> 目前已就绪：**第 1 关**。跑通流程后，其余关卡会陆续补齐。

---

## 四、存档 / 重置 / 通过提交

每关你都有几个安全网，用一个跨平台小工具实现（Mac / Windows 命令一样）。

在项目根目录运行（把 `01` 换成关号）：

```bash
# 保存当前进度（建议每写对一点就存一次）
dotnet run --project tools -- save 01

# 返回上次手动保存的版本（改坏了想退回；需二次确认）
dotnet run --project tools -- restore 01

# 重置到最初的空白模板（彻底重来；需二次确认）
dotnet run --project tools -- reset 01

# 跑本关测试，全绿就把当前代码存为「通过提交」
dotnet run --project tools -- submit 01

# 载入最后一次「通过提交」（想找回通关版本；需二次确认）
dotnet run --project tools -- solution 01
```

会**覆盖当前代码**的命令（`restore` / `reset` / `solution`）执行前都会**二次确认**，输入 `y` 才继续——防手滑。确认烦的话可加 `--yes`（或 `-y`）跳过。也可以在 VS Code 里用 `Tasks: Run Task` 选对应任务，不用记命令。

> 工作原理：每关有三种互不覆盖的存档，都放在隐藏文件夹 `.csharpen/` 里（跟着项目走，换电脑也不丢）：
> - `templates/`：最初空白模板（`reset` 取这里）；
> - `saves/`：你的手动存档（`save` 写、`restore` 取）；
> - `passing/`：测试全绿的「通过提交」（`submit` 写、`solution` 取）。
> `restore` / `reset` **永远不会**动你的「通过提交」。

---

## 五、遇到问题

- 测试一直红、看不懂报错：把报错贴回对话里，我帮你解释。
- 想跳过某关或调整顺序：直接说。
- 想加题或加难度：随时提。
