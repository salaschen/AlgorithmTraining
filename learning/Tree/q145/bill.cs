using leetcode.Datastructure;

internal class q145 {
    // iterative
    // time: 70%
    // mem: 37%
    public IList<int> PostorderTraversal(TreeNode root) {
        Stack<int> resultStack = new Stack<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Any()) {
            var node = stack.Pop();
            if (node is null) {
                continue;
            }
            resultStack.Push(node.val);
            stack.Push(node.left);
            stack.Push(node.right);
        }
        IList<int> result = new List<int>();
        while (resultStack.Any()) {
            result.Add(resultStack.Pop());
        }
        return result;
    }
}
