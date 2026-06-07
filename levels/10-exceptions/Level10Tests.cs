// ============================================================
//  第 10 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using Xunit;

namespace CSharpen.Level10;

public class Level10Tests
{
    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(7, 0, 0)]   // 除零被捕获 → 0
    [InlineData(9, 3, 3)]
    public void SafeDivide_handles_divide_by_zero(int a, int b, int expected)
    {
        Assert.Equal(expected, Exceptions.SafeDivide(a, b));
    }

    [Theory]
    [InlineData("42", -1, 42)]
    [InlineData("abc", -1, -1)]   // 解析失败 → fallback
    [InlineData("", 0, 0)]
    public void ParseOrDefault_falls_back_on_bad_input(string s, int fallback, int expected)
    {
        Assert.Equal(expected, Exceptions.ParseOrDefault(s, fallback));
    }

    [Fact]
    public void Withdraw_succeeds_with_enough_balance()
    {
        Assert.Equal(60, Exceptions.Withdraw(100, 40));
    }

    [Fact]
    public void Withdraw_throws_custom_exception_when_insufficient()
    {
        Assert.Throws<InsufficientFundsException>(() => Exceptions.Withdraw(50, 100));
    }

    [Fact]
    public void Custom_exception_is_an_exception_and_carries_message()
    {
        var ex = new InsufficientFundsException("too poor");
        Assert.IsAssignableFrom<System.Exception>(ex);
        Assert.Equal("too poor", ex.Message);
    }

    [Fact]
    public void ExecuteWithCleanup_runs_finally_on_success()
    {
        int result = Exceptions.ExecuteWithCleanup(10, 2, out bool cleanedUp);
        Assert.Equal(5, result);
        Assert.True(cleanedUp);
    }

    [Fact]
    public void ExecuteWithCleanup_runs_finally_on_error()
    {
        int result = Exceptions.ExecuteWithCleanup(10, 0, out bool cleanedUp);
        Assert.Equal(-1, result);
        Assert.True(cleanedUp); // finally 即使出异常也要执行
    }

    [Fact]
    public void CloseResource_disposes_via_using()
    {
        var resource = new TrackedResource();
        Assert.False(resource.IsDisposed);
        Exceptions.CloseResource(resource);
        Assert.True(resource.IsDisposed);
    }
}
