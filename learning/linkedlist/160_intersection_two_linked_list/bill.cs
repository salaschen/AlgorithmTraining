using leetcode.Datastructure;

namespace leetcode.Problems {
    internal class q160 {
        // version 1: memoization
        // time: 45%
        // mem: 15%
        public ListNode GetIntersectionNodeV1(ListNode headA, ListNode headB) {
            var seen = new HashSet<ListNode>();
            ListNode cur = headA;
            while (cur != null) {
                seen.Add(cur);
                cur = cur.next; 
            }

            cur = headB;
            while (cur != null) {
                if (seen.Contains(cur)) {
                    return cur; 
                }
                cur = cur.next;
            }

            return null; 
        }

        // version 2: use pointer tricks
        // time: 56%
        // mem: 57%
        // better than version 1
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
            int lenA = 0;
            int lenB = 0;
            var cur = headA;
            while (cur != null) {
                lenA ++;
                cur = cur.next;
            }

            cur = headB;
            while (cur != null) {
                lenB++;
                cur = cur.next;
            }

            var ptrA = headA;
            var ptrB = headB;
            var steps = Math.Abs(lenA - lenB);
            ListNode movePtr = (lenA > lenB) ? ptrA : ptrB ;
            ListNode stayPtr = (movePtr == ptrA) ? ptrB : ptrA;
            for (int i = 0; i < steps; i++) {
                movePtr = movePtr.next;
            }

            // now compare movePtr and stayPtr one by one
            while (movePtr != null && stayPtr != null) {
                if (movePtr == stayPtr) {
                    return movePtr;
                }
                movePtr = movePtr.next;
                stayPtr = stayPtr.next; 
            }
            return null; 
        }
    }
}
