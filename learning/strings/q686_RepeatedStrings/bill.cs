using System.Text;

// time: 100%
// mem: 80%
internal class q686
{
    public static void Run()
    {
        var sol = new q686();
        var a = "abcd";
        var b = "cdabcdab";
        Console.WriteLine(sol.RepeatedStringMatch(a, b)); // 3

        a = "a";
        b = "aa";
        Console.WriteLine(sol.RepeatedStringMatch(a, b)); // 2

        a = "a";
        b = "aac";
        Console.WriteLine(sol.RepeatedStringMatch(a, b)); // -1

        a = "abcd";
        b = "ab";
        Console.WriteLine($"{sol.RepeatedStringMatch(a,b)}, 1");

        a = "abcd";
        b = "abcd";
        Console.WriteLine($"{sol.RepeatedStringMatch(a,b)}, 1");

        a = "abcd";
        b = "abcda";
        Console.WriteLine($"{sol.RepeatedStringMatch(a,b)}, 2");

        a = "abcd";
        b = "bcda";
        Console.WriteLine($"{sol.RepeatedStringMatch(a,b)}, 2");

        a = "abcd";
        b = "bcdacba";
        Console.WriteLine($"{sol.RepeatedStringMatch(a,b)}, -1");
    }

    // brute-force
    // 1) calculate the repeated times (ra) require to construct two b's
    // 2) construct a long string a by ra times. (la)
    // 3) calcuates the index of b in (la)
    // 4) calculate minimum repeated times.
    public int RepeatedStringMatch(string a, string b)
    {
        // step 1)
        int[] countA = countLetters(a);
        int[] count2B = countLetters(b + b);
        int repeat = countRepeatTimes(countA, count2B);
        if (repeat < 1)
        {
            return -1;
        }

        // step 2)
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < repeat; i++)
        {
            builder.Append(a);
        }
        string longA = builder.ToString();

        // step 3)
        int index = longA.IndexOf(b);
        if (index == -1)
        {
            return -1;
        }

        // step 4)
        int lastIndex = index + b.Length-1;
        int minLength = lastIndex + 1;
        int minRepeat = (int)Math.Ceiling(minLength * 1.0 / a.Length);

        return minRepeat;
    }

    public int countRepeatTimes(int[] countA, int[] countB)
    {
        int result = 0;
        for (int i = 0; i < 26; i++)
        {
            // B has a character that A doesn't, so B can never be A's substring.
            if (countB[i] != 0 && countA[i] == 0)
            {
                return -1;
            }

            // a character both missing in A and B, it doesn't affect the final result.
            if (countB[i] == 0 && countA[i] == 0)
            {
                continue;
            }

            int temp = (int)(Math.Ceiling(countB[i] * 1.0 / countA[i]));
            result = (result < temp || result == 0) ? temp : result;
        }
        return result;
    }

    public int[] countLetters(string s)
    {
        int[] result = new int[26];
        for (int i = 0; i < s.Length; i++)
            result[s[i] - 'a']++;
        return result;
    }
}
