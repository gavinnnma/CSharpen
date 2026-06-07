// ============================================================
//  第 2 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using Xunit;

namespace CSharpen.Level02;

public class Level02Tests
{
    [Theory]
    [InlineData("42", true, 42)]
    [InlineData("-7", true, -7)]
    [InlineData("0", true, 0)]
    [InlineData("abc", false, 0)]
    [InlineData("", false, 0)]
    public void TryParseInt_reports_success_and_value(string s, bool expectedOk, int expectedValue)
    {
        bool ok = Methods.TryParseInt(s, out int value);
        Assert.Equal(expectedOk, ok);
        if (expectedOk)
            Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData(1, 3)]
    [InlineData(0, 0)]
    [InlineData(-4, -12)]
    public void Triple_multiplies_in_place(int input, int expected)
    {
        int value = input;
        Methods.Triple(ref value);
        Assert.Equal(expected, value);
    }

    [Fact]
    public void Swap_exchanges_values()
    {
        int a = 1, b = 2;
        Methods.Swap(ref a, ref b);
        Assert.Equal(2, a);
        Assert.Equal(1, b);
    }

    [Theory]
    [InlineData(5, 2, 25)]
    [InlineData(2, 10, 1024)]
    [InlineData(7, 0, 1)]
    [InlineData(3, 1, 3)]
    public void Power_computes_exponent(int baseValue, int exponent, int expected)
    {
        Assert.Equal(expected, Methods.Power(baseValue, exponent));
    }

    [Theory]
    [InlineData(4, 16)]
    [InlineData(9, 81)]
    public void Power_defaults_to_square(int baseValue, int expected)
    {
        // 不传 exponent 时应当默认平方。
        Assert.Equal(expected, Methods.Power(baseValue));
    }

    [Fact]
    public void Describe_int_overload()
    {
        Assert.Equal("int: 5", Methods.Describe(5));
    }

    [Fact]
    public void Describe_string_overload()
    {
        Assert.Equal("string: hi", Methods.Describe("hi"));
    }

    [Fact]
    public void SumAll_adds_all_arguments()
    {
        Assert.Equal(6, Methods.SumAll(1, 2, 3));
        Assert.Equal(0, Methods.SumAll());
        Assert.Equal(10, Methods.SumAll(10));
        Assert.Equal(0, Methods.SumAll(-5, 5));
    }
}
