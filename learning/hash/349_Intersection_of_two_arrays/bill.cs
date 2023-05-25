/// <summary>
/// Leetcode 349: Intersection of Two Arrays - Easy
/// time: 74%
/// mem: 28%
/// </summary>
public class q349 {
    public int[] Intersection(int[] nums1, int[] nums2) {
        HashSet<int> set1 = new HashSet<int>(nums1);
        HashSet<int> set2 = new HashSet<int>(nums2);
        return set1.Intersect(set2).ToArray();
    }
}
