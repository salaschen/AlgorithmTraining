using System.Runtime.CompilerServices;

namespace leetcode.Problems;

public class q51 {

    public static void Run() {
        var sol = new q51();
        int n = 4;
        var result = sol.SolveNQueens(n);
        Console.WriteLine($"\nn = {n}:");
        sol.PrintResult(result);

        n = 5;
        result = sol.SolveNQueens(n);
        Console.WriteLine($"\nn = {n}:");
        sol.PrintResult(result);

        n = 9;
        // result = sol.SolveNQueens(n);
        // Console.WriteLine($"n = {n}:");
        // sol.PrintResult(result);
    }

    public void PrintResult(IList<IList<string>> result) {
        foreach (var board in result) {
            Console.WriteLine();
            foreach (var line in board) {
                Console.WriteLine(line);
            }
        }
    }

    public IList<IList<string>> SolveNQueens(int n) {
        IList<IList<string>> result = new List<IList<string>>();
        backtrack(new int[n, n], 0, n, result);
        return result;
    }

    public void backtrack(int[,] board, int row, int n, IList<IList<string>> result) {
        if (row >= n) {
            // copy board to the result
            var t = translate(board, n);
            result.Add(t);
            return;
        }

        for (int i = 0; i < n; i++) {
            if (canPlace(board, row, n, i) == false) { continue; }

            // setup
            board[row, i] = 1;

            // search
            backtrack(board, row + 1, n, result);

            // restore
            board[row, i] = 0;
        }
    }

    public bool canPlace(int[,] board, int row, int n, int index) {
        // look up
        for (int i = 0; i < row; i++) {
            if (board[i, index] == 1) {
                return false;
            }
        }

        // look diagonal left-up
        for (int i = row - 1, j = index - 1; i >= 0 && j >= 0; i--, j--) {
            if (board[i, j] == 1) { return false; }
        }

        // look diagonal right-up
        for (int i = row - 1, j = index + 1; i >= 0 && j < n; i--, j++) {
            if (board[i, j] == 1) { return false; }
        }

        return true;
    }

    public List<string> translate(int[,] board, int n) {
        var result = new List<string>();
        for (int i = 0; i < n; i++) {
            var line = "";
            for (int j = 0; j < n; j++) {
                line += board[i, j] == 0 ? '.' : 'Q';
            }
            result.Add(line);
        }
        return result;
    }
}
