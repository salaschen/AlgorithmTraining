/// <summary>
/// Leetcode 18 - Medium
/// time: 5%
/// mem: 5%
/// </summary>
public class q18
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        nums = nums.OrderBy(n => n).ToArray();
        var index = new Dictionary<long, IList<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (index.ContainsKey(nums[i]))
            {
                index[nums[i]].Add(i);
            } else
            {
                index[nums[i]] = new List<int>() { i };
            }
        }

        var result = new List<IList<int>>();
        var seen = new HashSet<Tuple<int, int, int, long>>();

        // brute-force loop
        for (int i = 0; i < nums.Length; i++)
        {
            int num1 = nums[i];
            for (int j = i + 1; j < nums.Length; j++)
            {
                int num2 = nums[j];
                for (int k = j + 1; k < nums.Length; k++)
                {
                    int num3 = nums[k];
                    long want = (long)target - num1 - num2 - num3;
                    var tup = Tuple.Create(num1, num2, num3, want);

                    if (!index.ContainsKey(want) || seen.Contains(tup))
                    {
                        continue;
                    }

                    var found = index[want].Where(ind => ind > k).ToArray();
                    for(int w = 0; w < 1 && w < found.Length; w++)
                    {
                        result.Add(new List<int>()
                        {
                            num1, num2, num3, (int)want
                        });
                        seen.Add(tup);
                    }
                }
            }
        }

        return result;
    }
}
