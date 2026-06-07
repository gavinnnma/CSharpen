// ============================================================
//  第 5 关测试 —— 不要修改本文件。
//  这些测试检查你在 Solution.cs 里写的代码。
//  运行：在本文件夹执行 dotnet test，或用 VS Code 测试面板。
// ============================================================

using System;
using Xunit;

namespace CSharpen.Level05;

public class Level05Tests
{
    [Theory]
    [InlineData(1.0)]
    [InlineData(2.5)]
    [InlineData(0.0)]
    public void Circle_area_uses_pi(double r)
    {
        var c = new Circle(r);
        Assert.Equal(Math.PI * r * r, c.Area(), precision: 6);
    }

    [Theory]
    [InlineData(2.0, 3.0, 6.0)]
    [InlineData(5.0, 5.0, 25.0)]
    public void Rectangle_area_is_width_times_height(double w, double h, double expected)
    {
        Assert.Equal(expected, new Rectangle(w, h).Area(), precision: 6);
    }

    [Fact]
    public void Square_area_via_inherited_rectangle()
    {
        // Square 继承 Rectangle 的 Area 实现，边长 4 → 面积 16。
        Assert.Equal(16.0, new Square(4).Area(), precision: 6);
    }

    [Fact]
    public void Names_are_overridden()
    {
        Assert.Equal("circle", new Circle(1).Name());
        Assert.Equal("rectangle", new Rectangle(1, 1).Name());
    }

    [Fact]
    public void Square_name_uses_base_call()
    {
        Assert.Equal("square(rectangle)", new Square(2).Name());
    }

    [Fact]
    public void Name_is_polymorphic_through_base_reference()
    {
        // 用基类引用指向派生对象，调用应分派到派生类实现。
        Shape s = new Circle(1);
        Assert.Equal("circle", s.Name());
    }

    [Fact]
    public void TotalArea_sums_polymorphically()
    {
        Shape[] shapes =
        {
            new Rectangle(2, 3), // 6
            new Square(2),       // 4
            new Circle(1),       // π
        };
        double expected = 6 + 4 + Math.PI;
        Assert.Equal(expected, Shape.TotalArea(shapes), precision: 6);
    }
}
