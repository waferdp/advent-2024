namespace _02;

public class Program
{
    private readonly List<List<int>> input = [];
    
    public Program(string filename)
    {
        input = ParseInput(filename);
    }

    public long Part1()
    {
        return input.Select(IsSafe).Count(x => x);
    }

    public long Part2()
    {
        return input.Select(IsSafeWithDampener).Count(x => x);
    }

    public static void Main(string[] args)
    {
        var program = new Program("input.txt");
        //var program = new Program("example.txt");
        Console.WriteLine(program.Part1());
        Console.WriteLine(program.Part2());
    }

    private bool IsSafe(List<int> numbers)
    {
        var incDec = numbers[1].CompareTo(numbers[0]);
        for(var i = 1; i < numbers.Count; i++)
        {
            var a = numbers[i - 1];
            var b = numbers[i];

            var diff = Math.Abs(b - a);
            if (diff < 1 || diff > 3 )
            {
                return false;
            }

            if (b.CompareTo(a) != incDec)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsSafeWithDampener(List<int> numbers)
    {
        for(var i = 0; i < numbers.Count; i++)
        {
            var removed = numbers[0..i].Concat(numbers[(i+1)..]).ToList();
            if(IsSafe(removed))
            {
                return true;
            }
        }
        return false;
    }

    private List<List<int>> ParseInput(string filename)
    {
        var lines = File.ReadAllLines(filename);
        var result = new List<List<int>>();
        foreach (var line in lines)
        {
            var numbers = line
                .Split(' ')
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(int.Parse).ToList();

            result.Add(numbers);
        }

        return result;
    }
}
