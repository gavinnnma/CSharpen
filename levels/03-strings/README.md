# 第 3 关：字符串

## 目标

熟悉 C# 字符串：**不可变性**、字符串插值 `$"..."`、以及和 C++ `std::string` 对应的常用方法。

## 你要做什么

打开 `Solution.cs`，把 6 个 `// TODO` 补完整。改完跑测试，全绿即过关。不要改 `Level03Tests.cs`。

## 概念（含 C++ 对照）

### 字符串插值
```csharp
string name = "Gavin";
string msg = $"Hello, {name}!"; // "Hello, Gavin!"
```
大括号里可以是任意表达式：`$"sum = {a + b}"`。**对照 C++**：类似 C++20 的 `std::format`，但写法更顺手。

### 字符串不可变（重点差异）
C# 的 `string` **不可变**——所有「修改」方法都返回**新字符串**，原串不动：
```csharp
string a = "hi";
string b = a.ToUpper(); // a 还是 "hi"，b 是 "HI"
```
- **对照 C++**：`std::string` 是可变的，你可以 `s[0] = 'H'`；C# 里 `s[0]` 只能读不能写。
- 需要频繁拼接/修改时，用 `System.Text.StringBuilder`（类似 C++ 里避免反复构造临时串）。

### 常用方法对照
| 操作 | C++ (`std::string`) | C# (`string`) |
|------|---------------------|---------------|
| 取子串 | `s.substr(1)` | `s.Substring(1)` |
| 长度 | `s.size()` | `s.Length` |
| 转大写（单字符）| `toupper(c)` | `char.ToUpper(c)` |
| 反转 | `std::reverse(...)` | 转 `char[]` → `Array.Reverse` → `new string(arr)` |
| 包含 | `s.find(x) != npos` | `s.Contains(x)` |

### 遍历字符
```csharp
foreach (char ch in s) { /* ... */ }
```

## 运行测试

- VS Code 测试面板点本关 ▶；或在本文件夹执行 `dotnet test`。

## 卡住 / 改坏了

在项目根目录运行：
```bash
dotnet run --project tools -- save 03
dotnet run --project tools -- restore 03
dotnet run --project tools -- reset 03
```

## 过关提示

全绿即过关。最该记住的一点：**C# 字符串不可变**，别指望原地修改——总是接住方法的返回值。
