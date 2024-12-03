using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day3
{
    private const string File = "../../../Day3/Day3_input.txt";
    public void Challenge1()
    {
        int total = 0;
        List<string> matchedStrings = ExtractRegex(@"mul\(\d{1,3},\d{1,3}\)");

        foreach (var mul in matchedStrings)
        {
            string a = mul.Substring(mul.IndexOf('(')+ 1, mul.Length - mul.IndexOf('(')-2);
            var matchedNumbers = a.Split(',').Select(int.Parse).ToList();
            total += matchedNumbers[0] * matchedNumbers[1];
        }
        Console.WriteLine($"Day 3 Challenge 1: {total}");
    }
    
    public void Challenge2()
    {
        int total = 0;
        List<string> matchedStrings = ExtractRegex(@"mul\(\d{1,3},\d{1,3}\)|don't\(\)|do\(\)");

        bool enabled = true;
        foreach (var mul in matchedStrings)
        {
            if (mul == "don't()") { enabled = false; continue;}
            if (mul == "do()") { enabled = true; continue; }

            if (enabled)
            {
                string a = mul.Substring(mul.IndexOf('(')+ 1, mul.Length - mul.IndexOf('(')-2);
                var matchedNumbers = a.Split(',').Select(int.Parse).ToList();
                total += matchedNumbers[0] * matchedNumbers[1];
            }
        }
        Console.WriteLine($"Day 3 Challenge 2: {total}");
    }

    private List<string> ExtractRegex(string regexString)
    {
        List<string> matches = new List<string>();
        Regex regex = new(regexString);

        using StreamReader reader = new StreamReader(File);
        string fileContents = reader.ReadToEnd();
        foreach (Match match in regex.Matches(fileContents))
        {
            matches.Add(match.Value);
        }
        return matches;
    }
}

