using leetcode.Datastructure;

public class q24 {
    public static void Run() {
        var sol = new q24();

        var data = new List<List<int>>() {
            new List<int>() {1,2,3 },
            new List<int>() {1,2,3,4,5 },
            new List<int>() {1,2 },
            new List<int>() {1 },
            new List<int>() {1,2,3,4 },
            new List<int>() { }
        };

        foreach (var d in data) {
            var node = ListNode.ReadListToNode(d);
            ListNode.PrintListNode(node);
            var newHead = sol.SwapPairs(node);
            ListNode.PrintListNode(newHead);
        }
    }

    // time: 8%
    // mem: 9%
    // Note: why so slow
    public ListNode SwapPairs(ListNode head) {
        if (head is null || head.next is null) {
            return head;
        }

        ListNode dummy = new ListNode();

        // at the beginning, both cur and next are *not* null
        ListNode cur = head;
        ListNode next = cur.next;
        ListNode curHead = dummy;
        while (cur != null && next != null) {
            curHead.next = next;
            curHead = cur; 
            var temp = next.next;
            next.next = cur;
            cur.next = temp;
            cur = temp;
            next = cur?.next; 
        }

        return dummy.next; 
    }
}
