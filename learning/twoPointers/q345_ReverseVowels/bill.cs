using System.Text;

internal class q345
{
    public static void Run()
    {
        var sol = new q345();
        var s = "hello";
        Console.WriteLine($"{s}, {sol.ReverseVowels(s)}");

        s = "leetcode";
        Console.WriteLine($"{s}, {sol.ReverseVowels(s)}");

        s = "l";
        Console.WriteLine($"{s}, {sol.ReverseVowels(s)}");

        s = "e";
        Console.WriteLine($"{s}, {sol.ReverseVowels(s)}");

        s = "le";
        Console.WriteLine($"{s}, {sol.ReverseVowels(s)}");

        s = "el";
        Console.WriteLine($"{s}, {sol.ReverseVowels(s)}");

        s = "ela";
        Console.WriteLine($"{s}, {sol.ReverseVowels(s)}");

        s = "eleaa";
        Console.WriteLine($"{s}, {sol.ReverseVowels(s)}");

        s = "leaa";
        Console.WriteLine($"{s}, {sol.ReverseVowels(s)}");
    }

    /// <summary>
    /// Brute-force
    /// Use two pass
    /// time: 13%
    /// mem : 40%
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string ReverseVowels(string s)
    {
        // quick return
        if (s.Length == 1)
            return s;

        char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        List<int> vowelIndexes = new List<int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (vowels.Contains(s[i]))
            {
                vowelIndexes.Add(i);
            }
        }

        // only one vow, can just return
        if (vowelIndexes.Count == 1)
        {
            return s;
        }

        Tuple<int, int>[] pairs = new Tuple<int, int>[vowelIndexes.Count / 2];
        int low = 0;
        int high = vowelIndexes.Count - 1;
        int count = 0;
        while (low < high)
        {
            pairs[count++] = new Tuple<int, int>(vowelIndexes[low++], vowelIndexes[high--]);
        }

        // debug print
        // Console.WriteLine($"{string.Join(',', pairs.Select(p => "("+p.Item1.ToString()+","+p.Item2.ToString()+")"))}");

        StringBuilder front = new StringBuilder();
        StringBuilder end = new StringBuilder();
        int lowPtr = 0;
        int highPtr = s.Length - 1;
        for (int i = 0; i < pairs.Length; i++)
        {
            low = pairs[i].Item1;
            high = pairs[i].Item2;

            while (lowPtr < low)
            {
                front.Append(s[lowPtr++]);
            }

            while (highPtr > high)
            {
                end.Insert(0, s[highPtr--]);
            }

            // swap
            front.Append(s[highPtr--]);
            end.Insert(0, s[lowPtr++]);
        }

        // closing the gap
        while (lowPtr <= highPtr)
        {
            front.Append(s[lowPtr++]);
        }

        return front.Append(end).ToString();
    }
}
