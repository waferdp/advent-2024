namespace _04;

public class Program
{
    private Matrix2d<char> matrix;
    private List<string> lines;

    public static void Main(string[] args)
    {
        var example1 = new Program("example.txt");        
        Console.WriteLine($"Example 1: {example1.CountXmases()}");
        
        var part1 = new Program("input.txt");
        Console.WriteLine($"Part 1: {part1.CountXmases()}");

        var example2 = new Program("example.txt");
        Console.WriteLine($"Example 2: {example2.CountCrossMases()}");

        var part2 = new Program("input.txt");
        Console.WriteLine($"Part 2: {part2.CountCrossMases()}");
    }

    public Program(string filename)
    {
        lines = File.ReadAllLines(filename).ToList();
        matrix = new Matrix2d<char>(lines.Select(l => l.ToList()).ToList(), '.');
    }


    private long CountXmases()
    {
        var count = 0L;
        for (var y = matrix.MinY; y <= matrix.MaxY; y++)
        {
            for (var x = matrix.MinX; x <= matrix.MaxX; x++)
            {
                if (matrix.Get(x, y)  == 'X')
                {
                    count += CountXmasesAt(new Pos2d(x, y));
                }
            }
        }
        return count;
    }

    private long CountCrossMases()
    {
        var count = 0L;
        for (var y = matrix.MinY; y <= matrix.MaxY; y++)
        {
            for (var x = matrix.MinX; x <= matrix.MaxX; x++)
            {
                count += IsCrossMas(new Pos2d(x, y)) ? 1 : 0;
            }
        }
        return count;

    }

    private long CountXmasesAt(Pos2d pos)
    {
        var count = 0L;
        count += IsXmas(pos, -1, -1) ? 1 : 0;
        count += IsXmas(pos, -1, 0) ? 1 : 0;
        count += IsXmas(pos, -1, 1) ? 1 : 0;
        count += IsXmas(pos, 0, -1) ? 1 : 0;
        count += IsXmas(pos, 0, 1) ? 1 : 0;
        count += IsXmas(pos, 1, -1) ? 1 : 0;
        count += IsXmas(pos, 1, 0) ? 1 : 0;
        count += IsXmas(pos, 1, 1) ? 1 : 0;
        return count;
    }

    private bool IsXmas(Pos2d xPos, int yDir, int xDir)
    {
        var rest = "XMAS";
        for(var i = 0; i < rest.Length; i++)
        {
            var mPos = new Pos2d(xPos.X + (xDir * i), xPos.Y + (yDir * i));
            var m = matrix.Get(mPos.X, mPos.Y);
            if(m != rest[i])
            {
                return false;
            }
        }
        return true;
    }

    private bool IsCrossMas(Pos2d center)
    {
        var c = matrix.Get(center.X, center.Y);

        if (c != 'A')
        {
            return false;
        }

        var ul = matrix.Get(center.X - 1, center.Y - 1);
        var ur = matrix.Get(center.X + 1, center.Y - 1);
        var ll = matrix.Get(center.X - 1, center.Y + 1);
        var lr = matrix.Get(center.X + 1, center.Y + 1);

        var ltr = $"{ul}{c}{lr}";
        var rtl = $"{ur}{c}{ll}";
        var ltrRev = new string(ltr.Reverse().ToArray());
        var rtlRev = new string(rtl.Reverse().ToArray());

        if (ltr != "MAS" && ltrRev != "MAS")
        {
            return false;
        }

        if (rtl != "MAS" && rtlRev != "MAS")
        {
            return false;
        }

        return true;
    }
    
}
