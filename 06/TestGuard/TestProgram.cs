using FluentAssertions;
using Guard;

namespace TestGuard;

public class TestProgram
{
    [Fact]
    public void Test1()
    {
        var program = new Program("example.txt");
        
        var count = program.Part1();

        count.Should().Be(41);
    }
}