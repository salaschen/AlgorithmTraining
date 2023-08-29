using leetcode.Datastructure;
internal class q94 {

    /// <summary>
    /// Recursive and Iterative
    /// time: 68%
    /// mem : 94%.
    /// </summary>
    public static void Run() {
        var sol = new q94();
        var data = new List<int?>() { 1, null, 2, 3 };
        TreeNode root = TreeNode.ReadTree(data);
        var result = sol.InorderTraversal(root) as List<int>;
        Console.WriteLine(result?.ToPrintString());

        data = new List<int?>() { };
        root = TreeNode.ReadTree(data);
        result = sol.InorderTraversal(root) as List<int>;
        Console.WriteLine(result?.ToPrintString());

        data = new List<int?>() {1 };
        root = TreeNode.ReadTree(data);
        result = sol.InorderTraversal(root) as List<int>;
        Console.WriteLine(result?.ToPrintString());

    }

    // Iterative version.
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> result = new List<int>();
        HashSet<int> visited = new HashSet<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0) {
            TreeNode cur = stack.Pop();
            if (cur is null) {
                continue;
            } else if (visited.Contains(cur.GetHashCode())) {
                result.Add(cur.val);
            } else {
                visited.Add(cur.GetHashCode());
                stack.Push(cur.right);
                stack.Push(cur);
                stack.Push(cur.left);
            }
        }
        return result;
    }


    // Recursive version.
    public IList<int> InorderTraversalRecur(TreeNode root) {
        IList<int> result = new List<int>();
        visit(root, result);
        return result;
    }

    private void visit(TreeNode root, IList<int> result) {
        if (root is null) {
            return;
        }

        visit(root.left, result);
        result.Add(root.val);
        visit(root.right, result);
    }
}
