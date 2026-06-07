// ============================================================
//  第 9 关：LINQ
//  这是你要填空的文件。找到每个 // TODO，把代码补完整。
//  改完后运行测试（见本关 README）。全绿即过关。
// ============================================================

using System.Linq;

namespace CSharpen.Level09;

// LINQ（Language Integrated Query）是 C# 处理集合的「瑞士军刀」，C++ 没有
// 直接对应物（最接近的是 ranges/views，但 LINQ 用起来顺手得多）。
// 本关用到「Lambda 表达式」：n => n % 2 == 0 读作「给定 n，返回 n 是否为偶数」。
// （第 11 关会专门讲 Lambda；这里先会用即可。）
public static class Linq
{
    // -----------------------------------------------------------------
    // 任务 1：Where —— 过滤
    // -----------------------------------------------------------------
    // 要求：返回所有偶数（保持原顺序）。
    // 提示：numbers.Where(n => n % 2 == 0).ToArray()
    public static int[] EvenNumbers(int[] numbers)
    {
        // TODO: 用 Where 过滤偶数，ToArray 返回。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 2：Select —— 映射/变换
    // -----------------------------------------------------------------
    // 要求：返回每个元素的平方（保持原顺序）。
    // 提示：numbers.Select(n => n * n).ToArray()
    public static int[] Squares(int[] numbers)
    {
        // TODO: 用 Select 求平方，ToArray 返回。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 3：OrderByDescending —— 排序
    // -----------------------------------------------------------------
    // 要求：返回降序排列后的数组（原数组不被修改）。
    // 提示：numbers.OrderByDescending(n => n).ToArray()
    public static int[] SortedDescending(int[] numbers)
    {
        // TODO: 降序排序后 ToArray 返回。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 4：链式调用 Where + Sum —— 聚合
    // -----------------------------------------------------------------
    // LINQ 方法可以链起来：先过滤，再聚合。
    // 要求：返回所有偶数之和。
    // 提示：numbers.Where(n => n % 2 == 0).Sum()
    public static int SumOfEvens(int[] numbers)
    {
        // TODO: 偶数求和。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 5：All —— 全体判断
    // -----------------------------------------------------------------
    // 要求：当所有元素都 > 0 时返回 true，否则 false。
    //       （空数组按 LINQ 语义 All 返回 true，无需特判。）
    // 提示：numbers.All(n => n > 0)
    public static bool AllPositive(int[] numbers)
    {
        // TODO: 判断是否全为正数。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 6：OrderByDescending + First —— 取「最…」的一个
    // -----------------------------------------------------------------
    // 要求：返回最长的单词（可假设非空；若有并列，返回排在前面的那个即可）。
    // 提示：words.OrderByDescending(w => w.Length).First()
    public static string LongestWord(string[] words)
    {
        // TODO: 返回最长单词。
        throw new System.NotImplementedException();
    }
}
