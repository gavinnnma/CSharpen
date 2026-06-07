// ============================================================
//  第 1 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using Xunit;

namespace CSharpen.Level01;

public class Level01Tests
{
    [Fact]
    public void TheAnswer_returns_42()
    {
        Assert.Equal(42, Basics.TheAnswer());
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(0, 0, 0)]
    [InlineData(-5, 5, 0)]
    [InlineData(100, 250, 350)]
    public void Add_returns_sum(int a, int b, int expected)
    {
        Assert.Equal(expected, Basics.Add(a, b));
    }

    [Theory]
    [InlineData(2, true)]
    [InlineData(3, false)]
    [InlineData(0, true)]
    [InlineData(-4, true)]
    [InlineData(-7, false)]
    public void IsEven_detects_even_numbers(int n, bool expected)
    {
        Assert.Equal(expected, Basics.IsEven(n));
    }

    [Fact]
    public void Divide_does_floating_point_division()
    {
        // 5 / 2 应得 2.5，而不是整数除法的 2。
        Assert.Equal(2.5, Basics.Divide(5, 2), precision: 6);
    }

    [Fact]
    public void Divide_handles_exact_division()
    {
        Assert.Equal(4.0, Basics.Divide(8, 2), precision: 6);
    }

    [Fact]
    public void Pi_is_set()
    {
        Assert.Equal(3.14, Basics.Pi, precision: 6);
    }

    [Theory]
    [InlineData(1.0, 3.14)]
    [InlineData(2.0, 12.56)]
    [InlineData(0.0, 0.0)]
    public void CircleArea_uses_Pi(double r, double expected)
    {
        Assert.Equal(expected, Basics.CircleArea(r), precision: 6);
    }
}
