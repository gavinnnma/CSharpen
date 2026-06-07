// ============================================================
//  第 12 关：异步编程
//  这是你要填空的文件。找到每个 // TODO，把代码补完整。
//  改完后运行测试（见本关 README）。全绿即过关。
//
//  注意：本关的方法签名「故意」没有写 async。你需要在填空时
//        给方法加上 async 关键字，并在方法体里用 await。
// ============================================================

using System;
using System.Threading.Tasks;

namespace CSharpen.Level12;

public static class Async
{
    // -----------------------------------------------------------------
    // 任务 1：第一个 async 方法
    // -----------------------------------------------------------------
    // async 方法返回 Task / Task<T>；await 会「等待」一个 Task 完成，
    // 但不会阻塞线程（线程在等待期间可以去干别的）。
    // 对照 C++：思路类似 std::async + future.get()，或协程 co_await，
    //          但 C# 的 async/await 是语言级、用起来顺滑得多。
    // 要求：把本方法改成 async，先 await Task.Delay(1)（模拟异步等待），
    //       然后返回 42。
    public static Task<int> GetFortyTwoAsync()
    {
        // TODO: 加 async；await Task.Delay(1); 然后 return 42;
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 2：带参数的 async 方法
    // -----------------------------------------------------------------
    // 要求：改成 async，await Task.Delay(1) 后返回 n * n。
    public static Task<int> SquareAsync(int n)
    {
        // TODO: async + await Task.Delay(1); return n * n;
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 3：async 方法返回计算结果
    // -----------------------------------------------------------------
    // 要求：改成 async，await Task.Delay(1) 后返回 a + b。
    public static Task<int> AddAsync(int a, int b)
    {
        // TODO: async + await Task.Delay(1); return a + b;
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 4：await 另一个 async 方法（顺序组合）
    // -----------------------------------------------------------------
    // 要求：改成 async，分别 await SquareAsync(a) 和 SquareAsync(b)，
    //       返回两者之和。
    // 提示：int sa = await SquareAsync(a); int sb = await SquareAsync(b);
    //       return sa + sb;
    public static Task<int> SumOfSquaresAsync(int a, int b)
    {
        // TODO: 顺序 await 两次 SquareAsync 并返回和。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 5：Task.WhenAll（并发等待）
    // -----------------------------------------------------------------
    // 先「启动」两个 Task（不要立刻 await），再用 Task.WhenAll 一起等，
    // 这样两个任务可以并发进行。
    // 要求：改成 async。启动 SquareAsync(a) 和 SquareAsync(b) 两个 Task，
    //       用 await Task.WhenAll(...) 等它们都完成，返回两个结果之和。
    // 提示：
    //   var ta = SquareAsync(a);
    //   var tb = SquareAsync(b);
    //   await Task.WhenAll(ta, tb);
    //   return ta.Result + tb.Result;
    public static Task<int> ParallelSumAsync(int a, int b)
    {
        // TODO: 用 Task.WhenAll 并发等待两个平方，返回和。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 6：async 中的异常处理
    // -----------------------------------------------------------------
    // async 方法里照样能用 try/catch；await 处抛出的异常会在 catch 捕获。
    // 要求：改成 async。在 try 里 await Task.Delay(1) 后返回 a / b；
    //       若除零（DivideByZeroException），catch 后返回 -1。
    public static Task<int> SafeDivideAsync(int a, int b)
    {
        // TODO: async + try { await Task.Delay(1); return a / b; }
        //       catch (DivideByZeroException) { return -1; }
        throw new System.NotImplementedException();
    }
}
