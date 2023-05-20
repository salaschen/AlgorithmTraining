using leetcode.Datastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Problems {

    public class q237 {
        public static void Run() {
            var sol = new q237();
            
            // Case 1: sample 1
            var values = new List<int>() {4,5,1,9 };
            var nodeValue = 5;
            var head = ListNode.ReadListToNode(values);
            var node = GetNode(head, nodeValue);
            Console.Write("Before:\t");
            ListNode.PrintListNode(head);
            sol.DeleteNode(node);
            Console.Write("After:\t");
            ListNode.PrintListNode(head);

            // Case 2: sample 2
            values = new List<int>() {4,5,1,9 };
            nodeValue = 1;
            head = ListNode.ReadListToNode(values);
            node = GetNode(head, nodeValue);
            Console.Write("Before:\t");
            ListNode.PrintListNode(head);
            sol.DeleteNode(node);
            Console.Write("After:\t");
            ListNode.PrintListNode(head);

            // case 3: remove head
            int Case = 3;
            values = new List<int>() {4,5,1,9 };
            nodeValue = 4;
            head = ListNode.ReadListToNode(values);
            node = GetNode(head, nodeValue);
            Console.Write($"Case {Case}: Before:\t");
            ListNode.PrintListNode(head);
            sol.DeleteNode(node);
            Console.Write($"Case {Case}: After:\t");
            ListNode.PrintListNode(head);

            // Case 4: two value list remove head
            Case = 4;
            values = new List<int>() {4,5};
            nodeValue = 4;
            head = ListNode.ReadListToNode(values);
            node = GetNode(head, nodeValue);
            Console.Write($"Case {Case}: Before:\t");
            ListNode.PrintListNode(head);
            sol.DeleteNode(node);
            Console.Write($"Case {Case}: After:\t");
            ListNode.PrintListNode(head);

        }

        public static ListNode GetNode(ListNode head, int target) {
            if (head is null) {
                return null; 
            }

            var cur = head;
            while (cur != null) {
                if (cur.val == target) {
                    return cur; 
                }
                cur = cur.next; 
            }
            return null; 
        }

        // Note: We cannot manipulate the pointers, so have to copy the values instead
        public void DeleteNode(ListNode node) {
            // make sure the current node is not null, and it's not the last one in the list.
            if (node is null || node.next is null) {
                return;
            }

            ListNode prev = node;
            ListNode cur = node.next;
            prev.val = cur.val;

            while (cur.next != null) {
                cur.val = cur.next.val;
                prev = cur;
                cur = cur.next;
            }

            // delete the cur becaust cur is now the last node.
            prev.next = null; 
        }
    }
}
