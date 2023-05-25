/// <summary>
/// Leetcode 242 Valid Anagram - Easy
/// </summary>
public class q242 {

    // time: 69%
    // mem: 87%
    public bool IsAnagram(string s, string t) {
        List<char> chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray().ToList();
        var count = new Dictionary<char, int>();
        foreach (var ch in chars) {
            count[ch] = 0;
        }

        // quick test first
        if (s.Length != t.Length) {
            return false;
        }

        for (int i = 0; i < s.Length; i++) {
            count[s[i]]++;
            count[t[i]]--;
        }

        for (int i = 0; i < chars.Count; i++) {
            if (count[chars[i]] != 0) {
                return false; 
            }
        }

        return true; 
    }
}
