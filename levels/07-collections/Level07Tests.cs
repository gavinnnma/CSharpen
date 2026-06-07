// ============================================================
//  第 7 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using System.Collections.Generic;
using Xunit;

namespace CSharpen.Level07;

public class Level07Tests
{
    [Fact]
    public void SumAll_adds_list()
    {
        Assert.Equal(6, Collections.SumAll(new List<int> { 1, 2, 3 }));
        Assert.Equal(0, Collections.SumAll(new List<int>()));
    }

    [Fact]
    public void CreateRange_builds_one_to_n()
    {
        Assert.Equal(new List<int> { 1, 2, 3, 4 }, Collections.CreateRange(4));
        Assert.Equal(new List<int> { 1 }, Collections.CreateRange(1));
        Assert.Empty(Collections.CreateRange(0));
        Assert.Empty(Collections.CreateRange(-3));
    }

    [Fact]
    public void CountOccurrences_counts_words()
    {
        var result = Collections.CountOccurrences(new[] { "a", "b", "a", "a", "b" });
        Assert.Equal(3, result["a"]);
        Assert.Equal(2, result["b"]);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void CountOccurrences_empty_input()
    {
        Assert.Empty(Collections.CountOccurrences(new string[0]));
    }

    [Fact]
    public void LookupOr_returns_value_or_fallback()
    {
        var dict = new Dictionary<string, int> { ["x"] = 10 };
        Assert.Equal(10, Collections.LookupOr(dict, "x", -1));
        Assert.Equal(-1, Collections.LookupOr(dict, "missing", -1));
    }

    [Fact]
    public void UniqueSorted_dedups_and_sorts()
    {
        Assert.Equal(
            new List<int> { 1, 2, 3, 5 },
            Collections.UniqueSorted(new[] { 5, 1, 2, 2, 3, 1, 5 }));
        Assert.Empty(Collections.UniqueSorted(new int[0]));
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, false)]
    [InlineData(new[] { 1, 2, 2 }, true)]
    [InlineData(new int[0], false)]
    [InlineData(new[] { 7, 7 }, true)]
    public void ContainsDuplicates_detects_repeats(int[] values, bool expected)
    {
        Assert.Equal(expected, Collections.ContainsDuplicates(values));
    }
}
