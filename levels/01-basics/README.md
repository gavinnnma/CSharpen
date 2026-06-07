# 第 1 关：基本类型与变量

> 目标：熟悉 C# 的基本类型、`var` 推断、布尔、浮点除法和常量。建立和 C++ 的对照直觉。

## 你要做什么

打开本文件夹的 `Solution.cs`，把 5 个 `// TODO` 填完整，然后跑测试看是否全绿。

## 这一关的概念（含 C++ 对照）

**整数类型 `int`**
和 C++ 的 `int` 类似，但 C# 标准**保证** `int` 就是 32 位有符号整数（C++ 里 `int` 大小理论上依赖平台）。其他常见的有 `long`（64 位）、`short`、`byte`。

**`var`：类型推断**
```csharp
var x = 10;        // 编译器推断为 int
var name = "hi";   // 推断为 string
```
等价于 C++ 的 `auto`。关键点：`var` 仍是**静态类型**——一旦推断出来就固定了，不是动态类型。它只能在声明且有初始值时用。

**`bool`：真正的布尔类型**
C# 的 `bool` 和 `int` **不能隐式互转**。在 C++ 里你能写 `if (n)` 判断非零，但 C# 里 `if` 的条件**必须**是 `bool`，要写 `if (n != 0)`。这能避免很多 bug。

**浮点 `double` 与整数除法的坑**
`double` 是 64 位浮点，也是浮点字面量（如 `3.14`）的默认类型。和 C++ 完全一样的坑：两个 `int` 相除是**整数除法**——
```csharp
5 / 2     // == 2   （整数除法，丢弃小数）
5.0 / 2   // == 2.5 （只要有一个是浮点，就做浮点除法）
(double)a / b   // 强制转换其中一个，得到浮点结果
```

**`const`：编译期常量**
```csharp
public const double Pi = 3.14;
```
类似 C++ 的 `constexpr`/`const`。值在编译期确定，不可修改。

**`Console.WriteLine`**
C# 的控制台输出，类似 C++ 的 `std::cout`。这一关测试不直接用到，但你会经常见到它：
```csharp
Console.WriteLine("Hello");        // 输出并换行
Console.WriteLine($"x = {x}");     // 字符串插值，下一关会细讲
```

## 运行测试

任选一种：

- **测试面板**：VS Code 左侧烧瓶图标 → 找到 Level01 → 点 ▶。
- **命令行**：在本文件夹运行 `dotnet test`。

第一次运行会自动下载依赖（xUnit 等），稍等片刻。

## 卡住 / 改坏了

```bash
# 在项目根目录运行
dotnet run --project tools -- save 01      # 保存当前进度
dotnet run --project tools -- restore 01   # 回到上次保存
dotnet run --project tools -- reset 01     # 重置为空白模板
```

全绿后，就可以进第 2 关了 🎉
