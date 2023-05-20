using leetcode.Datastructure;

internal class q142 {
    // time: 79%
    // mem: 18%
    public ListNode DetectCycle(ListNode head) {
        if (head is null) {
            return null; 
        }

        var seen = new HashSet<ListNode>();
        var cur = head;
        while (cur != null) {
            if (seen.Contains(cur)) {
                return cur; 
            }
            seen.Add(cur);
            cur = cur.next; 
        }
        return null; 
    }
}
