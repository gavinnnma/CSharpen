// ============================================================
//  第 10 关：异常处理
//  这是你要填空的文件。找到每个 // TODO，把代码补完整。
//  改完后运行测试（见本关 README）。全绿即过关。
// ============================================================

using System;

namespace CSharpen.Level10;

public static class Exceptions
{
    // -----------------------------------------------------------------
    // 任务 1：try / catch
    // -----------------------------------------------------------------
    // 整数除以 0 会抛 DivideByZeroException。
    // 对照 C++：C++ 也有 try/catch，但整数除零是未定义行为、通常不抛异常；
    //          C# 则明确抛出可捕获的异常。
    // 要求：返回 a / b；若 b 为 0（触发 DivideByZeroException），捕获并返回 0。
    public static int SafeDivide(int a, int b)
    {
        // TODO: 用 try/catch 包住 a / b，捕获 DivideByZeroException 返回 0。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 2：捕获特定异常类型
    // -----------------------------------------------------------------
    // int.Parse 解析失败会抛 FormatException。
    // 要求：尝试把 s 解析成 int 返回；失败则返回 fallback。
    // 提示：try { return int.Parse(s); } catch (FormatException) { return fallback; }
    public static int ParseOrDefault(string s, int fallback)
    {
        // TODO: 解析成功返回结果，FormatException 时返回 fallback。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 4：主动抛出（自定义）异常
    // -----------------------------------------------------------------
    // （自定义异常类型见文件底部的 InsufficientFundsException——任务 3。）
    // 要求：如果 amount > balance，抛出 InsufficientFundsException（带一段说明
    //       文字，内容自定）；否则返回扣款后的余额 balance - amount。
    public static int Withdraw(int balance, int amount)
    {
        // TODO: 余额不足就 throw new InsufficientFundsException("..."); 否则返回差额。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 5：try / catch / finally
    // -----------------------------------------------------------------
    // finally 块「无论是否发生异常都会执行」，常用于释放资源/收尾。
    // 要求：
    //   - 在 try 里返回 a / b；
    //   - 若除零，catch 后返回 -1；
    //   - 无论哪条路径，都在 finally 里把 cleanedUp 设为 true。
    public static int ExecuteWithCleanup(int a, int b, out bool cleanedUp)
    {
        // TODO: 用 try/catch/finally 实现上述逻辑（cleanedUp 在 finally 里赋值）。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 6：using 语句（自动释放资源）
    // -----------------------------------------------------------------
    // using 块结束时会自动调用对象的 Dispose()——这是 C# 版的「RAII」。
    // 对照 C++：C++ 靠析构函数在作用域结束时自动清理；C# 的 GC 不保证及时
    //          析构，所以对「需要确定性释放」的资源（文件/连接/锁）用 using。
    // 要求：用 using 语句把传入的 resource 包起来（块体可为空），
    //       使其在方法结束时被自动 Dispose。
    // 提示：using (resource) { }
    public static void CloseResource(TrackedResource resource)
    {
        // TODO: 用 using 语句让 resource 在此被自动释放。
        throw new System.NotImplementedException();
    }
}

// =====================================================================
//  任务 3：自定义异常类型
// =====================================================================
// 自定义异常 = 继承 System.Exception（或其子类）。
// 对照 C++：类似继承 std::exception，但 C# 习惯继承 Exception 并通过
//          : base(message) 把消息传给父类，之后能用 ex.Message 取出。
public class InsufficientFundsException : System.Exception
{
    // TODO（任务 3）：让这个构造函数把 message 传给父类。
    // 现在它「没有」把 message 交给父类，所以 ex.Message 取不到你传的文字。
    // 请在括号后加上 : base(message)，即：
    //   public InsufficientFundsException(string message) : base(message) { }
    public InsufficientFundsException(string message)
    {
    }
}

// =====================================================================
//  TrackedResource：一个实现了 IDisposable 的资源（已替你写好）。
//  IDisposable 只要求一个 Dispose() 方法；using 块会自动调用它。
//  任务 6 里你要用 using 来消费这个资源。
// =====================================================================
public sealed class TrackedResource : IDisposable
{
    public bool IsDisposed { get; private set; }

    public void Dispose()
    {
        IsDisposed = true;
    }
}
