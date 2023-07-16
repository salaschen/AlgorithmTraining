using System.Drawing;
using System.Runtime.Intrinsics.X86;
/// <summary>
/// Implement Stack Using Queues
/// Note:
///     Use array to implement.
/// time: 47%
/// mem : 92%
/// </summary>
internal class q225 {
    public static void Run() {
        var stack = new MyStack225();
        stack.Push(1);
        stack.Push(2);
        // stack.PrintStack(); // debug
        Console.WriteLine(stack.Top());
        Console.WriteLine(stack.Pop());
        // stack.PrintStack(); // debug
        Console.WriteLine(stack.Empty());
    }
}


public class MyStack225 {
    private int bufSize = 100; // should be enough
    private int size;
    private int[] buf;
    public MyStack225() {
        buf = new int[bufSize];
        size = 0;
    }

    public void Push(int x) {
        buf[size++] = x;
    }

    public int Top() {
        return buf[size-1];
    }

    public int Pop() {
        size -= 1;
        return buf[size];
    }

    public bool Empty() {
        return size == 0;
    }

    // for debug
    public void PrintStack() {
        Console.WriteLine($"[{string.Join(',', buf.Select(n => n.ToString()))}] )");
    }
}
