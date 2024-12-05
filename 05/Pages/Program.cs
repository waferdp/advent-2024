namespace Pages;

public class Program
{
    public List<Order> Orders { get; set; }
    public List<List<int>> Updates { get; set; }

    public Program(string filename)
    {
        var lines = File.ReadAllLines(filename);
        var endOfOrder = Array.FindIndex(lines, string.IsNullOrWhiteSpace);
        var orderLines = lines[..endOfOrder];
        Orders = orderLines.Select(o => new Order(o)).ToList();
        var updates = lines[(endOfOrder + 1)..];
        Updates = updates.Select(u => u.Split(",").Select(int.Parse).ToList()).ToList();
    }

    public long Part1()
    {
        var valid = Updates.Where(u => Orders.All(o => o.IsValid(u))).ToList();
        return GetMiddleOfLists(valid).Sum();
    }

    public long Part2()
    {
        var invalids = Updates.Where(u => Orders.Any(o => !o.IsValid(u))).ToList();
        var reOrdered = new List<List<int>>();
        
        foreach(var invalid in invalids)
        {
            var sorted = invalid;
            while(Orders.Any(o => !o.IsValid(sorted)))
            {
                foreach(var order in Orders)
                {
                    sorted = order.Sort(sorted);
                }
            }
            reOrdered.Add(sorted);
        }

        return GetMiddleOfLists(reOrdered).Sum();
    }

    private List<int> GetMiddleOfLists(List<List<int>> lists)
    {
        return lists.Select(l => l[l.Count / 2]).ToList();
    }

    public static void Main(string[] args)
    {
        var p = new Program("input.txt");
        Console.WriteLine($"Part 1: {p.Part1()}");
        Console.WriteLine($"Part 2: {p.Part2()}");
    }
}
