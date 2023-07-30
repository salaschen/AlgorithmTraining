/// <summary>
/// 347 Top K Frequent Elements.
/// Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
/// Date: 30/Jul/2023
/// time:  98%
/// mem:   91%
/// </summary>
internal class q347 {
    public static void Run() {
        var sol = new q347();
        int[] nums = new int[] { 1, 1, 1, 2, 2, 3 };
        int k = 2;
        Console.WriteLine(sol.TopKFrequent(nums, k).ToList().ToPrintString());

        nums = new int[] { 1 };
        k = 1;
        Console.WriteLine(sol.TopKFrequent(nums, k).ToList().ToPrintString());
    }

    public int[] TopKFrequent(int[] nums, int k) {
        var minHeap = new MinHeap<int>();
        var count = new Dictionary<int, int>();

        // go through the list and count
        for (int i = 0; i < nums.Length; i++) {
            int cur = nums[i];
            if (count.ContainsKey(cur) == false) {
                count[cur] = 0;
            }
            count[cur]++;
        }

        // now add the mean heap
        foreach (var key in count.Keys) {
            HeapNode<int> node = new HeapNode<int>() { keyValue = key, weightValue = count[key] };
            minHeap.Add(node);
            while (minHeap.Size > k) {
                minHeap.Pop();
            }

            // debug
            // Console.WriteLine($"count[{key}]={count[key]}");
        }

        // debug
        // minHeap.PrintHeap();

        int[] result = new int[k];
        int j = 0;
        while (minHeap.Size > 0) {
            int value = minHeap.Pop();
            result[j++] = value;
        }

        return result;
    }
}

public struct HeapNode<T> {
    public T keyValue;
    public int weightValue;
}

public class MinHeap<T> {
    private List<HeapNode<T>> heap;
    public int Size { get => heap.Count; }

    public void PrintHeap() {
        for (int i = 0; i < Size; i++) {
            Console.WriteLine($"heap {i}: {heap[i].keyValue}, {heap[i].weightValue}");
        }
    }

    public MinHeap() {
        heap = new List<HeapNode<T>>();
    }

    public T Pop() {
        // swap 0 with list.count-1
        // heapify down 0
        // then return the result.
        T result = heap[0].keyValue;
        swap(0, heap.Count - 1);
        heap.RemoveAt(heap.Count - 1);
        heapifyDown(0);
        return result;
    }

    public void Add(HeapNode<T> node) {
        heap.Add(node);
        heapifyUp(heap.Count - 1);
    }

    // just peek
    public T Top() {
        return heap.First().keyValue;
    }

    private void swap(int indexA, int indexB) {
        var nodeB = heap[indexB];
        var temp = heap[indexA];
        heap[indexA] = nodeB;
        heap[indexB] = temp;
    }

    private void heapifyUp(int index) {
        while (index > 0 && index < heap.Count) {
            int par = parent(index);
            if (heap[index].weightValue < heap[par].weightValue) {
                swap(index, par);
                index = par;
            } else {
                return;
            }
        }
    }

    private void heapifyDown(int index) {
        while (index < heap.Count) {
            int l = left(index);
            int r = right(index);

            // if index is leaf, return
            if (l >= heap.Count) {
                return;
            } else if (r >= heap.Count) {
                if (heap[l].weightValue < heap[index].weightValue) {
                    // swap l and index
                    swap(l, index);
                    index = l;
                } else {
                    // index is in the right place
                    return;
                }
            } else {
                int ex = heap[l].weightValue < heap[r].weightValue ? l : r;
                if (heap[index].weightValue > heap[ex].weightValue) {
                    // swap index and ex
                    swap(index, ex);
                    index = ex;
                } else {
                    return;
                }
            }
        }
    }

    private int parent(int index) {
        return (index - 1) / 2;
    }

    private int left(int index) {
        return 2 * index + 1;
    }

    private int right(int index) {
        return 2 * index + 2;
    }
}
