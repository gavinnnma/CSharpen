// ============================================================
//  第 8 关：泛型
//  这是你要填空的文件。找到每个 // TODO，把代码补完整。
//  改完后运行测试（见本关 README）。全绿即过关。
// ============================================================

using System;

namespace CSharpen.Level08;

public static class Generics
{
    // -----------------------------------------------------------------
    // 任务 1：带约束的泛型方法
    // -----------------------------------------------------------------
    // <T> 是类型参数；where T : IComparable<T> 是「约束」，要求 T 可比较。
    // 对照 C++：类似 template<typename T>，约束类似 C++20 concepts；
    //          但 C# 泛型在运行时是真泛型（不是模板展开），约束在编译期检查。
    // 要求：返回 a、b 中较大的那个。
    // 提示：a.CompareTo(b) > 0 表示 a 比 b 大。
    public static T Max<T>(T a, T b) where T : IComparable<T>
    {
        // TODO: 返回较大者。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 2：泛型 + ref（任意类型的交换）
    // -----------------------------------------------------------------
    // 要求：交换 a 和 b（适用于任意类型 T）。
    public static void Swap<T>(ref T a, ref T b)
    {
        // TODO: 交换 a 和 b。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 3：泛型数组取首元素
    // -----------------------------------------------------------------
    // 要求：返回数组的第一个元素（可假设数组非空）。
    public static T First<T>(T[] items)
    {
        // TODO: 返回 items[0]。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 4：约束 + 遍历，求数组最大值
    // -----------------------------------------------------------------
    // 要求：返回数组中最大的元素（可假设数组非空）。可复用 Max。
    public static T MaxInArray<T>(T[] items) where T : IComparable<T>
    {
        // TODO: 遍历 items，返回最大值。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 6：约束为 IEquatable，判断相等
    // -----------------------------------------------------------------
    // 要求：用 a.Equals(b) 判断两个值是否相等。
    public static bool AreEqual<T>(T a, T b) where T : IEquatable<T>
    {
        // TODO: 返回 a.Equals(b)。
        throw new System.NotImplementedException();
    }
}

// =====================================================================
//  任务 5：泛型类（含两个类型参数）
// =====================================================================
// 对照 C++：相当于 template<class TFirst, class TSecond> class Pair { ... };
public class Pair<TFirst, TSecond>
{
    public TFirst First { get; }
    public TSecond Second { get; }

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }

    // -----------------------------------------------------------------
    // 任务 5：返回首尾对调的新 Pair（注意类型参数也跟着对调）
    // -----------------------------------------------------------------
    // 要求：返回一个新的 Pair<TSecond, TFirst>，其 First = 原 Second，
    //       Second = 原 First。
    public Pair<TSecond, TFirst> Swapped()
    {
        // TODO: 返回 new Pair<TSecond, TFirst>(Second, First)。
        throw new System.NotImplementedException();
    }
}
