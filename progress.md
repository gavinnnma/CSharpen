# CSharpen 项目进度与计划

> 本文件记录 CSharpen（从 C++ 到 C# 的闯关式学习项目）的当前状态和后续所有计划。
> 给接手的人（或 Claude Code）：先读这份，再读根目录 `README.md` 了解整体设计。

---

## 学习者背景与目标

- 有扎实的 **C++ 基础**，但对 **C# 一无所知**，从零学起。
- 目标：**能独立写 C# 项目代码并 debug**。
- 操作系统：**macOS**，但要求**跨平台**（Windows 也能用）。
- 环境：本机 `dotnet --version` = **7.0.317**（.NET 7）。建议升级到 .NET 8 LTS，但不强制。
- 不使用 conda 隔离——采用 .NET 原生方式（`global.json` + 各项目 `.csproj`）。
- 偏好 **VS Code** 作为 IDE（顺便练真实工具链与调试）。

---

## 项目设计（已确定）

闯关式学习：12 关，循序渐进，从零基础到能独立开发。

每一关一个独立文件夹，包含：
- `README.md`：本关 C# 概念讲解 + **与 C++ 的对照差异**（这是本项目特色，务必保留）。
- `Solution.cs`：学习者填空的文件，含 `// TODO` 和方法签名。
- `LevelNNTests.cs`：xUnit 单元测试，**不要让学习者改**，用来验证 `Solution.cs`。
- `LevelNN.csproj`：xUnit 测试项目，编译时把 `Solution.cs` 和测试一起编译。

每关学习者工作流：读 README → 填 `Solution.cs` 的 TODO → 跑 `dotnet test`（或 VS Code 测试面板）→ 全绿过关。

**存档 / 重置 / 通过提交**：用一个跨平台的 C# 辅助工具（`tools/`）实现，命令在 Mac/Windows 一致：
- `dotnet run --project tools -- save NN`：保存当前进度（手动存档）。
- `dotnet run --project tools -- restore NN`：回到上次 save 的版本（**需二次确认**）。
- `dotnet run --project tools -- reset NN`：重置为最初空白模板（**需二次确认**）。
- `dotnet run --project tools -- submit NN`：跑该关测试，全绿则把当前代码存为「通过提交」。
- `dotnet run --project tools -- solution NN`：载入最后一次「通过提交」（**需二次确认**）。
- `dotnet run --project tools -- list`：列出关卡（标记 `[已通过]` / `[有存档]`）。
- 会覆盖当前 Solution.cs 的命令（restore/reset/solution）执行前都二次确认（输入 y 才继续）；
  加 `--yes` / `-y` 跳过确认（脚本/自动化用）。
- 三种存档放在隐藏文件夹 `.csharpen/`，互不覆盖：`templates/`（模板，reset 取）、
  `saves/`（手动存档，save/restore）、`passing/`（通过提交，submit/solution）。restore/reset 永不动 passing。

---

## 关卡路线图（12 关）

| 关 | 文件夹 | 主题 | 与 C++ 对照的关键点 | 状态 |
|----|--------|------|---------------------|------|
| 01 | `01-basics`   | 基本类型与变量 | `var` vs `auto`、值类型、`bool` 不与 int 互转、整数/浮点除法、`const` | ✅ 已完成 |
| 02 | `02-methods`  | 方法与参数 | `out` / `ref`、可选参数、方法重载、`params` | ✅ 已完成 |
| 03 | `03-strings`  | 字符串 | 不可变 string、插值 `$"..."`、常用方法 vs `std::string` | ✅ 已完成 |
| 04 | `04-classes`  | 类与属性 | 属性 vs getter/setter、自动属性、构造函数、`this`、对象初始化器 | ✅ 已完成 |
| 05 | `05-inheritance` | 继承与多态 | `virtual`/`override`/`abstract`/`base`/`sealed` vs C++ 虚函数 | ✅ 已完成 |
| 06 | `06-interfaces`  | 接口 | `interface`、显式实现、多接口 vs 纯虚类 | ✅ 已完成 |
| 07 | `07-collections` | 集合 | `List`/`Dictionary`/`HashSet`/`foreach` vs STL 容器 | ✅ 已完成 |
| 08 | `08-generics`    | 泛型 | 泛型类与方法、约束 `where T :` vs templates | ✅ 已完成 |
| 09 | `09-linq`        | LINQ | `Where`/`Select`/`OrderBy`/`Aggregate`（C++ 无对应强项）| ✅ 已完成 |
| 10 | `10-exceptions`  | 异常处理 | `try/catch/finally`、自定义异常、`using`/`IDisposable` vs RAII | ✅ 已完成 |
| 11 | `11-delegates`   | 委托与 Lambda | `Func`/`Action`、Lambda、事件 vs 函数指针/`std::function` | ✅ 已完成 |
| 12 | `12-async`       | 异步编程 | `async`/`await`/`Task` vs C++ 异步 | ✅ 已完成 |

---

## 已完成

