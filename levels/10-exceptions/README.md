# 第 10 关：异常处理

## 目标

掌握 C# 异常机制：`try`/`catch`/`finally`、捕获特定异常、`throw`、自定义异常类型，以及 `using` / `IDisposable`（C# 版 RAII）。

## 你要做什么

打开 `Solution.cs`，把 6 个 `// TODO` 补完整。改完跑测试，全绿即过关。不要改 `Level10Tests.cs`。

## 概念（含 C++ 对照）

### try / catch / finally
```csharp
try { /* 可能出错的代码 */ }
catch (FormatException ex) { /* 处理某类异常，ex.Message 取消息 */ }
finally { /* 无论是否出异常都会执行：收尾/释放 */ }
```
- 可以写多个 `catch` 按类型分别处理，从具体到宽泛。
- **对照 C++**：结构类似 `try/catch`，但 **C++ 没有 `finally`**——C++ 靠析构函数（RAII）做收尾；C# 两者都有。

### 捕获特定异常
```csharp
catch (DivideByZeroException) { ... }  // 整数除零
catch (FormatException) { ... }        // int.Parse 失败
```
只捕获你能处理的类型，别用空 `catch` 吞掉一切。

### 主动抛出 & 自定义异常
```csharp
throw new InsufficientFundsException("balance too low");

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message) { }
}
```
- **对照 C++**：类似继承 `std::exception`；C# 习惯继承 `Exception` 并用 `: base(message)` 传消息，之后 `ex.Message` 取回。

### using / IDisposable —— C# 的 RAII
```csharp
using (var resource = new TrackedResource())
{
    // 用 resource ...
} // 块结束自动调用 resource.Dispose()
```
- **对照 C++（重要差异）**：C++ 对象离开作用域**立即**析构，清理是确定性的。C# 是垃圾回收，**不保证**对象何时被回收、`Dispose` 何时调用。所以对「必须及时释放」的资源（文件句柄、数据库连接、锁），要实现 `IDisposable` 并用 `using` 显式管理——这就是 C# 版 RAII。

## 运行测试

VS Code 测试面板点本关 ▶；或在本文件夹执行 `dotnet test`。

## 卡住 / 改坏了

```bash
dotnet run --project tools -- save 10
dotnet run --project tools -- restore 10
dotnet run --project tools -- reset 10
```

## 过关提示

全绿即过关。最该带走的两点：① C# 有 `finally`，C++ 没有；② GC ≠ 确定性析构，需要及时释放的资源用 `IDisposable` + `using`。
