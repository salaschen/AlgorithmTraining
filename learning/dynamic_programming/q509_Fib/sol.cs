using System.Globalization;

namespace leetcode.Problems;
public class q509 {
    public static void Run() {
        var sol = new q509();
        for (int i = 0; i <= 30; i++) {
            Console.WriteLine($"{i}: {sol.Fib(i)}");
        }
    }

    public int Fib(int n) {
        IEnumerable<int> gen(int num) {
            int prev = 0;
            int cur = 1;

            for (int i = 2; i <= num; i++) {
                int next = (prev + cur);
                yield return next;
                prev = cur;
                cur = next;
            }
        }

        if (n == 0) return 0;
        if (n == 1) return 1;

        var lst = gen(n);
        int result = 0;
        foreach (int num in lst) {
            result = num;
        }

        return result;
    }
}
