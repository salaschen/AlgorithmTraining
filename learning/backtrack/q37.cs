using System.Text;
using System.Xml.Linq;

/**
Author: Ruowei Chen
Prob: 37 Hard - Solve Sudoku
Date: 17/Mar/2024
*/


namespace leetcode.Problems;

public class q37 {

    public static void Run() {
        var sol = new q37();
        char[][] board = new char[][] {
            new char[] {'5','3','.','.','7','.','.','.','.' },
            new char[] {'6','.','.','1','9','5','.','.','.' },
            new char[] {'.','9','8','.','.','.','.','6','.' },
            new char[] {'8','.','.','.','6','.','.','.','3' },
            new char[] {'4','.','.','8','.','3','.','.','1' },
            new char[] {'7','.','.','.','2','.','.','.','6' },
            new char[] {'.','6','.','.','.','.','2','8','.' },
            new char[] {'.','.','.','4','1','9','.','.','5' },
            new char[] {'.','.','.','.','8','.','.','7','9' },
        };

        sol.SolveSudoku(board);
        Console.WriteLine(sol.PrintBoard(board));
    }

    public string PrintBoard(char[][] board) {
        var builder = new StringBuilder();
        for (int i = 0; i < 9; i++) {
            string line = "";
            for (int j = 0; j < 9; j++) {
                line += board[i][j];
            }
            line += '\n';
            builder.Append(line);
        }
        return builder.ToString();
    }

    public void SolveSudoku(char[][] board) {
        backtrack(board);
    }

    public bool backtrack(char[][] board) {
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (board[i][j] != '.') { continue; }

                // try 1-9
                for (int k = 1; k <= 9; k++) {
                    char c = (char)('0' + k);
                    
                    // setup
                    board[i][j] = c;
                   

                    // backtrack 
                    if (isValid(board, i, j) && backtrack(board)) { return true; }

                    // restore
                    board[i][j] = '.';
                }

                return false;
            }
        }
        return true;
    }

    private bool isValid(char[][] board, int r, int c) {
        // check box
        if (checkBox(board, r, c) == false) {
            return false;
        }

        // check row
        for (int j = 0; j < 9; j++) {
            if (j == c) { continue; }
            if (board[r][j] == board[r][c]) { return false; }
        }

        // check column
        for (int i = 0; i < 9; i++) {
            if (i == r) { continue; }
            if (board[i][c] == board[r][c]) { return false; }
        }

        return true;
    }

    private bool checkBox(char[][] board, int r, int c) {
        var (tr, tc) = getTopLeftCorner(r, c);
        for (int i = tr; i < tr + 3; i++) {
            for (int j = tc; j < tc + 3; j++) {
                if (i == r && j == c) { continue; }
                if (board[i][j] == board[r][c]) { return false; }
            }
        }
        return true;
    }

    private (int, int) getTopLeftCorner(int r, int c) {
        return ((r / 3) * 3, (c / 3) * 3);
    }
}
