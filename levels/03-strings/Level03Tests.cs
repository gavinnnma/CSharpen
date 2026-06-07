// ============================================================
//  第 3 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using Xunit;

namespace CSharpen.Level03;

public class Level03Tests
{
    [Theory]
    [InlineData("Gavin", "Hello, Gavin!")]
    [InlineData("C#", "Hello, C#!")]
    public void Greet_interpolates_name(string name, string expected)
    {
        Assert.Equal(expected, StringOps.Greet(name));
    }

    [Theory]
    [InlineData("hello", "HELLO")]
    [InlineData("Mixed", "MIXED")]
    [InlineData("", "")]
    public void Shout_uppercases(string s, string expected)
    {
        Assert.Equal(expected, StringOps.Shout(s));
    }

    [Theory]
    [InlineData("hello", "Hello")]
    [InlineData("a", "A")]
    [InlineData("Already", "Already")]
    [InlineData("", "")]
    public void Capitalize_uppercases_first_letter(string s, string expected)
    {
        Assert.Equal(expected, StringOps.Capitalize(s));
    }

    [Theory]
    [InlineData("banana", 'a', 3)]
    [InlineData("banana", 'n', 2)]
    [InlineData("banana", 'z', 0)]
    [InlineData("", 'a', 0)]
    public void CountChar_counts_occurrences(string s, char c, int expected)
    {
        Assert.Equal(expected, StringOps.CountChar(s, c));
    }

    [Theory]
    [InlineData("abc", "cba")]
    [InlineData("hello", "olleh")]
    [InlineData("x", "x")]
    [InlineData("", "")]
    public void Reverse_reverses_string(string s, string expected)
    {
        Assert.Equal(expected, StringOps.Reverse(s));
    }

    [Theory]
    [InlineData("level", true)]
    [InlineData("Level", true)]
    [InlineData("RaceCar", true)]
    [InlineData("hello", false)]
    [InlineData("", true)]
    public void IsPalindrome_ignores_case(string s, bool expected)
    {
        Assert.Equal(expected, StringOps.IsPalindrome(s));
    }
}
