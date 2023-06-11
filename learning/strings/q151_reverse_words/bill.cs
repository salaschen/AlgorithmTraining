/// <summary>
/// 151 Reverse Words (Medium)
/// time: 41%
/// mem: 42%
/// </summary>
public class q151
{
    public static void Run() {
        var sol = new q151();
        var s = "the sky is blue";
        Console.WriteLine(sol.ReverseWords(s));

        s = "  hello  world  ";
        Console.WriteLine(sol.ReverseWords(s));

        s = "a good  example ";
        Console.WriteLine(sol.ReverseWords(s));
    }

    public string ReverseWords(string s)
    {
        return string.Join(" ",
            s.Split(' ')
            .Where(p => !string.IsNullOrEmpty(p))
            .Select(p => p.Trim()).Reverse());
    }

}
