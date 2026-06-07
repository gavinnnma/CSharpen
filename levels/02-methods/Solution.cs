// ============================================================
//  第 2 关：方法与参数
//  这是你要填空的文件。找到每个 // TODO，把代码补完整。
//  改完后运行测试（见本关 README）。全绿即过关。
// ============================================================

namespace CSharpen.Level02;

public static class Methods
{
    // -----------------------------------------------------------------
    // 任务 1：out 参数
    // -----------------------------------------------------------------
    // C# 用 out 参数从方法「额外返回」一个值，调用方写 TryXxx(s, out var n)。
    // 对照 C++：你在 C++ 里会用指针或引用参数（int*/int&）来回传；C# 的 out
    // 更明确——编译器强制方法在正常返回前必须给 out 参数赋值。
    // 要求：尝试把字符串解析成整数。成功则把结果写入 result 并返回 true；
    //       失败（无法解析）则返回 false。
    // 提示：int.TryParse(s, out result) 本身就符合这个签名。
    public static bool TryParseInt(string s, out int result)
    {
        // TODO: 用 int.TryParse 解析 s，把结果写入 result，并返回是否成功。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 2：ref 参数
    // -----------------------------------------------------------------
    // ref 参数是「双向」的：调用方传进来的变量会被原地修改。
    // 对照 C++：相当于 int&（引用传递）。区别是 C# 在调用处也要写 ref，
    // 例如 Triple(ref x)，调用点一眼能看出该变量会被改。
    // 要求：把 value 原地变成它的 3 倍。
    public static void Triple(ref int value)
    {
        // TODO: 让 value 变成原来的 3 倍。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 3：用 ref 实现交换
    // -----------------------------------------------------------------
    // 要求：交换 a 和 b 的值（经典 swap）。
    // 对照 C++：等价于 std::swap(a, b) 或手写引用交换。
    public static void Swap(ref int a, ref int b)
    {
        // TODO: 交换 a 和 b。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 4：可选参数（默认值）
    // -----------------------------------------------------------------
    // C# 方法参数可以有默认值，调用时不传就用默认值。
    // 对照 C++：和 C++ 的默认实参几乎一样（int Power(int b, int e = 2)）。
    // 要求：返回 baseValue 的 exponent 次幂；exponent 默认为 2（平方）。
    //       可假设 exponent >= 0。
    public static int Power(int baseValue, int exponent = 2)
    {
        // TODO: 计算 baseValue 的 exponent 次方并返回。
        // 提示：可以用循环连乘；exponent 为 0 时结果是 1。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 5：方法重载
    // -----------------------------------------------------------------
    // 同名方法、不同参数类型即可重载，编译器按实参类型选择。
    // 对照 C++：和 C++ 的函数重载概念一致。
    // 要求：实现两个 Describe 重载：
    //   - 传入 int n   → 返回 $"int: {n}"
    //   - 传入 string s → 返回 $"string: {s}"
    public static string Describe(int n)
    {
        // TODO: 返回形如 "int: 5" 的字符串。
        throw new System.NotImplementedException();
    }

    public static string Describe(string s)
    {
        // TODO: 返回形如 "string: hi" 的字符串。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 6：params 可变参数
    // -----------------------------------------------------------------
    // params 让方法接收任意多个同类型实参：SumAll(1, 2, 3) 或 SumAll()。
    // 对照 C++：类似可变参数模板/initializer_list，但语法更简单。
    // 要求：返回所有传入整数的和；没有传任何参数时返回 0。
    public static int SumAll(params int[] numbers)
    {
        // TODO: 把 numbers 里所有元素相加并返回。
        throw new System.NotImplementedException();
    }
}
