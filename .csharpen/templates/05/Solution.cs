// ============================================================
//  第 5 关：继承与多态
//  这是你要填空的文件。找到每个 // TODO，把代码补完整。
//  改完后运行测试（见本关 README）。全绿即过关。
// ============================================================

namespace CSharpen.Level05;

// =====================================================================
//  抽象基类 Shape。
//  - abstract 方法：没有实现体，派生类「必须」override。
//  - virtual 方法：有默认实现，派生类「可以」override。
//  对照 C++：abstract ↔ 纯虚函数 (= 0)；virtual ↔ 虚函数；
//           C# 派生类重写时「必须」写 override 关键字（C++ 的 override 是可选的）。
// =====================================================================
public abstract class Shape
{
    public abstract double Area();

    public virtual string Name() => "shape";

    // -----------------------------------------------------------------
    // 任务 6：多态求和（静态方法）
    // -----------------------------------------------------------------
    // 要求：遍历 shapes，把每个形状的 Area() 加起来返回。
    //       这里体现「多态」：调用 shape.Area() 时，运行时会按对象的
    //       真实类型（Circle/Rectangle/Square）选择对应实现。
    public static double TotalArea(Shape[] shapes)
    {
        // TODO: 累加每个 shape 的 Area() 并返回。
        throw new System.NotImplementedException();
    }
}

// =====================================================================
//  Circle : Shape
// =====================================================================
public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    // -----------------------------------------------------------------
    // 任务 1：override 抽象方法 Area
    // -----------------------------------------------------------------
    // 要求：返回圆面积 = π * r²。用 System.Math.PI。
    public override double Area()
    {
        // TODO: 返回 Math.PI * Radius * Radius。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 3：override 虚方法 Name
    // -----------------------------------------------------------------
    // 要求：返回 "circle"。
    public override string Name()
    {
        // TODO: 返回 "circle"。
        throw new System.NotImplementedException();
    }
}

// =====================================================================
//  Rectangle : Shape
// =====================================================================
public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    // -----------------------------------------------------------------
    // 任务 2：override 抽象方法 Area
    // -----------------------------------------------------------------
    // 要求：返回矩形面积 = 宽 * 高。
    public override double Area()
    {
        // TODO: 返回 Width * Height。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 4：override 虚方法 Name
    // -----------------------------------------------------------------
    // 要求：返回 "rectangle"。
    public override string Name()
    {
        // TODO: 返回 "rectangle"。
        throw new System.NotImplementedException();
    }
}

// =====================================================================
//  Square : Rectangle（正方形「是一个」边长相等的矩形）
//  注意构造函数用 ": base(side, side)" 调用父类构造函数——
//  这就是 C# 调用基类构造函数的写法（对照 C++ 的初始化列表 : Rectangle(side, side)）。
// =====================================================================
public class Square : Rectangle
{
    public Square(double side) : base(side, side)
    {
    }

    // -----------------------------------------------------------------
    // 任务 5：override 并用 base 调用父类实现
    // -----------------------------------------------------------------
    // base.Xxx() 调用「父类版本」的方法（对照 C++ 的 Base::Xxx()）。
    // 要求：返回 $"square({base.Name()})"。
    //       因为父类 Rectangle.Name() 返回 "rectangle"，
    //       所以最终应得到 "square(rectangle)"。
    public override string Name()
    {
        // TODO: 返回 $"square({base.Name()})"。
        throw new System.NotImplementedException();
    }
}
