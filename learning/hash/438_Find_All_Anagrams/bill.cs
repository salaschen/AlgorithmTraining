/// <summary>
/// Leetcode 438 Find All Anagrams in a string - Medium
/// time: 83%
/// mem: 51%
/// </summary>
public class q438 {

    public static void Run() {
        var sol = new q438();
        string s = "cbaebabacd";
        string p = "abc";
        PrintList(sol.FindAnagrams(s, p));

        s = "abab";
        p = "ab";
        PrintList(sol.FindAnagrams(s, p));

        s = "ababa";
        p = "ab";
        PrintList(sol.FindAnagrams(s, p));

        s = "ababa";
        p = "abcdefg";
        PrintList(sol.FindAnagrams(s, p));

        s = "baa";
        p = "aa";
        PrintList(sol.FindAnagrams(s, p));
    }

    public static void PrintList(IList<int> lst) {
        Console.WriteLine(string.Join(',', lst.Select(n => n.ToString())));
    }

    public static void PrintArray(int[] lst) {
        Console.WriteLine(string.Join(',', lst.Select(n => n.ToString())));
    }

    public IList<int> FindAnagrams(string s, string p) {
        int[] count = new int[26];
        int notMatched = 0;
        IList<int> result = new List<int>();
        HashSet<char> pchars = new HashSet<char>(p.ToCharArray());

        // quick test
        if (s.Length < p.Length) {
            return result;
        }
        // count the p
        for (int i = 0; i < p.Length; i++) {
            count[p[i] - 'a']++;
        }

        // debug
        // Console.WriteLine($"s:{s}, p:{p}");

        // debug
        // PrintArray(count);

        // Do the first p.length characters first
        for (int i = 0; i < p.Length; i++) {
            if (pchars.Contains(s[i])) {
                count[s[i] - 'a']--;
            }
        }

        // debug
        // PrintArray(count);

        // count the not matched
        for (int i = 0; i < count.Length; i++) {
            if (count[i] != 0) { notMatched++; }
        }

        if (notMatched == 0) {
            result.Add(0);
        }
        // now scan the other start indexes
        for (int i = 1; i <= s.Length - p.Length; i++) {
            char prev = s[i - 1];
            char next = s[i + p.Length - 1];
            if (prev == next) {
                if (notMatched == 0) {
                    result.Add(i);
                }
                continue;
            }
            if (pchars.Contains(prev)) {
                count[prev - 'a']++;
                if (count[prev - 'a'] == 0) {
                    notMatched--;
                } else if (count[prev - 'a'] == 1) {
                    notMatched++;
                }
            }

            if (pchars.Contains(next)) {
                count[next - 'a']--;
                if (count[next - 'a'] == 0) {
                    notMatched--;
                } else if (count[next - 'a'] == -1) {
                    notMatched++;
                }
            }

            // debug
            // PrintArray(count);

            if (notMatched == 0) {
                result.Add(i);
            }
        }
        return result;
    }
}
