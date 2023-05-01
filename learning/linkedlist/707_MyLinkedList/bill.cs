public class q707 {

    public static void Run() {
        var lst = new MyLinkedList();
        lst.AddAtHead(1);
        lst.AddAtTail(3);
        lst.AddAtIndex(1, 2);
        Console.WriteLine(lst.Get(1));
        lst.DeleteAtIndex(1);
        Console.WriteLine(lst.Get(1));

        Test();
    }

    private static void Test() {
        var actions = new string[] { "MyLinkedList", "addAtHead", "addAtTail", "addAtTail", "get", "get", "addAtTail", "addAtIndex", "addAtHead", "addAtHead", "addAtTail", "addAtTail", "addAtTail", "addAtTail", "get", "addAtHead", "addAtHead", "addAtIndex", "addAtIndex", "addAtHead", "addAtTail", "deleteAtIndex", "addAtHead", "addAtHead", "addAtIndex", "addAtTail", "get", "addAtIndex", "addAtTail", "addAtHead", "addAtHead", "addAtIndex", "addAtTail", "addAtHead", "addAtHead", "get", "deleteAtIndex", "addAtTail", "addAtTail", "addAtHead", "addAtTail", "get", "deleteAtIndex", "addAtTail", "addAtHead", "addAtTail", "deleteAtIndex", "addAtTail", "deleteAtIndex", "addAtIndex", "deleteAtIndex", "addAtTail", "addAtHead", "addAtIndex", "addAtHead", "addAtHead", "get", "addAtHead", "get", "addAtHead", "deleteAtIndex", "get", "addAtHead", "addAtTail", "get", "addAtHead", "get", "addAtTail", "get", "addAtTail", "addAtHead", "addAtIndex", "addAtIndex", "addAtHead", "addAtHead", "deleteAtIndex", "get", "addAtHead", "addAtIndex", "addAtTail", "get", "addAtIndex", "get", "addAtIndex", "get", "addAtIndex", "addAtIndex", "addAtHead", "addAtHead", "addAtTail", "addAtIndex", "get", "addAtHead", "addAtTail", "addAtTail", "addAtHead", "get", "addAtTail", "addAtHead", "addAtTail", "get", "addAtIndex" };
        string valuesString = "[],[84],[2],[39],[3],[1],[42],[1,80],[14],[1],[53],[98],[19],[12],[2],[16],[33],[4,17],[6,8],[37],[43],[11],[80],[31],[13,23],[17],[4],[10,0],[21],[73],[22],[24,37],[14],[97],[8],[6],[17],[50],[28],[76],[79],[18],[30],[5],[9],[83],[3],[40],[26],[20,90],[30],[40],[56],[15,23],[51],[21],[26],[83],[30],[12],[8],[4],[20],[45],[10],[56],[18],[33],[2],[70],[57],[31,24],[16,92],[40],[23],[26],[1],[92],[3,78],[42],[18],[39,9],[13],[33,17],[51],[18,95],[18,33],[80],[21],[7],[17,46],[33],[60],[26],[4],[9],[45],[38],[95],[78],[54],[42,86]";
        List<string> values = new List<string>();
        int curIndex = 0;
        string curString = "";
        bool open = false; 
        while (curIndex < valuesString.Length) {
            if (valuesString[curIndex] == ']') {
                values.Add(curString);
                curString = "";
                open = false; 
            } else if (valuesString[curIndex] == '[') {
                open = true;
            } else if (open) {
                curString += valuesString[curIndex];
            }
            curIndex++;
        }

        MyLinkedList lst = null;
        List<string> result = new List<string>();
        for (int i = 0; i < actions.Length; i++) {
            var action = actions[i];
            string value = values[i].Trim('[').Trim(']');
            int val = -1;
            switch (action) {
                case "MyLinkedList":
                    lst = new MyLinkedList();
                    result.Add("null");
                    break;

                case "addAtHead":
                    if (int.TryParse(value, out val)) {
                        lst?.AddAtHead(val);
                    }
                    result.Add("null");
                    Console.WriteLine($"add at head {val}"); // debug
                    break;

                case "addAtTail":
                    if (int.TryParse(value, out val)) {
                        lst?.AddAtTail(val);
                    }
                    result.Add("null");
                    Console.WriteLine($"add at tail {val}"); // debug
                    break;

                case "get":
                    if (int.TryParse(value, out val)) {
                        int tempGet = lst.Get(val);
                        result.Add(tempGet.ToString());
                    } else {
                        result.Add("null");
                    }
                    break;

                case "deleteAtIndex":
                    if (int.TryParse(value, out val)) {
                        lst.DeleteAtIndex(val);
                    }
                    result.Add("null");
                    Console.WriteLine($"delete at {val}"); // debug
                    break;

                case "addAtIndex":
                    string[] temp = value.Split(',');
                    int index;
                    if (int.TryParse(temp[0], out index) && int.TryParse(temp[1], out val)) {
                        lst.AddAtIndex(index, val);
                    }
                    result.Add("null");
                    Console.WriteLine($"add {val} at {index}"); // debug
                    break;
                default:
                    break;
            }

            // debug
            lst.PrintList(lst);
        }
        Console.WriteLine(string.Join(',', result));
    }
}

