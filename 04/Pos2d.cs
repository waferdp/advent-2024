namespace _04;

public class Pos2d
{
    public int X { get; set; }
    public int Y { get; set; }

    public Pos2d(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}