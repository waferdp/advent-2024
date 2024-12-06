namespace Guard;

public class Program
{
    private Matrix2d<char> matrix;

    public Program(string filename)
    {
        matrix = ReadMatrix(filename);
    }

    public long Part1()
    {
        var guard = new GuardMover(matrix);
        var count = 0;
        while (!guard.HasExited && count < 10000)
        {
            guard.Move();
            count++;
        }
        return guard.History.Count;
    }

    public static void Main(string[] args)
    {
        var program = new Program("input.txt");
        Console.WriteLine($"Part 1: {program.Part1()}");
    }
    

    private Matrix2d<char> ReadMatrix(string filename)
    {
        var lines = File.ReadLines(filename).Select(x => x.ToList()).ToList();
        return new Matrix2d<char>(lines, '.');
    }
}
