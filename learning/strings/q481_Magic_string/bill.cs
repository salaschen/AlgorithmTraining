/// <summary>
/// 481 - Medium 
/// time: 20%
/// mem: 20%
/// Note: 
///     1) pass at 5th try.
///     2) use stringbuilder is much faster.
///
/// </summary>

public class q481
{
    public static void Run()
    {
        var sol = new q481();
        int n = 6;
        Console.WriteLine($"{sol.MagicalString(n)}, 3");

        n = 1; 
        Console.WriteLine($"{sol.MagicalString(n)}, 1");

        n = 5; 
        Console.WriteLine($"{sol.MagicalString(n)}, 3");

        var start = DateTime.Now;
        n = 99998; 
        Console.WriteLine($"{sol.MagicalString(n)}, 3");

        n = 99999; 
        Console.WriteLine($"{sol.MagicalString(n)}, 3");

        n = 100000; 
        Console.WriteLine($"{sol.MagicalString(n)}, 3");

        var end = DateTime.Now;
        Console.WriteLine($"{end - start} seconds"); 
    }

    public q481()
    {
        s = "122";
        ptr = 2;
    }

    string s;
    int ptr;

    public int helper(int n)
    {
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '1')
            {
                result++;
            }
        }
        return result; 
    }

    public int MagicalString(int n)
    {
        // string s = "122";
        // int slen = 3;
        if (s.Length > n)
        {
            // just count the ones for up to n
            return helper(n);
        }

        // keep building the s until it's no shorter than n
        string cur = s[s.Length - 1].ToString();
        while (s.Length < n)
        {
            int strLen = s[ptr] - '0';
            string next = "1";
            if (cur == "1")
            {
                next = "2";
            }
            switch (strLen)
            {
                case 1:
                    s = s + next;
                    break;
                case 2:
                    s = s + next + next;
                    break;
                default:
                    break;
            }

            cur = next;
            ptr++;
        }

        return helper(n); 
    }
}
