namespace AdventOfCode;
using System;

public class Day2
{
    private const string File = "C:/Personal/AdventOfCode/AdventOfCode/AdventOfCode/Day2/Day2_input.txt";

    public void Challenge1()
    {
        int[][] input = System.IO.File.ReadLines(File).Select(n => Array.ConvertAll(n.Split(' '), int.Parse)).ToArray();
        int safeCount = 0;
        
        for (int i = 0; i < input.Length; i++)
        {
            int prevValue = new int();
            bool ascending = false;
            bool safe = true;

            for (int j = 0; j < input[i].Length; j++)
            {
                if (j == 0)
                {
                    prevValue = input[i][j];
                    if (input[i][j+1] == prevValue)
                    {
                        safe = false;
                        break;
                    }
                    ascending = (input[i][j+1] > prevValue);
                    continue;
                }

                var test = input[i][j];
                if (ascending)
                {
                    if (input[i][j] > prevValue && (input[i][j] - prevValue) <= 3)
                    {
                        prevValue = input[i][j];
                        continue;
                    }
                }
                if (!ascending)
                {
                    if (input[i][j] < prevValue && (prevValue - input[i][j]) <= 3)
                    {
                        prevValue = input[i][j];
                        continue;
                    }
                }
                safe = false;
                break;
            }
            if (safe) safeCount++;
        }
        Console.WriteLine($"Day 2 Challenge 1: {safeCount}");
    }

    public void Challenge2()
    {
        
    }
    
}