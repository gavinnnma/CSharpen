# 第 11 关：委托与 Lambda

## 目标

掌握 C# 把「函数当数据」的能力：`Func` / `Action` / `Predicate`、Lambda 表达式与闭包、自定义 `delegate` 类型、以及 `event` 事件。

## 你要做什么

打开 `Solution.cs`，把 6 个 `// TODO` 补完整。改完跑测试，全绿即过关。不要改 `Level11Tests.cs`。

## 概念（含 C++ 对照）

### 委托 = 类型安全的「函数引用」
委托是一种类型，它的值是一个（或多个）方法。**对照 C++**：相当于 `std::function` 或函数指针，但是类型安全、且能多播。

内置委托类型（最常用）：
| 类型 | 含义 | 例 |
|------|------|----|
| `Func<int,int>` | 接收 int，返回 int | `x => x * 2` |
| `Func<int,int,int>` | 接收两个 int，返回 int（最后一个是返回类型）| `(a,b) => a + b` |
| `Action` | 无参、无返回 | `() => Console.WriteLine("hi")` |
| `Action<string>` | 接收 string、无返回 | `s => Console.WriteLine(s)` |
| `Predicate<int>` | 接收 int、返回 bool | `n => n % 2 == 0` |

### Lambda 表达式
`(参数) => 表达式或语句块`：
```csharp
x => x + 1                 // 单参单表达式
(a, b) => a * b            // 多参
x => { return x * x; }     // 语句块版
```
- **对照 C++**：相当于 `[](int x){ return x + 1; }`，但不用写类型和捕获列表。

### 闭包（捕获外层变量）
Lambda 能「记住」它定义处的变量：
```csharp
Func<int,int> MakeAdder(int n) => x => x + n; // 捕获了 n
```
- **对照 C++**：相当于 `[n](int x){ return x + n; }`。但 C# 的捕获是自动的，变量生命周期由 GC 延长，不会像 C++ 捕获引用那样出现悬垂。

### 自定义委托类型
```csharp
public delegate int BinaryOp(int a, int b);
```
等价于自定义一个 `Func<int,int,int>` 的「具名版本」，可读性更好。

### 事件（event）
事件是**多播委托**的安全封装：外部只能 `+=` / `-=`，**触发只能在类内部**。
```csharp
public event Action? Clicked;          // 声明
Clicked?.Invoke();                     // 触发（?. 防止没有订阅者时报错）
button.Clicked += () => { ... };       // 订阅
```
- **对照 C++**：C++ 没有内建事件，通常自己维护一个回调列表（`std::vector<std::function<...>>`）；C# 把观察者模式做进了语言。

## 运行测试

VS Code 测试面板点本关 ▶；或在本文件夹执行 `dotnet test`。

## 卡住 / 改坏了

```bash
dotnet run --project tools -- save 11
dotnet run --project tools -- restore 11
dotnet run --project tools -- reset 11
```

## 过关提示

全绿即过关。注意触发事件用 `Clicked?.Invoke()`——`?.` 在没有订阅者（委托为 `null`）时安全跳过，省去手动判空。回头看第 9 关的 LINQ，你现在该明白那些 `n => ...` 到底是什么了。
