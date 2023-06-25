internal class q27
{
    public static void Run()
    {
        var sol = new q27();
        int[] nums = new int[] { 3, 2, 2, 3 };
        int val = 3;
        int result = sol.RemoveElement(nums,val);
        Console.WriteLine(result);
        Console.WriteLine(string.Join(',', nums.Select(n => n.ToString())));

        nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
        val = 2;
        result = sol.RemoveElement(nums,val);
        Console.WriteLine(result);
        Console.WriteLine(string.Join(',', nums.Select(n => n.ToString())));
    }

    /// <summary>
    /// time: 71%
    /// mem : 81%
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public int RemoveElement(int[] nums, int val)
    {
        int insertPtr = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[insertPtr] = nums[i];
                insertPtr++;
            }
        }
        return insertPtr;
    }
}
