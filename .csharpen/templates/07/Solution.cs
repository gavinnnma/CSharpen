// ============================================================
//  第 7 关：集合
//  这是你要填空的文件。找到每个 // TODO，把代码补完整。
//  改完后运行测试（见本关 README）。全绿即过关。
// ============================================================

using System.Collections.Generic;

namespace CSharpen.Level07;

public static class Collections
{
    // -----------------------------------------------------------------
    // 任务 1：遍历 List 求和
    // -----------------------------------------------------------------
    // List<T> 是 C# 最常用的动态数组。对照 C++：相当于 std::vector<T>。
    // foreach 遍历集合，对照 C++：相当于范围 for (for (auto x : v))。
    // 要求：返回 numbers 里所有元素之和。
    public static int SumAll(List<int> numbers)
    {
        // TODO: 用 foreach 累加并返回。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 2：构建一个 List
    // -----------------------------------------------------------------
    // 要求：返回包含 1, 2, ..., n 的 List<int>。n <= 0 时返回空列表。
    // 提示：new List<int>() 然后用 Add 往里加；或用循环。
    public static List<int> CreateRange(int n)
    {
        // TODO: 构造并返回 [1..n]。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 3：用 Dictionary 统计词频
    // -----------------------------------------------------------------
    // Dictionary<K,V> 是键值映射。对照 C++：相当于 std::unordered_map<K,V>。
    // 要求：统计每个单词出现的次数，返回 Dictionary<string,int>。
    // 提示：
    //   if (dict.ContainsKey(w)) dict[w]++; else dict[w] = 1;
    //   也可以用 dict.TryGetValue(...) 模式。
    public static Dictionary<string, int> CountOccurrences(string[] words)
    {
        // TODO: 返回每个词 -> 出现次数 的字典。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 4：查字典（带默认值）
    // -----------------------------------------------------------------
    // 要求：如果 key 在 dict 里，返回它的值；否则返回 fallback。
    // 提示：dict.TryGetValue(key, out var value) 成功时返回 true 并写入 value。
    public static int LookupOr(Dictionary<string, int> dict, string key, int fallback)
    {
        // TODO: 命中返回对应值，否则返回 fallback。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 5：去重并排序
    // -----------------------------------------------------------------
    // HashSet<T> 是不含重复元素的集合。对照 C++：相当于 std::unordered_set<T>。
    // 要求：去掉 values 里的重复元素，返回「升序排列」的 List<int>。
    // 提示：new HashSet<int>(values) 去重；转成 List 后 list.Sort()。
    public static List<int> UniqueSorted(int[] values)
    {
        // TODO: 去重 + 升序，返回 List<int>。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 6：判断是否有重复
    // -----------------------------------------------------------------
    // 要求：如果 values 中存在重复元素返回 true，否则 false。
    // 提示：把元素往 HashSet 里加，Add 返回 false 就说明已存在。
    public static bool ContainsDuplicates(int[] values)
    {
        // TODO: 用 HashSet 判断是否有重复。
        throw new System.NotImplementedException();
    }
}
