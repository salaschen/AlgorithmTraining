internal class q383 {
    // time: 99.65% (wow)
    //  mem: 72%
    public bool CanConstruct(string ransomNote, string magazine) {
        int[] count = new int[27];
        for (int i = 0; i < magazine.Length; i++) {
            count[magazine[i] - 'a']++;
        }

        for (int i = 0; i < ransomNote.Length; i++) {
            count[ransomNote[i] - 'a']--;
        }

        for (int i = 0; i < count.Length; i++) {
            if (count[i] < 0) {
                return false; 
            }
        }

        return true; 
    }
}
