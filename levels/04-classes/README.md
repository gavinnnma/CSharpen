# 第 4 关：类与属性

## 目标

学会写 C# 的类：**属性（property）vs C++ 的 getter/setter**、自动属性、构造函数、`this`、对象初始化器、计算属性。

## 你要做什么

打开 `Solution.cs`，把 6 个 `// TODO` 补完整（涉及 `BankAccount` 和 `Point` 两个类）。改完跑测试，全绿即过关。不要改 `Level04Tests.cs`。

## 概念（含 C++ 对照）

### 属性：C# 的招牌特性
C++ 里你会写私有字段 + `getX()/setX()`：
```cpp
class C { double balance_; public: double getBalance() const { return balance_; } };
```
C# 用**属性**把这套封装成「看起来像字段、实际是方法」：
```csharp
public double Balance { get; private set; } // 自动属性
account.Balance        // 读，像字段
```
- **自动属性** `{ get; set; }`：编译器自动生成隐藏后备字段，省去样板。
- 访问器可分别限定：`{ get; private set; }` = 外部只读、类内可写。
- 默认值：`public string Owner { get; set; } = "";`

### 构造函数
和 C++ 一样：方法名同类名、无返回类型。
```csharp
public BankAccount(string owner, double initialBalance = 0) { ... }
```

### `this`
指当前对象，语义同 C++，但成员访问用 `.` 不是 `->`：`this.Owner`。

### 对象初始化器（C++ 没有的语法糖）
创建对象的同时给属性赋值：
```csharp
var p = new Point { X = 3, Y = 4 };
```
等价于先 `new Point()` 再逐个赋值。需要可访问的 setter 和无参构造（不写构造函数时默认就有）。

### 计算属性（表达式体）
没有后备字段，每次读取即时计算：
```csharp
public bool IsEmpty => Balance == 0;
```
- **对照 C++**：相当于 `bool isEmpty() const`，但调用时**不写括号**：`account.IsEmpty`。

## 运行测试

VS Code 测试面板点本关 ▶；或在本文件夹执行 `dotnet test`。

## 卡住 / 改坏了

```bash
dotnet run --project tools -- save 04
dotnet run --project tools -- restore 04
dotnet run --project tools -- reset 04
```

## 过关提示

全绿即过关。核心心法：在 C# 里**优先用属性而不是 public 字段**——它给你封装，却保持字段一样的调用语法。
