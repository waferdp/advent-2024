namespace Pages;

public class Order
{
    public int First { get; set; }
    
    public int Second { get; set; }

    public Order(string order)
    {
        var parts = order
            .Split("|")
            .Select(p => int.Parse(p.Trim()))
            .ToList();

        First = parts[0];
        Second = parts[1];
    }

    public bool IsValid(List<int> order)
    {
        if(!order.Any(o => o == First) || !order.Any(o => o == Second))
        {
            return true;
        }

        var first = order.FindIndex(o => o == First);
        var second = order.FindIndex(o => o == Second);
        return first < second;
    }

    public List<int> Sort(List<int> order)
    {
        var first = order.FindIndex(o => o == First);
        var second = order.FindIndex(o => o == Second);

        if (first == -1 || second == -1)
        {
            return order;
        }

        if(first < second)
        {
            return order;
        }

        var temp = order[first];
        order[first] = order[second];
        order[second] = temp;

        return order;
    }
}