// ============================================================
//  第 12 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using System.Threading.Tasks;
using Xunit;

namespace CSharpen.Level12;

public class Level12Tests
{
    [Fact]
    public async Task GetFortyTwo_returns_42()
    {
        Assert.Equal(42, await Async.GetFortyTwoAsync());
    }

    [Theory]
    [InlineData(5, 25)]
    [InlineData(0, 0)]
    [InlineData(-3, 9)]
    public async Task SquareAsync_squares(int n, int expected)
    {
        Assert.Equal(expected, await Async.SquareAsync(n));
    }

    [Theory]
    [InlineData(3, 4, 7)]
    [InlineData(-1, 1, 0)]
    public async Task AddAsync_adds(int a, int b, int expected)
    {
        Assert.Equal(expected, await Async.AddAsync(a, b));
    }

    [Fact]
    public async Task SumOfSquaresAsync_composes_awaits()
    {
        // 3² + 4² = 9 + 16 = 25
        Assert.Equal(25, await Async.SumOfSquaresAsync(3, 4));
    }

    [Fact]
    public async Task ParallelSumAsync_uses_when_all()
    {
        Assert.Equal(25, await Async.ParallelSumAsync(3, 4));
        Assert.Equal(2, await Async.ParallelSumAsync(1, 1));
    }

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(10, 0, -1)]  // 除零被捕获 → -1
    public async Task SafeDivideAsync_handles_divide_by_zero(int a, int b, int expected)
    {
        Assert.Equal(expected, await Async.SafeDivideAsync(a, b));
    }
}
