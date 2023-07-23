internal class q150 {
    public static void Run() {
        var sol = new q150();
        string[] tokens = new string[] { "2", "1", "+", "3", "*" };
        Console.WriteLine($"{sol.EvalRPN(tokens)}, 9");

        tokens = new string[] { "4", "13", "5", "/", "+" };
        Console.WriteLine($"{sol.EvalRPN(tokens)}, 6");

        tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
        Console.WriteLine($"{sol.EvalRPN(tokens)}, 22");
    }

    private string[] operators = new string[] { "+", "-", "/", "*" };

    /// <summary>
    /// time: 28%
    /// mem : 40%
    /// </summary>
    /// <param name="tokens"></param>
    /// <returns></returns>
    public int EvalRPN(string[] tokens) {
        List<int> operands = new List<int>();
        for (int i = 0; i < tokens.Length; i++) {
            string cur = tokens[i];
            if (operators.Contains(cur)) {
                // eval
                int second = operands[operands.Count - 1];
                int first = operands[operands.Count - 2];
                operands.RemoveRange(operands.Count - 2, 2);
                int result = eval(first, second, cur);
                // debug
                // Console.WriteLine($"{first}{cur}{second}={result}");
                operands.Add(result);
            } else {
                operands.Add(int.Parse(cur));
            }
        }
        return operands[0];
    }

    private int eval(int first, int second, string op) {
        switch (op) {
            case "+":
                return first + second;
            case "-":
                return first - second;
            case "*":
                return first * second;
            case "/":
                double temp = (first * 1.0) / second;
                int sign = (temp >= 0) ? 1 : -1;
                return (int)Math.Floor(Math.Abs(temp)) * sign;
            default:
                return 0;
        }
    }
}
