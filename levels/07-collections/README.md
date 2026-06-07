# 第 7 关：集合

## 目标

掌握 C# 三大常用集合及其与 STL 的对应：`List<T>`、`Dictionary<K,V>`、`HashSet<T>`，以及用 `foreach` 遍历。

## 你要做什么

打开 `Solution.cs`，把 6 个 `// TODO` 补完整。改完跑测试，全绿即过关。不要改 `Level07Tests.cs`。

## 概念（含 C++ 对照）

### 集合对照表
| C# | C++ | 说明 |
|----|-----|------|
| `List<T>` | `std::vector<T>` | 动态数组；`Add` ↔ `push_back`，`Count` ↔ `size()`，`list[i]` 索引访问 |
| `Dictionary<K,V>` | `std::unordered_map<K,V>` | 键值映射；`dict[k]` 读写，`ContainsKey`/`TryGetValue` 查存在 |
| `HashSet<T>` | `std::unordered_set<T>` | 不重复集合；`Add` 返回 `bool`（是否真的新加） |

它们都在 `System.Collections.Generic` 命名空间下（本关已 `using`）。

### foreach
```csharp
foreach (int x in numbers) { sum += x; }
```
- **对照 C++**：相当于范围 for `for (auto x : v)`。

### Dictionary 的几种用法
```csharp
var dict = new Dictionary<string, int>();
dict["a"] = 1;                       // 写
if (dict.ContainsKey("a")) { ... }   // 查
if (dict.TryGetValue("a", out int v)) { ... } // 查 + 取，一步到位（推荐）
var d2 = new Dictionary<string,int> { ["x"] = 10 }; // 集合初始化器
```
注意：用 `dict[k]` 读一个**不存在**的键会抛 `KeyNotFoundException`（不像 C++ `map[k]` 会默默插入默认值）——所以查不确定的键要用 `TryGetValue`/`ContainsKey`。

### HashSet 去重技巧
```csharp
var set = new HashSet<int>(values); // 直接用数组构造即完成去重
bool isNew = set.Add(x);            // 已存在则返回 false
```

## 运行测试

VS Code 测试面板点本关 ▶；或在本文件夹执行 `dotnet test`。

## 卡住 / 改坏了

```bash
dotnet run --project tools -- save 07
dotnet run --project tools -- restore 07
dotnet run --project tools -- reset 07
```

## 过关提示

全绿即过关。记住一个和 C++ 不同的坑：`Dictionary` 用 `[]` 读不存在的键会**抛异常**，不会自动插入——查不准的键一律用 `TryGetValue`。
