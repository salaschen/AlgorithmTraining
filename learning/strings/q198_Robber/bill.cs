internal class q198
{
    public static void Run()
    {
        var sol = new q198();
        var nums = new int[] {1,2,3,1  };
        Console.WriteLine($"{sol.Rob(nums)}, 4");

        nums = new int[] {2,7,9,3,1 };
        Console.WriteLine($"{sol.Rob(nums)}, 12");

        nums = new int[] {2};
        Console.WriteLine($"{sol.Rob(nums)}, 2");

        nums = new int[] {2,7};
        Console.WriteLine($"{sol.Rob(nums)}, 7");

        nums = new int[] {8,7};
        Console.WriteLine($"{sol.Rob(nums)}, 8");

        nums = new int[] {2,7,1};
        Console.WriteLine($"{sol.Rob(nums)}, 7");

        nums = new int[] {2,7,10};
        Console.WriteLine($"{sol.Rob(nums)}, 12");
    }

    /// <summary>
    /// Dynamic Programming
    /// dp[i][0]: The max rob value starting from house i but not included i
    /// dp[i][1]: The max rob value starting from house i and included i
    /// 
    /// time: 67%
    /// mem : 58%
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int Rob(int[] nums)
    {
        int nlen = nums.Length;
        if (nlen <= 0)
        {
            return 0;
        }

        // List<int>[] dp = new List<int>[nlen+1];
        int[][] dp = new int[nlen][];
        for (int i = 0; i < nlen; i++)
        {
            dp[i] = new int[2] { 0, 0 };
        }

        // initialize the last value
        dp[nlen - 1][0] = 0;
        dp[nlen - 1][1] = nums[nlen-1];

        for (int i = nlen - 2; i >= 0; i--)
        {
            // dp[i][0] = max(dp[i + 1][0], dp[i + 1][1]);
            dp[i][0] = (dp[i + 1][0] > dp[i + 1][1]) ? dp[i + 1][0] : dp[i + 1][1];
            dp[i][1] = nums[i] + dp[i + 1][0];
        }

        int result = dp[0][0] > dp[0][1] ? dp[0][0] : dp[0][1];
        return result; 
    }

    public int max(int a, int b) {
        return (a < b) ? b : a;
    }
}
