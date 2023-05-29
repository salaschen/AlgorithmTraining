/// <summary>
/// Leetcode 454 FourSum II - Medium 
/// time: 32%
/// mem: 10%
/// </summary>
public class q454
{
    public static void Run()
    {
        var sol = new q454();
        int[] nums1 = new int[2] { 1, 2 };
        int[] nums2 = new int[2] { -2, -1 };
        int[] nums3 = new int[2] { -1, 2 };
        int[] nums4 = new int[2] { 0, 2 };
        Console.WriteLine(string.Format("{0}, {1}",
            sol.FourSumCount(nums1, nums2, nums3, nums4), 2));

        nums1 = new int[] { 0 };
        nums2 = new int[] { 0 };
        nums3 = new int[] { 0 };
        nums4 = new int[] { 0 };
        Console.WriteLine(string.Format("{0}, {1}",
            sol.FourSumCount(nums1, nums2, nums3, nums4), 1));
    }

    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        int zero1;
        int zero2;
        var t1 = getTwoMem(nums1, nums2, out zero1);
        var t2 = getTwoMem(nums3, nums4, out zero2);
        int result = zero1 * zero2;
        var pos1 = t1.Item1;
        var neg1 = t1.Item2;
        var pos2 = t2.Item1;
        var neg2 = t2.Item2;

        foreach (var k in pos1.Keys)
        {
            if (neg2.ContainsKey(-k))
            {
                result += (pos1[k] * neg2[-k]);
            }
        }

        foreach (var k in neg1.Keys)
        {
            if (pos2.ContainsKey(-k))
            {
                result += neg1[k] * pos2[-k];
            }
        }
        return result;
    }

    private Tuple<Dictionary<int, int>, Dictionary<int, int>> getTwoMem(int[] nums1, int[] nums2, out int numZeros)
    {
        var pos = new Dictionary<int, int>();
        var neg = new Dictionary<int, int>();
        numZeros = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            for (int j = 0; j < nums2.Length; j++)
            {
                int temp = nums1[i] + nums2[j];
                if (temp == 0)
                {
                    numZeros++;
                } else if (temp > 0)
                {
                    if (pos.ContainsKey(temp))
                    {
                        pos[temp]++;
                    } else
                    {
                        pos[temp] = 1;
                    }
                } else
                {
                    if (neg.ContainsKey(temp))
                    {
                        neg[temp]++;
                    } else
                    {
                        neg[temp] = 1;
                    }
                }
            }
        }
        return Tuple.Create(pos, neg);
    }

    public int FourSumCountOld(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        var mem1 = getMem(nums1, nums2);
        var mem2 = getMem(nums3, nums4);
        int result = 0;
        foreach (var k in mem1.Keys)
        {
            if (mem2.ContainsKey(-k))
            {
                result += (mem1[k] * mem2[-k]);
            }
        }
        return result;
    }

    private Dictionary<long, int> getMem(int[] nums1, int[] nums2)
    {
        var mem1 = new Dictionary<long, int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            for (int j = 0; j < nums2.Length; j++)
            {
                long temp = nums1[i] + nums2[j];
                if (mem1.ContainsKey(temp))
                {
                    mem1[temp]++;
                } else
                {
                    mem1[temp] = 1;
                }
            }
        }
        return mem1;
    }
}
