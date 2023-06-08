/**
 * 541 Reverse String II - Easy
 * 
 * time: 43%
 * mem: 12%
 */

using System.Text;

public class q541
{
    public static void Run()
    {
        var sol = new q541();
        string s =  "abcdefg";
        int k = 2;
        Console.WriteLine(sol.ReverseStr(s, k));

        s = "abcd";
        k = 2;
        Console.WriteLine(sol.ReverseStr(s, k));

        s = "abcdef";
        k = 3;
        Console.WriteLine(sol.ReverseStr(s, k));

        s = "abcdefg";
        k = 3;
        Console.WriteLine(sol.ReverseStr(s, k));
    }

    public string ReverseStr(string s, int k)
    {
        string result = "";
        int ptr = 0;
        while (ptr < s.Length)
        {
            int takeLength = ((ptr + 2 * k) < s.Length) ? 2 * k : s.Length - ptr;
            result += reversePart(s.Substring(ptr, takeLength), k);
            ptr += takeLength;
        }
        return result;
    }

    public string reversePart(string s, int k)
    {
        string result = "";
        if (s.Length >= k)
        {
            result = reverseWhole(s.Substring(0, k), k) + s.Substring(k, s.Length - k);
        } else 
        {
            result = reverseWhole(s.Substring(0, s.Length), s.Length);
        }
        return result;
    }

    public string reverseWhole(string s, int slen)
    {
        var builder = new StringBuilder();

        for (int i = slen / 2; i >= 0; i--)
        {
            builder.Append(s[i]);
        }

        for (int i = slen / 2 + 1; i < slen; i++)
        {
            builder.Insert(0, s[i]);
        }

        return builder.ToString();
    }
}
