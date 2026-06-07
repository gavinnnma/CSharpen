// ============================================================
//  第 8 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using Xunit;

namespace CSharpen.Level08;

public class Level08Tests
{
    [Fact]
    public void Max_works_on_ints()
    {
        Assert.Equal(5, Generics.Max(3, 5));
        Assert.Equal(5, Generics.Max(5, 3));
    }

    [Fact]
    public void Max_works_on_strings()
    {
        // string 实现了 IComparable<string>，按字典序比较。
        Assert.Equal("banana", Generics.Max("apple", "banana"));
    }

    [Fact]
    public void Swap_works_on_any_type()
    {
        int a = 1, b = 2;
        Generics.Swap(ref a, ref b);
        Assert.Equal(2, a);
        Assert.Equal(1, b);

        string x = "x", y = "y";
        Generics.Swap(ref x, ref y);
        Assert.Equal("y", x);
        Assert.Equal("x", y);
    }

    [Fact]
    public void First_returns_first_element()
    {
        Assert.Equal(10, Generics.First(new[] { 10, 20, 30 }));
        Assert.Equal("a", Generics.First(new[] { "a", "b" }));
    }

    [Fact]
    public void MaxInArray_finds_maximum()
    {
        Assert.Equal(9, Generics.MaxInArray(new[] { 3, 9, 1, 7 }));
        Assert.Equal("pear", Generics.MaxInArray(new[] { "apple", "pear", "kiwi" }));
    }

    [Fact]
    public void Pair_swapped_exchanges_values_and_types()
    {
        var pair = new Pair<int, string>(1, "one");
        Pair<string, int> swapped = pair.Swapped();
        Assert.Equal("one", swapped.First);
        Assert.Equal(1, swapped.Second);
    }

    [Fact]
    public void AreEqual_compares_values()
    {
        Assert.True(Generics.AreEqual(2, 2));
        Assert.False(Generics.AreEqual(2, 3));
        Assert.True(Generics.AreEqual("x", "x"));
        Assert.False(Generics.AreEqual("x", "y"));
    }
}
