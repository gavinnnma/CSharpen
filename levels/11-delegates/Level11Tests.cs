// ============================================================
//  第 11 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using Xunit;

namespace CSharpen.Level11;

public class Level11Tests
{
    [Fact]
    public void Apply_invokes_function()
    {
        Assert.Equal(10, Delegates.Apply(x => x * 2, 5));
        Assert.Equal(6, Delegates.Apply(x => x + 1, 5));
    }

    [Fact]
    public void MakeAdder_returns_closure()
    {
        var add3 = Delegates.MakeAdder(3);
        Assert.Equal(13, add3(10));
        Assert.Equal(3, add3(0));

        var add10 = Delegates.MakeAdder(10);
        Assert.Equal(15, add10(5));
    }

    [Fact]
    public void RunTimes_invokes_action_n_times()
    {
        int counter = 0;
        Delegates.RunTimes(4, () => counter++);
        Assert.Equal(4, counter);

        Delegates.RunTimes(0, () => counter++);
        Assert.Equal(4, counter); // 0 次：不变
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, 2)]   // 偶数个数
    [InlineData(new[] { 1, 3, 5 }, 0)]
    public void CountMatching_counts_predicate_hits(int[] numbers, int expected)
    {
        Assert.Equal(expected, Delegates.CountMatching(numbers, n => n % 2 == 0));
    }

    [Fact]
    public void Combine_uses_custom_delegate()
    {
        Assert.Equal(7, Delegates.Combine(3, 4, (a, b) => a + b));
        Assert.Equal(12, Delegates.Combine(3, 4, (a, b) => a * b));
    }

    [Fact]
    public void Click_notifies_subscribers()
    {
        var button = new Button();
        int clicks = 0;
        button.Clicked += () => clicks++;

        button.Click();
        button.Click();

        Assert.Equal(2, clicks);
    }

    [Fact]
    public void Click_without_subscribers_does_not_throw()
    {
        var button = new Button();
        button.Click(); // 不应抛异常
    }
}