// time: 98.7%
// mem: 11.8%
public class MyLinkedList {
    private Node head;
    public int size;
    private Node tail;

    public MyLinkedList() {
        head = null;
        size = 0;
        tail = null;
    }

    public int Get(int index) {
        // return -1 if the index is invalid
        if (index > size - 1 || index < 0) {
            return -1;
        }

        if (size > 0 && index == size - 1) {
            return tail.value;
        }

        Node cur = head;
        for (int i = 0; i < index; i++) {
            cur = cur.next;
        }
        return cur.value;
    }

    public void AddAtHead(int val) {
        if (head is null) {
            head = new Node(val);
            tail = head;
        } else {
            Node newHead = new Node(val);
            newHead.next = head;
            head = newHead;
        }
        size++;
    }

    public void AddAtTail(int val) {
        if (head is null) {
            head = new Node(val);
            tail = head;
        } else {
            Node newTail = new Node(val);
            tail.next = newTail;
            tail = newTail;
        }
        size++;
    }

    public void AddAtIndex(int index, int val) {
        // when the index is greater than the length, node will not be inserted.
        if (index > size || index < 0) {
            return;
        }

        // add to head
        if (index == 0) {
            AddAtHead(val);
            return;
        }

        // add to tail
        if (index == size) {
            AddAtTail(val);
            return;
        }

        // now find the correct node to insert before.
        Node before = head;
        for (int i = 0; i < index - 1; i++) {
            before = before.next;
        }
        Node after = before.next;
        Node target = new Node(val);
        before.next = target;
        target.next = after;
        size++;
    }

    public void DeleteAtIndex(int index) {
        // Don't delete if index is not valid.
        if (index < 0 || index >= size) {
            return;
        }

        // Special: delete head
        if (index == 0) {
            head = head.next;
            size--;
            return;
        }
        
        Node before = head;
        for (int i = 0; i < index - 1; i++) {
            before = before.next;
        }
        Node target = before.next;
        before.next = target.next;
        // delete at tail
        if (index == size - 1) {
            tail = before;
        }

        size--;
    }

    public bool isEmpty() {
        return size == 0;
    }

    private class Node {
        public Node next;
        public int value;

        public Node(int val) {
            next = null;
            value = val;
        }
    }

    public void PrintList(MyLinkedList lst) {
        if (lst.isEmpty()) {
            Console.WriteLine("empty list");
        }

        List<int> values = new List<int>();
        for (int i = 0; i < lst.size; i++) {
            values.Add(lst.Get(i));
        }
        Console.WriteLine($"size: {lst.size}\nvalues: {string.Join(',', values.Select(n => n.ToString()))}");
    }
}
