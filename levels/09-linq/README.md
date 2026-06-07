# 第 9 关：LINQ

## 目标

学会用 LINQ 流式处理集合：`Where`、`Select`、`OrderBy(Descending)`、`Sum`、`All`/`Any`、`First`，并能把它们**链式**组合。这是 C# 相对 C++ 的一大生产力优势。

## 你要做什么

打开 `Solution.cs`，把 6 个 `// TODO` 补完整。改完跑测试，全绿即过关。不要改 `Level09Tests.cs`。

## 概念（含 C++ 对照）

### LINQ 是什么
一组作用于集合的扩展方法，能把「过滤→变换→排序→聚合」写成一条流水线：
```csharp
numbers.Where(n => n % 2 == 0)   // 过滤
       .Select(n => n * n)        // 变换
       .Sum();                    // 聚合
```
- **对照 C++**：最接近的是 C++20 的 ranges/views（`std::views::filter | std::views::transform`），但 LINQ 早了十几年且更易读。以前在 C++ 你得手写循环或用 `<algorithm>`。

### Lambda 速览（第 11 关详解）
`n => n % 2 == 0` 是一个匿名函数：参数 `n`，返回箭头右边的表达式。
- **对照 C++**：相当于 `[](int n){ return n % 2 == 0; }`，但不用写类型和 `return`。

### 常用算子对照
| LINQ | 作用 | C++ `<algorithm>` 类比 |
|------|------|------------------------|
| `Where(pred)` | 过滤 | `std::copy_if` |
| `Select(f)` | 映射 | `std::transform` |
| `OrderBy(key)` / `OrderByDescending(key)` | 排序（返回新序列，不改原集合）| `std::sort`（原地）|
| `Sum()` / `Count()` / `Max()` | 聚合 | `std::accumulate` / `std::count` |
| `All(pred)` / `Any(pred)` | 全体/存在判断 | `std::all_of` / `std::any_of` |
| `First()` / `FirstOrDefault()` | 取第一个 | `*v.begin()` |

### 延迟执行 + ToArray
`Where`/`Select` 返回的是**惰性序列**（`IEnumerable<T>`），还没真正算。调用 `ToArray()`/`ToList()` 或遍历时才执行。本关需要返回数组，所以末尾要 `.ToArray()`。

## 运行测试

VS Code 测试面板点本关 ▶；或在本文件夹执行 `dotnet test`。

## 卡住 / 改坏了

```bash
dotnet run --project tools -- save 09
dotnet run --project tools -- restore 09
dotnet run --project tools -- reset 09
```

## 过关提示

全绿即过关。两个易忘点：① `OrderBy` **不改原集合**、返回新序列；② 想要具体数组/列表，记得在链尾 `.ToArray()` / `.ToList()`。
