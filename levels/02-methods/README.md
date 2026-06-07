# 第 2 关：方法与参数

## 目标

掌握 C# 方法的参数传递方式，理解它和 C++ 的对应关系：`out`、`ref`、可选参数（默认值）、方法重载、`params` 可变参数。

## 你要做什么

打开本文件夹下的 `Solution.cs`，把 6 个 `// TODO` 补完整。改完跑测试，全绿即过关。

不要改 `Level02Tests.cs`（那是用来验证你的实现的）。

## 概念（含 C++ 对照）

### `out` 参数：额外返回一个值
```csharp
bool ok = Methods.TryParseInt("42", out int n); // ok == true, n == 42
```
- 调用处也要写 `out`，一眼就能看出该变量会被方法写入。
- 编译器**强制**方法在正常返回前给 `out` 参数赋值。
- **对照 C++**：你以前会用 `int*` 或 `int&` 回传；C# 的 `out` 更明确，且常配合 `TryXxx` 模式（解析/查找失败时返回 `false` 而不是抛异常）。

### `ref` 参数：双向引用
```csharp
int x = 5;
Methods.Triple(ref x); // x == 15
```
- **对照 C++**：相当于 `int&`。区别是 C# 在**调用点**也要写 `ref`。
- `ref` 与 `out` 的区别：`ref` 进来时变量必须已初始化（双向）；`out` 进来可以没初始化，但方法内必须赋值（单向输出）。

### 可选参数（默认值）
```csharp
int Power(int baseValue, int exponent = 2)
Methods.Power(4);     // 用默认 exponent=2 → 16
Methods.Power(2, 10); // → 1024
```
- **对照 C++**：和 C++ 的默认实参几乎一样。

### 方法重载
同名、参数列表不同即可重载，编译器按实参类型选择。**对照 C++**：概念一致。

### `params` 可变参数
```csharp
int SumAll(params int[] numbers)
Methods.SumAll(1, 2, 3); // 6
Methods.SumAll();        // 0
```
- **对照 C++**：类似可变参数模板 / `std::initializer_list`，但语法简单得多。

## 运行测试

- VS Code 测试面板（烧瓶图标）点本关 ▶；或
- 命令行：在本文件夹执行 `dotnet test`。

## 卡住 / 改坏了

在项目根目录运行（`02` 是关号）：
```bash
dotnet run --project tools -- save 02      # 保存当前进度
dotnet run --project tools -- restore 02   # 回到上次保存
dotnet run --project tools -- reset 02     # 重置为空白模板
```

## 过关提示

8 个测试方法全绿即过关。重点体会：`out`/`ref` 在调用点也要显式写出，这是 C# 比 C++ 更「啰嗦但更安全」的设计。
