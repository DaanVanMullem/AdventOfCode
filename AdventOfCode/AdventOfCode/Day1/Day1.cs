namespace AdventOfCode;

public class Day1
{

    private const string File = "../../../Day1/Day1_1_input.txt";

    public void Challenge1()
    {
        List<int> inputA = [];
        List<int> inputB = [];
        int distanceCount = 0;

        foreach (var line in System.IO.File.ReadLines(File))
        {
            var parsed = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            inputA.Add(int.Parse(parsed[0])); 
            inputB.Add(int.Parse(parsed[1]));
        }

        inputA = inputA.OrderBy(n => n).ToList();
        inputB = inputB.OrderBy(n => n).ToList();

        for (int i = 0; i < inputA.Count; i++)
        {
            int distance = Math.Abs(inputA[i] - inputB[i]);
            distanceCount += distance;
        }
        
        Console.WriteLine($"Day 1 Challenge 1: {distanceCount}");
    }
    
    public void Challenge2()
    {
        List<int> inputA = [];
        List<int> inputB = [];
        int distanceCount = 0;

        foreach (var line in System.IO.File.ReadLines(File))
        {
            var parsed = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            inputA.Add(int.Parse(parsed[0])); 
            inputB.Add(int.Parse(parsed[1]));
        }

        foreach (var value in inputA)
        {
            distanceCount += (value * inputB.Count(n => n == value));
        }
        
        Console.WriteLine($"Day 1 Challenge 2: {distanceCount}");
    }
}