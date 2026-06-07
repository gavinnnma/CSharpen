# 第 6 关：接口

## 目标

掌握 C# 接口：定义接口、隐式实现、**显式实现**、一个类实现多个接口、以及「面向接口」的多态。

## 你要做什么

打开 `Solution.cs`，把 6 个 `// TODO` 补完整。改完跑测试，全绿即过关。不要改 `Level06Tests.cs`。

## 概念（含 C++ 对照）

### 接口是什么
接口只声明「能做什么」，没有实现、没有数据成员：
```csharp
public interface IArea { double Area(); }
public interface INamed { string Name { get; } } // 接口也能声明属性
```
- **对照 C++**：相当于一个**只含纯虚函数、没有数据成员**的抽象类。
- C# 的类是**单继承**（只能有一个基类），但可以实现**任意多个接口**——这正是 C# 替代 C++ 多重继承的方式。

### 隐式实现 vs 显式实现
**隐式实现**：写成普通 `public` 方法，签名对上即可，既能通过类实例也能通过接口调用：
```csharp
public double Area() => Width * Height;
```

**显式实现**：方法名前加 `接口名.`，不写 `public`。这种成员**只能通过接口类型访问**：
```csharp
string IEnglishGreeter.Greet() => "Hello";
// 用法：
IEnglishGreeter g = new BilingualGreeter();
g.Greet();                       // OK
// new BilingualGreeter().Greet(); // 编译不过——实例上看不到这个方法
```
什么时候用显式实现？当两个接口有**同名成员**需要分别实现时（本关的 `IEnglishGreeter`/`IFrenchGreeter` 都有 `Greet()`），或想刻意隐藏接口成员时。

### 面向接口的多态
方法参数用接口类型，就能接收任何实现该接口的对象：
```csharp
public static double TotalArea(IArea[] shapes) { ... }
// Rectangle、Circle 都能塞进同一个数组
```
这和第 5 关的继承多态是同一思想的两种实现路径——**优先依赖接口（抽象）而非具体类型**。

## 运行测试

VS Code 测试面板点本关 ▶；或在本文件夹执行 `dotnet test`。

## 卡住 / 改坏了

```bash
dotnet run --project tools -- save 06
dotnet run --project tools -- restore 06
dotnet run --project tools -- reset 06
```

## 过关提示

全绿即过关。重点对比：`abstract class`（第 5 关，可带实现和字段、单继承）vs `interface`（本关，纯契约、可多实现）。C# 工程里接口用得极广（依赖注入、单元测试 mock 都靠它）。
