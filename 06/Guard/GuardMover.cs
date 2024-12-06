namespace Guard;

public class GuardMover(Matrix2d<char> matrix)
{
    public List<(int x, int y)> History { get; set; } = [];
    public bool HasExited { get; set; } = false;
    private (int x, int y) guardPostion { get; set; } = matrix.Find('^') ?? throw new Exception("Guard not found");

    public void Move()
    {
        var nextPosition = GetNextPosition();
        if (matrix.Get(nextPosition) == '#')
        {
            TurnRight();
            return;
        }
        
        if(!History.Contains(guardPostion))
        {
            History.Add(guardPostion);
        }

        if(!matrix.IsInside(nextPosition.x, nextPosition.y))
        {
            HasExited = true;
            return;
        }

        RedrawGuard(guardPostion, nextPosition);
        guardPostion = nextPosition;
    }

    private void RedrawGuard((int x, int y) a, (int x, int y) b)
    {
        var orientation = matrix.Get(a);
        matrix.Set(a.x, a.y, '.');
        matrix.Set(b.x, b.y, orientation);
    }

    private (int x, int y) GetNextPosition()
    {
        var (x, y) = guardPostion;
        switch (matrix.Get(guardPostion))
        {
            case '^':
                return (x, y - 1);
            case 'v':
                return (x, y + 1);
            case '<':
                return (x - 1, y);
            case '>':
                return (x + 1, y);
            default:
                throw new Exception("Invalid guard orientation");
        }
    }

    private void TurnRight()
    {
        var (x, y) = guardPostion;
        switch (matrix.Get(guardPostion))
        {
            case '^':
                matrix.Set(x, y, '>');
                break;
            case 'v':
                matrix.Set(x, y, '<');
                break;
            case '<':
                matrix.Set(x, y, '^');
                break;
            case '>':
                matrix.Set(x, y, 'v');
                break;
            default:
                throw new Exception("Invalid guard orientation");
        }
    }
    
}