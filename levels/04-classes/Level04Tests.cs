// ============================================================
//  第 4 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using Xunit;

namespace CSharpen.Level04;

public class Level04Tests
{
    [Fact]
    public void Constructor_sets_owner_and_balance()
    {
        var account = new BankAccount("Gavin", 100);
        Assert.Equal("Gavin", account.Owner);
        Assert.Equal(100, account.Balance, precision: 6);
    }

    [Fact]
    public void Constructor_balance_defaults_to_zero()
    {
        var account = new BankAccount("Gavin");
        Assert.Equal(0, account.Balance, precision: 6);
    }

    [Fact]
    public void Deposit_increases_balance()
    {
        var account = new BankAccount("Gavin", 50);
        account.Deposit(25);
        Assert.Equal(75, account.Balance, precision: 6);
    }

    [Fact]
    public void Withdraw_succeeds_when_funds_sufficient()
    {
        var account = new BankAccount("Gavin", 100);
        bool ok = account.Withdraw(40);
        Assert.True(ok);
        Assert.Equal(60, account.Balance, precision: 6);
    }

    [Fact]
    public void Withdraw_fails_when_insufficient_and_leaves_balance()
    {
        var account = new BankAccount("Gavin", 30);
        bool ok = account.Withdraw(100);
        Assert.False(ok);
        Assert.Equal(30, account.Balance, precision: 6);
    }

    [Fact]
    public void IsEmpty_reflects_zero_balance()
    {
        Assert.True(new BankAccount("Gavin", 0).IsEmpty);
        Assert.False(new BankAccount("Gavin", 1).IsEmpty);
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(0, 0, 0)]
    [InlineData(5, 12, 13)]
    public void DistanceFromOrigin_uses_pythagoras(double x, double y, double expected)
    {
        var p = new Point { X = x, Y = y }; // 对象初始化器
        Assert.Equal(expected, p.DistanceFromOrigin(), precision: 6);
    }

    [Fact]
    public void Translate_returns_new_point_without_mutating()
    {
        var p = new Point { X = 1, Y = 2 };
        var moved = p.Translate(10, 20);

        Assert.Equal(11, moved.X, precision: 6);
        Assert.Equal(22, moved.Y, precision: 6);
        // 原对象不应被改动
        Assert.Equal(1, p.X, precision: 6);
        Assert.Equal(2, p.Y, precision: 6);
    }
}
