# 第 12 关：异步编程

## 目标

掌握 C# 异步编程的核心：`async` / `await` / `Task`，顺序组合与 `Task.WhenAll` 并发，以及 async 里的异常处理。这是现代 C# 写 I/O、网络、UI 的必备技能，也是本闯关项目的收官关。

## 你要做什么

打开 `Solution.cs`，把 6 个 `// TODO` 补完整。**注意：方法签名故意没写 `async`，你要自己加上**，并在方法体里用 `await`。改完跑测试，全绿即过关。不要改 `Level12Tests.cs`。

## 概念（含 C++ 对照）

### Task 是什么
`Task` 代表「一个将来会完成的操作」；`Task<T>` 是「将来会产出一个 T 的操作」。
- **对照 C++**：类似 `std::future<T>` / `std::async` 的返回值。

### async / await
```csharp
public static async Task<int> GetFortyTwoAsync()
{
    await Task.Delay(1);  // 异步等待 1ms，期间不阻塞线程
    return 42;
}
```
- 方法用 `async` 标记后，返回类型写 `Task` 或 `Task<T>`，但 `return` 写的是「里面的值」（如 `return 42;`，编译器替你包成 `Task<int>`）。
- `await t` 等待 `t` 完成并取出结果，**不阻塞线程**（对照 C++ `future.get()` 会阻塞）。
- **对照 C++**：最接近 C++20 协程的 `co_await`，但 C# 早就有、生态成熟。

### 顺序 await vs 并发 WhenAll
顺序（一个等完再等下一个）：
```csharp
int a = await SquareAsync(x);
int b = await SquareAsync(y); // 等 a 完成后才开始
```
并发（同时进行，一起等）：
```csharp
var ta = SquareAsync(x);   // 启动，先不 await
var tb = SquareAsync(y);   // 启动
await Task.WhenAll(ta, tb);
return ta.Result + tb.Result;
```
要点：**先拿到 Task 再 WhenAll** 才是并发；如果每个都立刻 `await`，就退化成顺序执行了。

### async 里的异常
`await` 处抛出的异常能用普通 `try/catch` 捕获：
```csharp
try { await Task.Delay(1); return a / b; }
catch (DivideByZeroException) { return -1; }
```

### 测试怎么写（供你参考）
xUnit 的测试方法本身可以是 `async Task`，里面直接 `await` 你的方法——本关测试就是这么做的。

## 运行测试

VS Code 测试面板点本关 ▶；或在本文件夹执行 `dotnet test`。

## 卡住 / 改坏了

```bash
dotnet run --project tools -- save 12
dotnet run --project tools -- restore 12
dotnet run --project tools -- reset 12
```

## 过关提示

全绿即过关——也就通关了全部 12 关 🎉。记住两个高频要点：① `async` 方法 `return` 的是「裸值」，类型却是 `Task<T>`；② 想并发就「先启动 Task，再 `Task.WhenAll`」，别一拿到就 `await`。
