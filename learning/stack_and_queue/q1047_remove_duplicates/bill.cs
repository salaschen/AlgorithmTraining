using System.Text;

/// <summary>
/// Level: Easy
/// Note: 
///     1) It's most efficient to use StringBuilder.
/// </summary>
internal class q1047 {

    public static void Run() {
        var sol = new q1047();
        string s = "abbaca";
        Console.WriteLine(sol.RemoveDuplicates(s));

        s = "azxxzy";
        Console.WriteLine(sol.RemoveDuplicates(s));
    }

    /// <summary>
    /// time: 46%
    /// mem : 67%
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string RemoveDuplicates(string s) {
        int size = (int)Math.Pow(10, 5) + 5;
        char[] mem = new char[size];
        int ptr = 0;

        foreach (var c in s) {
            if (ptr > 0 && mem[ptr - 1] == c) {
                mem[ptr] = '\0';
                ptr--;
            } else {
                mem[ptr++] = c;
            }
        }
        return string.Join(string.Empty, mem.Take(ptr));
    }

    /// <summary>
    /// time: 64%
    /// mem:  84%
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string RemoveDuplicates2(string s) {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (builder.Length > 0 && builder[builder.Length - 1] == c) {
                builder.Remove(builder.Length - 1, 1);
            } else {
                builder.Append(c);
            }
        }
        return builder.ToString();
    }

    /// <summary>
    /// time: 41.5%
    /// mem:  34%
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string RemoveDuplicatesOld(string s) {
        List<char> stack = new List<char>();
        for (int i = 0; i < s.Length; i++) {
            char cur = s[i];
            if (stack.Count > 0 && stack[stack.Count - 1] == cur) {
                stack.RemoveAt(stack.Count - 1);
            } else {
                stack.Add(cur);
            }
        }
        return string.Join(string.Empty, stack);
    }
}
