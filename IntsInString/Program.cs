using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var lines = File.ReadAllText("Data.txt");
        Console.WriteLine(Solve(lines, @"\d"));
        Console.WriteLine(Solve(lines, @"\d|one|two|three|four|five|six|seven|eight|nine"));
    }

    static int Solve(string input, string rx) => (
        from line in input.Split(Environment.NewLine)
        let first = Regex.Match(line, rx)
        let last = Regex.Match(line, rx, RegexOptions.RightToLeft)
        select Match(first.Value) * 10 + Match(last.Value)
    ).Sum();

    static int Match(string st)
    {
        var numberDict = new Dictionary<string, int>
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
        };
        return numberDict.TryGetValue(st, out var number) ? number : int.TryParse(st, out number) ? number : 0;
    }
}