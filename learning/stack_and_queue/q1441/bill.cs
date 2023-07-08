using System.Runtime.CompilerServices;
/// <summary>
/// Build an array with stack operations.
/// time: 68%
/// mem: 100%
/// </summary>
public static class TestHelper {
    public static string toPrintString(this IList<string> lst) {
        return $"[{string.Join(',', lst)}]";
    }
}

internal class q1441 {
    public static void Run() {
        var sol = new q1441();
        int[] target = new int[] { 1, 3 };
        int n = 3;
        Console.WriteLine(sol.BuildArray(target, n).toPrintString());
    }

    public IList<string> BuildArray(int[] target, int n) {
        var result = new List<string>();
        int cur = 1;
        for (int i = 0; i < target.Length; i++) {
            int tNum = target[i];
            while (cur != tNum) {
                result.Add("Push");
                result.Add("Pop");
                cur++;
            }
            result.Add("Push");
            cur++;
        }
        return result;
    }
}
