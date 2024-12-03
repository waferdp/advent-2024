using System.Text.RegularExpressions;

namespace _03;

public class Program
{
    public static void Main(string[] args)
    {
        var example = Part1("example.txt");
        var part1 =  Part1("input.txt");
        
        Console.WriteLine($"Example 1: {example}");
        Console.WriteLine($"Part 1: {part1}");

        var example2 = Part2("example2.txt");
        var part2 = Part2("input.txt");

        Console.WriteLine($"Example 2: {example2}");
        Console.WriteLine($"Part 2: {part2}");

    }

    private static long Part1(string filename)
    {
        var lines = File.ReadAllLines(filename);
        return SumStatements(string.Join("", lines));
    }

    private static long Part2(string filename)
    {
        var lines = File.ReadAllLines(filename);
        var input = string.Join("", lines);
        var parsed = ParseNext(input);

        return SumStatements(parsed);
    }

    private static string ParseNext(string input)
    {
        if(string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        var nextDont = input.Split("don't()");
        if (nextDont.Length == 1)
        {
            return input;
        }

        var rest = string.Join("don't()", nextDont[1 ..]);
        var nextDo = rest.Split("do()");
        if (nextDo.Length == 1)
        {
            return nextDont[0];
        }

        var next = string.Join("do()", nextDo[1 ..]);
        return nextDont[0] + ParseNext(next);
    }

    private static long SumStatements(string input)
    {
        var parsed = GetMultiplicationStatements(input);
        var sum = parsed.Select(groups => groups).Sum(m => m.left * m.right);
        return sum;
    }

    private static List<(int left, int right)> GetMultiplicationStatements(string input)
    {
        var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
        var matches = regex.Matches(input);
        
        return matches.Select(m => (int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value))).ToList();
    }
}
