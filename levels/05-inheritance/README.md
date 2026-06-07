# 第 5 关：继承与多态

## 目标

掌握 C# 的继承体系：`abstract` / `virtual` / `override` / `base`，以及**多态**（用基类引用调用派生类实现）。

## 你要做什么

打开 `Solution.cs`，把 6 个 `// TODO` 补完整（涉及 `Shape`/`Circle`/`Rectangle`/`Square`）。改完跑测试，全绿即过关。不要改 `Level05Tests.cs`。

## 概念（含 C++ 对照）

### abstract / virtual / override
| C# | 含义 | C++ 对照 |
|----|------|---------|
| `abstract double Area();` | 抽象方法，无实现，派生类**必须**重写 | 纯虚函数 `virtual double area() = 0;` |
| `virtual string Name()` | 虚方法，有默认实现，派生类**可**重写 | `virtual` 函数 |
| `override double Area()` | 重写基类方法，**必须**写 `override` | C++ 的 `override` 是可选的；C# 强制 |

含抽象方法的类必须声明为 `abstract`，不能直接 `new`。

### base：调用父类版本
```csharp
public override string Name() => $"square({base.Name()})";
```
- **对照 C++**：相当于 `Rectangle::Name()`。

### 调用基类构造函数
```csharp
public Square(double side) : base(side, side) { }
```
- **对照 C++**：相当于初始化列表 `Square(double s) : Rectangle(s, s) {}`。

### 多态（本关重点）
用基类类型的引用指向派生对象，调用虚方法时按**运行时真实类型**分派：
```csharp
Shape s = new Circle(1);
s.Name();   // "circle"，不是 "shape"
s.Area();   // 调用 Circle.Area
```
`TotalArea(Shape[])` 就靠这一点：同一段 `shape.Area()` 代码，对不同形状执行不同实现。

> 补充：`sealed` 可以「封印」类（禁止再被继承）或封印某个 `override`（禁止子类再重写），对照 C++11 的 `final`。本关不强制用到，了解即可。

## 运行测试

VS Code 测试面板点本关 ▶；或在本文件夹执行 `dotnet test`。

## 卡住 / 改坏了

```bash
dotnet run --project tools -- save 05
dotnet run --project tools -- restore 05
dotnet run --project tools -- reset 05
```

## 过关提示

全绿即过关。体会多态那条测试：`Shape s = new Circle(1); s.Name()` 得到 `"circle"`——这就是虚函数分派，和 C++ 一脉相承，只是关键字更严格。
