// ============================================================
//  第 9 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using Xunit;

namespace CSharpen.Level09;

public class Level09Tests
{
    [Fact]
    public void EvenNumbers_filters_evens()
    {
        Assert.Equal(new[] { 2, 4, 6 }, Linq.EvenNumbers(new[] { 1, 2, 3, 4, 5, 6 }));
        Assert.Empty(Linq.EvenNumbers(new[] { 1, 3, 5 }));
    }

    [Fact]
    public void Squares_maps_each_element()
    {
        Assert.Equal(new[] { 1, 4, 9 }, Linq.Squares(new[] { 1, 2, 3 }));
    }

    [Fact]
    public void SortedDescending_orders_and_does_not_mutate()
    {
        var input = new[] { 3, 1, 2 };
        Assert.Equal(new[] { 3, 2, 1 }, Linq.SortedDescending(input));
        // 原数组不应被改动
        Assert.Equal(new[] { 3, 1, 2 }, input);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, 6)]
    [InlineData(new[] { 1, 3, 5 }, 0)]
    [InlineData(new[] { 2, 4, 6 }, 12)]
    public void SumOfEvens_sums_even_values(int[] input, int expected)
    {
        Assert.Equal(expected, Linq.SumOfEvens(input));
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, true)]
    [InlineData(new[] { 1, -2, 3 }, false)]
    [InlineData(new[] { 0, 1 }, false)]
    public void AllPositive_checks_all(int[] input, bool expected)
    {
        Assert.Equal(expected, Linq.AllPositive(input));
    }

    [Fact]
    public void LongestWord_returns_longest()
    {
        Assert.Equal("banana", Linq.LongestWord(new[] { "a", "banana", "kiwi" }));
        Assert.Equal("x", Linq.LongestWord(new[] { "x" }));
    }
}