- [x] `global.json`：锁定 .NET，`rollForward: latestMajor`（7 能跑，升级 8/9 也兼容）。
- [x] 根 `README.md`：总目录 + 操作指南 + 重置/保存说明。
- [x] `.gitignore`：忽略 bin/obj，但**保留** `.csharpen/`。
- [x] `tools/`：跨平台辅助工具（save/restore/reset/list），已实现并写好注释。
- [x] **第 1 关**（`levels/01-basics/`）：README + Solution.cs（5 个 TODO）+ xUnit 测试。
- [x] **本地验证第 1 关流程**（2026-06-06）：`dotnet test` 全红（空白模板，符合预期）；
      辅助工具 list/save/restore/reset 四命令均正常；`.csharpen/` 快照结构正确。.NET 7 下无需修复。
- [x] **第 1 关填空验证 + 工具增强**（2026-06-06）：把第 1 关所有 TODO 填上，`dotnet test` 16/16 全绿；
      确认无误后用 `submit 01` 存为「通过提交」，再 `reset 01` 回到空白模板（终态，供学习者练习）。
      同时给 `tools` 增加：① `submit`（跑测试，全绿存通过提交）② `solution`（载入通过提交）
      ③ restore/reset/solution 二次确认（`--yes`/`-y` 跳过）④ 新增 `.csharpen/passing/` 存档，
      与 templates/saves 互不覆盖。已逐条验证：submit 存档、取消路径、y 确认、solution 载入、终态 reset。
- [x] **第 2–12 关全部完成**（2026-06-06）：每关含 README + Solution.cs（空白模板，4–6 个 TODO）
      + LevelNNTests.cs + LevelNN.csproj，风格与第 1 关一致、难度逐关递增。
      每关均已 `dotnet test` 验证：可编译、测试可运行且全红（等学习者填空）。
      命名空间 `CSharpen.LevelNN`，主类型见各关：02 Methods / 03 StringOps / 04 BankAccount+Point /
      05 Shape+Circle+Rectangle+Square / 06 IArea+INamed+Rectangle+Circle+BilingualGreeter /
      07 Collections / 08 Generics+Pair / 09 Linq / 10 Exceptions+InsufficientFundsException+TrackedResource /
      11 Delegates+Button / 12 Async。

## 待做（按优先级）

1. **[等待中] 学习者实战**：从第 1 关开始逐关填 `Solution.cs` 的 TODO，跑测试转绿过关。
   有任何报错或概念疑问随时贴回对话。
2. **VS Code 集成（可选，未定）**：原计划在 `.vscode/` 放 `tasks.json`（保存/重置/恢复一键任务）、`launch.json`（调试）、`extensions.json`（推荐 C# Dev Kit）、`settings.json`。
   - ⚠️ 注意：之前的沙箱环境**禁止写入 `.vscode/`**（安全限制）。Claude Code 在本地通常没有此限制，可以直接创建。若仍受限，退路是写进 `vscode-config/` 再让用户 `mv vscode-config .vscode`。
   - 学习者一度问「为什么要改 vscode 配置」，需向其说明这是**项目级**便利配置（仅对本项目生效，不动全局设置）。此项是否要做，最终由学习者拍板。**目前尚未做，需先征求学习者意愿。**

---

## 给每关作者的规范（保持一致性）

- 每关 `Solution.cs` 顶部写明本关标题和「填 TODO → 跑测试」的提示。
- TODO 数量约 4–6 个，难度**逐关递增**；第 1 关最简单。
- 每个 TODO 上方用注释讲清要求，并在合适处点出 **C++ 对照**。
- 测试文件命名 `LevelNNTests.cs`，命名空间 `CSharpen.LevelNN`，类型放在同名命名空间下，方便测试直接引用（参考第 1 关：`namespace CSharpen.Level01;`，测试用 `Basics.Xxx()`）。
- `.csproj` 用 `net7.0`、`ImplicitUsings` 和 `Nullable` 都 enable；引用 `Microsoft.NET.Test.Sdk` / `xunit` / `xunit.runner.visualstudio`（版本与第 1 关一致）。
- 测试要覆盖正常情况 + 边界情况（用 `[Theory]` + `[InlineData]`）。
- 每关 README 结构：目标 → 你要做什么 → 概念（含 C++ 对照）→ 运行测试 → 卡住/改坏了（重置命令）→ 过关提示。

---

## 当前文件树

```
CSharpen/
├── global.json
├── README.md
├── CLAUDE.md              ← 给 Claude Code 的项目说明
├── progress.md            ← 本文件
├── .gitignore
├── tools/
│   ├── Tools.csproj
│   └── Program.cs
└── levels/
    ├── 01-basics/         每关都是：README.md + LevelNN.csproj + Solution.cs + LevelNNTests.cs
    ├── 02-methods/
    ├── 03-strings/
    ├── 04-classes/
    ├── 05-inheritance/
    ├── 06-interfaces/
    ├── 07-collections/
    ├── 08-generics/
    ├── 09-linq/
    ├── 10-exceptions/
    ├── 11-delegates/
    └── 12-async/
```

---

## 下一步（接手者从这里开始）

1. 12 关已全部就绪且验证为「可编译 + 测试全红」。接下来是**学习者自己填空**练习。
2. 学习者卡住时：先看对应关 README 的概念与 C++ 对照；改坏了用
   `dotnet run --project tools -- reset NN` 重置；把报错贴回对话即可帮忙。
3. VS Code 集成（`.vscode/`）仍是可选项，**动手前先问学习者要不要**。
4. 若要再加题/加难度：在对应关的 `Solution.cs` 增 TODO 并同步在 `LevelNNTests.cs` 加测试，
   保持「测试不被学习者修改、能独立验证」的约定。
