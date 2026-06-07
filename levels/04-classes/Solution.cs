// ============================================================
//  第 4 关：类与属性
//  这是你要填空的文件。找到每个 // TODO，把代码补完整。
//  改完后运行测试（见本关 README）。全绿即过关。
// ============================================================

namespace CSharpen.Level04;

// =====================================================================
//  BankAccount：练习构造函数、属性、this、方法。
//  下面两个属性已经替你声明好了（自动属性），你需要在构造函数和
//  方法里正确地使用 / 修改它们。
// =====================================================================
public class BankAccount
{
    // 自动属性：编译器自动生成隐藏的后备字段。
    // Owner 外部可读可写；Balance 只能外部读、内部（本类内）写。
    // 对照 C++：你以前要写 private 字段 + getOwner()/setOwner()；C# 一行搞定。
    public string Owner { get; set; } = "";
    public double Balance { get; private set; }

    // -----------------------------------------------------------------
    // 任务 1：构造函数
    // -----------------------------------------------------------------
    // 对照 C++：构造函数名同类名、无返回类型——这点和 C++ 一样。
    // this.Owner 里的 this 指当前对象（和 C++ 的 this 同义，但用 . 不用 ->）。
    // 要求：把参数 owner 存入 Owner 属性，把 initialBalance 存入 Balance。
    public BankAccount(string owner, double initialBalance = 0)
    {
        // TODO: 用 this.Owner / Owner 和 Balance 完成初始化。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 2：存款
    // -----------------------------------------------------------------
    // 要求：把 amount 加到 Balance 上。
    public void Deposit(double amount)
    {
        // TODO: Balance += amount;
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 3：取款（带条件，返回是否成功）
    // -----------------------------------------------------------------
    // 要求：如果 amount <= Balance，则扣款并返回 true；
    //       否则余额不变，返回 false。
    public bool Withdraw(double amount)
    {
        // TODO: 余额够就扣款返回 true，否则不动返回 false。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 4：只读计算属性
    // -----------------------------------------------------------------
    // 计算属性没有后备字段，每次读取时即时算出。语法用 => 表达式体。
    // 对照 C++：相当于一个 const 成员函数 bool isEmpty() const，但调用时
    //          不写括号：account.IsEmpty（像访问字段一样）。
    // 要求：当 Balance 等于 0 时返回 true，否则 false。
    public bool IsEmpty => throw new System.NotImplementedException();
    // TODO: 把上面一行改成： public bool IsEmpty => Balance == 0;
}

// =====================================================================
//  Point：练习自动属性、对象初始化器、返回新对象。
// =====================================================================
public class Point
{
    // 自动属性（已声明好）。测试会用「对象初始化器」来创建：
    //   var p = new Point { X = 3, Y = 4 };
    public double X { get; set; }
    public double Y { get; set; }

    // -----------------------------------------------------------------
    // 任务 5：实例方法 + 用属性计算
    // -----------------------------------------------------------------
    // 要求：返回该点到原点 (0,0) 的距离 = sqrt(X*X + Y*Y)。
    // 提示：System.Math.Sqrt(...)。
    public double DistanceFromOrigin()
    {
        // TODO: 返回到原点的距离。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 6：返回一个新对象
    // -----------------------------------------------------------------
    // 要求：返回一个「平移」后的新 Point（X+dx, Y+dy），不修改当前对象。
    // 提示：return new Point { X = ..., Y = ... };
    public Point Translate(double dx, double dy)
    {
        // TODO: 返回平移后的新 Point。
        throw new System.NotImplementedException();
    }
}
