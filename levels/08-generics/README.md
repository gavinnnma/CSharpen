# 第 8 关：泛型

## 目标

掌握 C# 泛型：泛型方法、泛型类（含多个类型参数）、类型约束 `where T : ...`，并理解它和 C++ 模板的异同。

## 你要做什么

打开 `Solution.cs`，把 6 个 `// TODO` 补完整。改完跑测试，全绿即过关。不要改 `Level08Tests.cs`。

## 概念（含 C++ 对照）

### 泛型方法
```csharp
public static T Max<T>(T a, T b) where T : IComparable<T> { ... }
Generics.Max(3, 5);          // T 自动推断为 int
Generics.Max("a", "b");      // T 自动推断为 string
```

### 泛型 vs C++ 模板（关键差异）
| | C++ 模板 | C# 泛型 |
|--|---------|---------|
| 机制 | 编译期**展开**，每个类型生成一份代码 | 运行时**真泛型**，一份 IL，CLR 按类型实例化 |
| 约束 | 直到 C++20 才有 concepts；之前靠「能编译就行」 | `where` 约束，**编译期**强制 |
| 报错 | 经典的模板报错地狱 | 约束让报错清晰得多 |

### 类型约束 `where`
约束告诉编译器「T 至少能做什么」，这样方法体里才能调用对应成员：
```csharp
where T : IComparable<T>   // T 可比较 → 能调用 a.CompareTo(b)
where T : IEquatable<T>    // T 可判等 → 能调用 a.Equals(b)
where T : class            // T 必须是引用类型
where T : new()            // T 必须有无参构造
```
没有约束时，`T` 只能当作 `object` 用（只能调用 `ToString`/`Equals` 等 object 成员）。

### 泛型类（多个类型参数）
```csharp
public class Pair<TFirst, TSecond> { ... }
new Pair<int, string>(1, "one");
```
- **对照 C++**：相当于 `template<class TFirst, class TSecond> class Pair`。

## 运行测试

VS Code 测试面板点本关 ▶；或在本文件夹执行 `dotnet test`。

## 卡住 / 改坏了

```bash
dotnet run --project tools -- save 08
dotnet run --project tools -- restore 08
dotnet run --project tools -- reset 08
```

## 过关提示

全绿即过关。核心心法：**约束不是限制，而是「解锁能力」**——加上 `where T : IComparable<T>`，你才能在方法体里写 `a.CompareTo(b)`。
