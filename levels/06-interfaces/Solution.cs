// ============================================================
//  第 6 关：接口
//  这是你要填空的文件。找到每个 // TODO，把代码补完整。
//  改完后运行测试（见本关 README）。全绿即过关。
// ============================================================

namespace CSharpen.Level06;

// =====================================================================
//  接口只定义「能做什么」，不含实现。
//  对照 C++：相当于「只有纯虚函数、没有数据成员」的抽象类。
//  一个类可以同时实现多个接口（C# 类是单继承，但可实现任意多个接口）。
// =====================================================================
public interface IArea
{
    double Area();
}

public interface INamed
{
    // 接口里也能声明属性（这里是只读属性）。
    string Name { get; }
}

// =====================================================================
//  Rectangle 同时实现 IArea 和 INamed。
// =====================================================================
public class Rectangle : IArea, INamed
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    // -----------------------------------------------------------------
    // 任务 1：实现接口方法 IArea.Area（隐式实现）
    // -----------------------------------------------------------------
    // 「隐式实现」= 写成普通 public 方法即可，签名对上接口就算实现了。
    // 要求：返回 Width * Height。
    public double Area()
    {
        // TODO: 返回 Width * Height。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 2：实现接口属性 INamed.Name
    // -----------------------------------------------------------------
    // 要求：返回 "rectangle"。
    public string Name => throw new System.NotImplementedException();
    // TODO: 把上一行改成： public string Name => "rectangle";
}

// =====================================================================
//  Circle 也实现这两个接口（用于演示「面向接口」的多态）。
// =====================================================================
public class Circle : IArea, INamed
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    // -----------------------------------------------------------------
    // 任务 3：实现 IArea.Area
    // -----------------------------------------------------------------
    // 要求：返回圆面积 = π * r²（用 System.Math.PI）。
    public double Area()
    {
        // TODO: 返回 Math.PI * Radius * Radius。
        throw new System.NotImplementedException();
    }

    // Name 已替你实现好，作为对照参考。
    public string Name => "circle";
}

// =====================================================================
//  面向接口编程：方法只依赖接口，不关心具体类型。
// =====================================================================
public static class Shapes
{
    // -----------------------------------------------------------------
    // 任务 4：通过接口实现多态
    // -----------------------------------------------------------------
    // 要求：把数组里每个形状的 Area() 加起来返回。
    //       注意参数类型是接口 IArea——Rectangle、Circle 都能传进来。
    public static double TotalArea(IArea[] shapes)
    {
        // TODO: 累加每个 shape.Area() 并返回。
        throw new System.NotImplementedException();
    }
}

// =====================================================================
//  显式接口实现：当两个接口有同名成员、或你想「隐藏」接口成员时使用。
//  显式实现的成员「只能」通过接口类型访问，不能通过类实例直接调用。
// =====================================================================
public interface IEnglishGreeter
{
    string Greet();
}

public interface IFrenchGreeter
{
    string Greet();
}

public class BilingualGreeter : IEnglishGreeter, IFrenchGreeter
{
    // -----------------------------------------------------------------
    // 任务 5：显式实现 IEnglishGreeter.Greet
    // -----------------------------------------------------------------
    // 注意写法：方法名前加「接口名.」，且不写 public。
    // 要求：返回 "Hello"。
    string IEnglishGreeter.Greet()
    {
        // TODO: 返回 "Hello"。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 6：显式实现 IFrenchGreeter.Greet
    // -----------------------------------------------------------------
    // 要求：返回 "Bonjour"。
    string IFrenchGreeter.Greet()
    {
        // TODO: 返回 "Bonjour"。
        throw new System.NotImplementedException();
    }
}
