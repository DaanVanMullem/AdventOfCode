
using System.Linq;

namespace AdventOfCode;

public class Day4
{
    private const string File = "../../../Day4/Day4_input.txt";
    public void Challenge1()
    {
        List<List<char>> chars = new List<List<char>>();
        
        foreach (var line in System.IO.File.ReadLines(File))
        {
            chars.Add(line.ToCharArray().ToList()); 
        }

        List<List<char>> charsT = new List<List<char>>(chars).AsEnumerable().Reverse().Select(l => l.AsEnumerable().Reverse().ToList()).ToList();
        
        Console.WriteLine(string.Join("", chars[1]));
        Console.WriteLine(string.Join("", charsT[^2]));
        
        int countLRB = XmasCounter(chars);
        int countRLT = XmasCounter(charsT);
        
        Console.WriteLine($"Day 4 Challenge 1: {countLRB+countRLT}");
    }

    private int XmasCounter(List<List<char>> chars)
    {
        int xmasCounter = 0;

        for (int i = 0; i <= chars.Count-4; i++)
        {
            for (int j = 0; j <= chars[i].Count-4; j++)
            {
                if (chars[i][j] == 'X' && chars[i][j+1] == 'M' && chars[i][j+2] == 'A' && chars[i][j+3] == 'S')
                {
                    xmasCounter++;
                }
                
                if (chars[i][j] == 'X' && chars[i+1][j+1] == 'M' && chars[i+2][j+2] == 'A' && chars[i+3][j+3] == 'S')
                {
                    xmasCounter++;
                }
                
                if (chars[i][j] == 'X' && chars[i+1][j] == 'M' && chars[i+2][j] == 'A' && chars[i+3][j] == 'S')
                {
                    xmasCounter++;
                }

                if (i > 2)
                {
                    if (chars[i][j] == 'X' && chars[i-1][j+1] == 'M' && chars[i-2][j+2] == 'A' && chars[i-3][j+3] == 'S')
                    {
                        xmasCounter++;
                    }
                }
            }
        }
        return xmasCounter;
    }
    
}