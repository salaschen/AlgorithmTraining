/// <summary>
/// Using Deque to solve the Leetcode 239. 
/// time: 99.44%
/// mem : 31.35%
/// </summary>
public class q239_v2 {
    public static void Run() {
        var sol = new q239_v2();
        int[] nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;
        Console.WriteLine(sol.MaxSlidingWindow(nums, k).ToList().ToPrintString());

        nums = new int[] { 1 };
        k = 1;
        Console.WriteLine(sol.MaxSlidingWindow(nums, k).ToList().ToPrintString());

        nums = new int[] { -5769, -7887, -5709, 4600, -7919, 9807, 1303, -2644, 1144, -6410, -7159, -2041, 9059, -663, 4612, -257, 2870, -6646, 8161, 3380, 6823, 1871, -4030, -1758, 4834, -5317, 6218, -4105, 6869, 8595, 8718, -4141, -3893, -4259, -3440, -5426, 9766, -5396, -7824, -3941, 4600, -1485, -1486, -4530, -1636, -2088, -5295, -5383, 5786, -9489, 3180, -4575, -7043, -2153, 1123, 1750, -1347, -4299, -4401, -7772, 5872, 6144, -4953, -9934, 8507, 951, -8828, -5942, -3499, -174, 7629, 5877, 3338, 8899, 4223, -8068, 3775, 7954, 8740, 4567, 6280, -7687, -4811, -8094, 2209, -4476, -8328, 2385, -2156, 7028, -3864, 7272, -1199, -1397, 1581, -9635, 9087, -6262, -3061, -6083, -2825, -8574, 5534, 4006, -2691, 6699, 7558, -453, 3492, 3416, 2218, 7537, 8854, -3321, -5489, -945, 1302, -7176, -9201, -9588, -140, 1369, 3322, -7320, -8426, -8446, -2475, 8243, -3324, 8993, 8315, 2863, -7580, -7949, 4400 };
        k = 6;
        Console.WriteLine(sol.MaxSlidingWindow(nums, k).ToList().ToPrintString());

        nums = new int[] { 7954, 8740, 4567, 6280, -7687, -4811, -8094, 2209, -4476 };
        k = 6;
        Console.WriteLine(sol.MaxSlidingWindow(nums, k).ToList().ToPrintString());
    }

    public int[] MaxSlidingWindow(int[] nums, int k) {
        var queue = new Deque();
        int windowSize = nums.Length - k + 1;
        var result = new int[windowSize];

        // add the first k elements.
        for (int i = 0; i < k; i++) {
            queue.Push(nums[i]);
        }
        int cur = 0;
        result[cur++] = queue.PeekTop();

        // now slide the window to the right and maintain the deque.
        for (int i = k; i < nums.Length; i++) {
            int toRemove = nums[i - k];
            int toAdd = nums[i];
            queue.Pop(toRemove);
            queue.Push(toAdd);
            result[cur++] = queue.PeekTop();
        }
        return result;
    }
}

// Maintain a deque where the elements are sorted in decrease order.
// So that the first element is the largest, the last element is the smallest.
// The entry is at the end of the queue, exit is at the front of the queue.
public class Deque {
    private readonly LinkedList<int> queue;

    public Deque() {
        queue = new LinkedList<int>();
    }

    public void Pop(int val) {
        // only remove when the exit element is the target.
        if (queue.First.Value == val) {
            queue.RemoveFirst();
        }
    }

    /// <summary>
    /// Push a new element into the queue.
    /// 
    /// </summary>
    /// <param name="val"></param>
    public void Push(int val) {
        // keep poping the queue until the entry element is no smaller than the current pushing element.
        while (queue.Count > 0 && queue.Last.Value < val) {
            queue.RemoveLast();
        }
        queue.AddLast(val);
    }

    public int PeekTop() {
        if (queue.Count == 0) {
            throw new ArgumentOutOfRangeException();
        }

        return queue.First.Value;
    }
}
