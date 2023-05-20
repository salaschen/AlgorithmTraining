public class q287 {
    // use count array
    // time: 98%
    // mem: 36%
    public int FindDuplicate(int[] nums) {
        int upper = (int)Math.Pow(10, 5) + 10;
        int[] count = new int[upper];

        for (int i = 0; i < nums.Length; i++) {
            count[nums[i]]++;
            if (count[nums[i]] > 1) {
                return nums[i];
            }
        }

        // not found
        return -1; 
    }

    // Use HashSet
    // time: 25%
    // mem: 78%
    public int FindDuplicateV1(int[] nums) {
        var seen = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++) {
            if (seen.Contains(nums[i])) {
                return nums[i];
            }
            seen.Add(nums[i]);
        }
        // not found
        return -1;
    }
}
