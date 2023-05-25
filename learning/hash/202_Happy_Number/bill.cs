/// <summary>
/// Leetcode 202 Happy number - Easy
/// time: 29% (bad)
/// mem: 8% (bad)
/// </summary>
public class q202 {

    public static void Run() {
        var sol = new q202();
        int n = 19;
        Console.WriteLine($"n: {n}, result: {sol.IsHappy(n)}");

        n = 2;
        Console.WriteLine($"n: {n}, result: {sol.IsHappy(n)}");

        n = 1;
        Console.WriteLine($"n: {n}, result: {sol.IsHappy(n)}");
    }

    public bool IsHappy(int n) {
        var seen = new HashSet<int>();
        // int should be enough
        int cur = n;
        while (!seen.Contains(cur)) {
            if (cur == 1) {
                return true;
            }
            seen.Add(cur);
            // Console.Write($"Before: {cur},");
            cur = cur.ToString().Select(t => (int)Math.Pow(t-'0', 2)).Sum();
            // Console.WriteLine($"After: {cur},");
        }
        // cycle detected
        return false;
    }
}
