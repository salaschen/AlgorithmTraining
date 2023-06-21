using System.Text;

internal class q459
{
    /// <summary>
    /// brute-force
    /// time: 34%
    /// mem: 21%
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public bool RepeatedSubstringPattern(string s)
    {
        int slen = s.Length;
        for (int i = 1; i < s.Length / 2 + 1; i++)
        {
            string pattern = s.Substring(0, i);
            if (slen % i != 0)
            {
                continue;
            }

            int repeats = slen / i;
            string construct = buildString(pattern, repeats);
            if (construct.CompareTo(s) == 0)
            {
                return true;
            }
        }
        return false; 
    }

    private string buildString(string pattern, int repeats)
    {
        StringBuilder builder = new StringBuilder(pattern);
        for (int i = 1; i < repeats; i++)
        {
            builder.Append(pattern);
        }
        return builder.ToString();
    }
}
