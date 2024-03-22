namespace leetcode.Problems;

public class q746 {
    public static void Run() {
        var sol = new q746();
        var cost = new int[] { 10, 15, 20 };
        var result = sol.MinCostClimbingStairs(cost);
        Console.WriteLine($"{result}");

        cost = new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
        result = sol.MinCostClimbingStairs(cost);
        Console.WriteLine($"{result}");
    }

    public int MinCostClimbingStairs(int[] cost) {
        int[] dp = new int[cost.Length + 2];
        dp[0] = 0;
        dp[1] = 0;

        for (int i = 2; i <= cost.Length; i++) {
            dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
        }

        return dp[cost.Length];
    }
}
