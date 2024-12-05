using FluentAssertions;
using Pages;

namespace TestPages;

public class TestProgram
{
    [Fact]
    public void TestOrderParsing()
    {
        var p = new Program("example.txt");
        p.Orders[5].First.Should().Be(61);
        p.Orders[5].Second.Should().Be(13);
        p.Orders.Count.Should().Be(21);
    }

    [Fact]
    public void TestUpdateParsing()
    {
        var p = new Program("example.txt");
        p.Updates[5][0].Should().Be(97);
        p.Updates[5][1].Should().Be(13);
        p.Updates.Count.Should().Be(6);
    }

    [Fact]
    public void TestPart1()
    {
        var p = new Program("example.txt");
        p.Part1().Should().Be(143L);
    }

    [Fact]
    public void TestPart2()
    {
        var p = new Program("example.txt");
        p.Part2().Should().Be(123L);
    }
}