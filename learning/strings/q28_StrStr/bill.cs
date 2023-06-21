/// <summary>
/// Leetcode 28 Find the index of the First Occurrence in a String - Easy
/// Note: Implementing KMP
/// </summary>
public class q28
{
    public static void Run()
    {
        var sol = new q28();
        var haystack = "aabaabaafa";
        var needle = "aabaaf";
        Console.WriteLine(sol.StrStr(haystack, needle));
    }
    public int StrStr(string haystack, string needle)
    {
        int[] next = computeNextArray(needle);
        int j = 0;
        for (int i = 0; i < haystack.Length; i++)
        {
            while (j > 0 && haystack[i] != needle[j])
            {
                j = next[j - 1];
            }
            if (haystack[i] == needle[j])
            {
                j++;
            }
            if (j == needle.Length)
            {
                return i - needle.Length + 1;
            }
        }
        return -1;
    }

    public int[] computeNextArray(string needle)
    {
        int length = needle.Length;
        int[] next = new int[length];
        next[0] = 0;
        int tail = 0;
        for (int i = 1; i < length; i++)
        {
            while (needle[tail] != needle[i] && tail > 0)
            {
                tail = next[tail-1];
            }

            if (needle[tail] == needle[i])
            {
                tail++;
            }
            next[i] = tail;
        }
        return next;
    }
}
