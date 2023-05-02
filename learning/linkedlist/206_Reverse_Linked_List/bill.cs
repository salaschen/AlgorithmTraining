using leetcode.Datastructure;

public class q206 {
    public static void Run() {
        var sol = new q206();

        var data = new List<List<int>>() {
            new List<int>() {1,2,3,4,5 },
            new List<int>() {1,2 },
            new List<int>() { }
        };

        foreach (var d in data) {
            var node = ListNode.ReadListToNode(d);
            ListNode.PrintListNode(node);
            var newHead = sol.ReverseList(node);
            ListNode.PrintListNode(newHead);
        }
    }

    public ListNode ReverseList(ListNode head) {
        if (head is null) {
            return head;
        }

        // ListNode dummy = new ListNode();
        ListNode cur = head;
        ListNode pre = null;

        while (cur != null) {
            var next = cur.next;
            cur.next = pre;
            pre = cur;
            cur = next; 
        }

        return pre; 
    }

    // slow
    public ListNode ReverseListSlow(ListNode head) {
        if (head is null) {
            return head; 
        }

        ListNode dummyHead = new ListNode();
        List<ListNode> nodes = new List<ListNode>();
        ListNode cur = head;
        while (cur != null) {
            nodes.Add(cur);
            cur = cur.next;
        }

        nodes.Reverse();
        cur = dummyHead;
        int count = nodes.Count; 
        for (int i = 0; i < count; i++) {
            ListNode next = nodes.First();
            cur.next = next;
            cur = next;
            nodes.RemoveAt(0);
        }

        cur.next = null;

        return dummyHead.next; // todo
    }
}

