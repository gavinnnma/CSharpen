// ============================================================
//  第 11 关：委托与 Lambda
//  这是你要填空的文件。找到每个 // TODO，把代码补完整。
//  改完后运行测试（见本关 README）。全绿即过关。
// ============================================================

using System;

namespace CSharpen.Level11;

public static class Delegates
{
    // -----------------------------------------------------------------
    // 任务 1：Func —— 把「函数」当参数传
    // -----------------------------------------------------------------
    // Func<int,int> 表示「接收一个 int、返回一个 int」的函数。
    // 对照 C++：相当于 std::function<int(int)>，或函数指针 int(*)(int)。
    // 要求：调用 f，把 x 传进去并返回结果。
    public static int Apply(Func<int, int> f, int x)
    {
        // TODO: 返回 f(x)。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 2：返回一个 Lambda（闭包）
    // -----------------------------------------------------------------
    // Lambda 能「捕获」外层变量，形成闭包。
    // 对照 C++：相当于带捕获的 lambda [n](int x){ return x + n; }，
    //          但 C# 的捕获是自动按引用语义捕获，且生命周期由 GC 管理。
    // 要求：返回一个函数，它接收 x 并返回 x + n。
    // 提示：return x => x + n;
    public static Func<int, int> MakeAdder(int n)
    {
        // TODO: 返回一个把入参加上 n 的 Lambda。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 3：Action —— 没有返回值的委托
    // -----------------------------------------------------------------
    // Action 表示「无参数、无返回值」的函数。
    // 要求：调用 action 共 n 次。
    public static void RunTimes(int n, Action action)
    {
        // TODO: 循环调用 action() 共 n 次。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 4：Predicate —— 返回 bool 的委托
    // -----------------------------------------------------------------
    // Predicate<T> 表示「接收一个 T、返回 bool」的判断函数。
    // 要求：返回 numbers 中「使 predicate 返回 true」的元素个数。
    public static int CountMatching(int[] numbers, Predicate<int> predicate)
    {
        // TODO: 统计满足 predicate 的元素数量。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 5：自定义委托类型
    // -----------------------------------------------------------------
    // 除了内置的 Func/Action，也能用 delegate 关键字定义自己的委托类型。
    // 下面这行声明了一个「接收两个 int、返回 int」的委托类型 BinaryOp。
    public delegate int BinaryOp(int a, int b);

    // 要求：用传入的 op 计算 a、b 的结果并返回。
    public static int Combine(int a, int b, BinaryOp op)
    {
        // TODO: 返回 op(a, b)。
        throw new System.NotImplementedException();
    }
}

// =====================================================================
//  任务 6：事件（event）
// =====================================================================
// 事件是「多播委托」的封装：外部只能 += 订阅 / -= 取消，不能直接触发或清空，
// 触发只能在声明它的类内部进行。
// 对照 C++：类似「观察者/回调列表」。C++ 没有内建 event，通常自己维护一个
//          std::vector<std::function<...>> 回调列表；C# 把这套做进了语言。
public class Button
{
    // 事件类型用 Action（无参无返回）。? 表示可能没有任何订阅者。
    public event Action? Clicked;

    // -----------------------------------------------------------------
    // 要求：触发 Clicked 事件，通知所有订阅者。
    //       若当前没有订阅者，也不能报错（NullReferenceException）。
    // 提示：Clicked?.Invoke();   // ?. 在没有订阅者(null)时安全跳过
    // -----------------------------------------------------------------
    public void Click()
    {
        // TODO: 安全地触发 Clicked 事件。
        throw new System.NotImplementedException();
    }
}
