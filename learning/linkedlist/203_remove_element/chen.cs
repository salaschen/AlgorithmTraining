using leetcode.Datastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Problems {
    public class q203 {
        // time: 5%
        // mem: 60%
        public ListNode RemoveElements(ListNode head, int val) {
            var dummy = new ListNode(-1);
            dummy.next = head;
            var prev = dummy;
            var cur = head;

            while (cur != null) {
                if (cur.val == val) {
                    prev.next = cur.next;
                    cur = cur.next;
                } else {
                    prev = cur;
                    cur = cur.next; 
                }
            }

            return dummy.next; 
        }
    }
}
