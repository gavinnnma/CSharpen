// ============================================================
//  第 6 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using System;
using Xunit;

namespace CSharpen.Level06;

public class Level06Tests
{
    [Fact]
    public void Rectangle_implements_IArea()
    {
        IArea r = new Rectangle(2, 3);
        Assert.Equal(6.0, r.Area(), precision: 6);
    }

    [Fact]
    public void Rectangle_implements_INamed()
    {
        INamed r = new Rectangle(1, 1);
        Assert.Equal("rectangle", r.Name);
    }

    [Theory]
    [InlineData(1.0)]
    [InlineData(2.0)]
    public void Circle_implements_IArea(double radius)
    {
        IArea c = new Circle(radius);
        Assert.Equal(Math.PI * radius * radius, c.Area(), precision: 6);
    }

    [Fact]
    public void TotalArea_works_over_interface()
    {
        IArea[] shapes =
        {
            new Rectangle(2, 3), // 6
            new Circle(1),       // π
        };
        Assert.Equal(6 + Math.PI, Shapes.TotalArea(shapes), precision: 6);
    }

    [Fact]
    public void Explicit_english_greeter()
    {
        // 显式实现只能通过接口类型访问。
        IEnglishGreeter g = new BilingualGreeter();
        Assert.Equal("Hello", g.Greet());
    }

    [Fact]
    public void Explicit_french_greeter()
    {
        IFrenchGreeter g = new BilingualGreeter();
        Assert.Equal("Bonjour", g.Greet());
    }

    [Fact]
    public void Same_instance_two_interfaces()
    {
        var bilingual = new BilingualGreeter();
        Assert.Equal("Hello", ((IEnglishGreeter)bilingual).Greet());
        Assert.Equal("Bonjour", ((IFrenchGreeter)bilingual).Greet());
    }
}
