/// <summary>
/// Leetcode 350 Array Intersection
/// time: 87%
/// mem: 24%
/// </summary>
public class q350 {
    public int[] Intersect(int[] nums1, int[] nums2) {
        List<int> result = new List<int>();
        int[] count = new int[1010];
        for (int i = 0; i < nums1.Length; i++) { count[nums1[i]]++; }
        for (int i = 0; i < nums2.Length; i++) {
            if (count[nums2[i]] > 0) {
                result.Add(nums2[i]);
                count[nums2[i]]--;
            }
        }
        return result.ToArray(); 
    }
}
