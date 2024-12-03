namespace AdventOfCode;
using System;

public class Day2
{
    private const string File = "../../../Day2/Day2_input.txt";

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
        int[][] input = System.IO.File.ReadLines(File).Select(n => Array.ConvertAll(n.Split(' '), int.Parse)).ToArray();
        int safeCount = 0;

        foreach (var readingArray in input)
        {
            if (SafetyCheck(readingArray.ToList()))
            {
                safeCount++;
            };
        }
        Console.WriteLine($"Day 2 Challenge 2: {safeCount}");
    }

    private bool SafetyCheck(List<int> readings)
    {
        int ascendingCount = 0;
        int descendingCount = 0;
        
        for (int index = 0; index < readings.Count; index++)
        {
            if (index != readings.Count - 1)
            {
                if (readings[index] < readings[index + 1])
                {
                    ascendingCount++;
                }
                else if (readings[index] > readings[index + 1])
                {
                    descendingCount++;
                }
            }
        }

        bool ascending = ascendingCount >= descendingCount;
        
        //Makes sure all readings are aligned from small to big, easier to find an outlier and remove it
        if (!ascending) readings.Reverse();
        
        bool recheck = false;
        
        for (int index = 0; index < readings.Count; index++) //check if initial List is Safe, if not break and split List into multiple lists with i element removed
        {
            int next = readings.ElementAtOrDefault(index + 1);
            int current = readings[index];

            if ( (next != 0) && ((current >= next) || (Math.Abs(next - current) > 3)))
            { //Unsafe case
                recheck = true;
            }
            
            if (recheck) break;
        }

        bool safeDampened = false;
        if (recheck)
        {
            List<List<int>> dampenedReadings = new List<List<int>>();
            for (int i = 0; i < readings.Count; i++)
            {
                List<int> temp = new List<int>(readings);
                temp.RemoveAt(i);
                dampenedReadings.Add(temp);
            }

            foreach (var dampenedReading in dampenedReadings)
            {
                bool breaked = false;
                for (int i = 0; i < dampenedReading.Count; i++)
                {
                    int next = dampenedReading.ElementAtOrDefault(i + 1);
                    int current = dampenedReading[i];
                    if ( (next != 0) && ((current >= next) || (Math.Abs(next - current) > 3)))
                    { //Unsafe case
                        breaked = true;
                        break;
                    }
                }
                if (!breaked)
                {
                    safeDampened = true; //code is exec even when brake
                    break;
                }
            }
        }
        return !recheck || safeDampened;
    }
    
}