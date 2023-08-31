using leetcode.Datastructure;

internal class q144 {

    // Iterative
    // time: 88%
    // mem: 17%
    public IList<int> PreorderTraversal(TreeNode root) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        IList<int> result = new List<int>();
        stack.Push(root);
        while (stack.Count > 0) {
            var node = stack.Pop();
            if (node is null) {
                continue;
            }
            result.Add(node.val);
            stack.Push(node.right);
            stack.Push(node.left);
        }
        return result;
    }
}
