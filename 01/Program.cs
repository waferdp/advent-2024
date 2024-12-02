using System.IO.Compression;

namespace advent.day1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var example = new Program().GetNumbers("example.txt");
            var numbers = new Program().GetNumbers("input.txt");
            // Console.WriteLine(Part1(numbers));
            Console.WriteLine(Part2(numbers));
        }

        private (List<int>, List<int>) GetNumbers(string filename)
        {
            var lines = File
                .ReadAllLines(filename)
                .Select(r => r
                    .Split(" ")
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(int.Parse)
                    .ToList()).ToList();
            var a = lines.Select(l => l[0]).ToList();
            var b = lines.Select(l => l[1]).ToList();
            a.Sort();
            b.Sort();
            return (a, b);
        }

        static int Part1((List<int> a, List<int> b) numbers)
        {
            var a = numbers.a;
            var b = numbers.b;
            var i = 0;
            var sum = 0;
            while (i < a.Count && i < b.Count)
            {
                sum += Math.Abs(a[i] - b[i]);
                i++;
            }
            return sum;
        }

        static int Part2((List<int> a, List<int> b) numbers)
        {
            var a = numbers.a;
            var b = numbers.b;
            var i = 0;
            var sum = 0;
            while (i < a.Count && i < b.Count)
            {
                var left = a[i];
                var count = b.Count(r => r == left);
                sum += left * count;
                i++;
            }
            return sum;
        }
    }
}