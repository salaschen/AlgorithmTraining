internal class q232 {

    public static void Run() {
        var queue = new MyQueue();
        queue.Push(1);
        queue.Push(2);
        Console.WriteLine(queue);
        Console.WriteLine($"peek: {queue.Peek()}");
        Console.WriteLine(queue.Pop());
        Console.WriteLine(queue);
        Console.WriteLine(queue.Empty());
        Console.WriteLine(queue.Peek());
        Console.WriteLine(queue);
    }
}

/// <summary>
/// Complexity: O(1) per operation.
/// time: 96%
/// mem: 94%.
/// </summary>
public class MyQueue {
    private readonly MyStack addStack;
    private readonly MyStack takeStack;
    public override string ToString() {
        return $"addStack: {addStack.ToString()}\ntakeStack: {takeStack.ToString()}";
    }

    public MyQueue() {
        addStack = new MyStack();
        takeStack = new MyStack();
    }

    public void Push(int x) {
        addStack.Push(x);
    }

    public int Pop() {
        if (Empty()) {
            return Int32.MinValue;
        }
        if (takeStack.IsEmpty()) {
            shuffle();
        }

        return takeStack.Pop();
    }

    public int Peek() {
        if (Empty()) {
            return Int32.MinValue;
        }

        if (takeStack.IsEmpty()) {
            shuffle();
        }

        return takeStack.Peek();
    }

    public bool Empty() {
        return addStack.Size == 0 && takeStack.Size == 0;
    }

    // move all elements from add-stack to take-stack
    private void shuffle() {
        try {
            while (addStack.Size > 0) {
                takeStack.Push(addStack.Pop());
            }
        } catch (Exception ex) {
            Console.WriteLine(ex);
        }
    }
}

public class MyStack {
    private readonly List<int> container;

    public MyStack() {
        container = new List<int>();
    }

    public void Push(int x) {
        container.Add(x);
    }

    public int Pop() {
        if (IsEmpty()) {
            throw new ArgumentOutOfRangeException();
        }
        int result = Peek();
        container.RemoveAt(Size - 1);
        return result;
    }

    public int Peek() {
        return container[Size - 1];
    }

    private int size() {
        return container.Count;
    }

    public bool IsEmpty() {
        return Size == 0;
    }

    public int Size { get => size(); }

    public override string ToString() {
        return $"[{string.Join(',', container.Select(n => n.ToString()))}]";
    }
}
