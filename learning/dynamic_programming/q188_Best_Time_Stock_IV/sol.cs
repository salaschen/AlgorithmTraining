namespace leetcode.Problems; 
internal class q188 {
    public static void Run() {
        new q188().Test();
    }

    private void Test() {
        int k;
        int[] prices;
        int result;
        // case 1:
        k = 2;
        prices = new int[] { 2, 4, 1 };
        result = MaxProfit(k, prices);
        Console.WriteLine($"{result}, expect 2");

        // case 2:
        k = 2;
        prices = new int[] { 3,2,6,5,0,3 };
        result = MaxProfit(k, prices);
        Console.WriteLine($"{result}, expect 7");
    }

    // dynamic programming
    public int MaxProfit(int k, int[] prices) {
        // step 0: setup 
        int n = prices.Length;
        // for ith day:
        // dp[i, 2*p] is when not holding any stock for the (p+1)th time.
        // dp[i, 2*p+1] is when holding stock for the (p+1)th time.
        // e.g., dp[2, 0] is not holding stock for the 1st time. 
        // dp[3, 3] is holding stock for the 2nd time. 
        // dp[10, 2*k+1] is has held stocks for kth time and sold for kth time.
        int[,] dp = new int[n, 2 * k+1];

        // step 1: initialize day 0
        dp[0, 0] = 0;
        dp[0, 1] = -prices[0];
        for (int i = 2; i <= 2 * k; i++) {
            dp[0, i] = int.MinValue + 100000;
        }

        // step 2: loop through the rest of the days
        for (int i = 1; i < n; i++) {
            // Never bought any stock, cash position remains the same.
            dp[i, 0] = dp[i - 1, 0];

            // All the day of holding stocks
            for (int j = 1; j < 2 * k + 1; j += 2) {
                // day i holds stock for the jth time, either:
                // 1) day i-1 holds stock for the j/2th time, or
                // 2) day i-1 doen't hold stock for the j/2th time, and we buy on day i
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - 1] - prices[i]);
            }

            // All the day of *not* holding stocks
            for (int j = 2; j < 2 * k + 1; j += 2) {
                // day i doesn't hold stock for the j/2th time, either:
                // day i-1 doesn't hold stock for the j/2th time, or
                // day i-1 holds stock for the (j-1)/2 th time, and we sell on day i
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - 1] + prices[i]);
            }
        }

        // step 3: examine all the cash positions on day n.
        int result = dp[n - 1, 0];
        for (int i = 1; i < 2 * k + 1; i++) {
            result = Math.Max(result, dp[n - 1, i]);
        }
        return result;
    }
}
