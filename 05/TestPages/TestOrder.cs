using FluentAssertions;
using Pages;

namespace TestPages;

public class TestOrder
{
    [Fact]
    public void IsValid_ValidOrder_True()
    {
        var order = new Order("1|2");
        
        var valid = order.IsValid([1, 3, 5, 2]);
        
        valid.Should().BeTrue();
    }

    [Fact]
    public void IsValid_InvalidOrder_False()
    {
        var order = new Order("1|2");
        
        var valid = order.IsValid([2, 3, 1, 5]);
        
        valid.Should().BeFalse();
    }

    [Fact]
    public void IsValid_Missing_True()
    {
        var order = new Order("66|15");
        
        var valid = order.IsValid([3, 15, 5]);
        
        valid.Should().BeTrue();
    }

    [Fact]
    public void Sort_WrongOrder_Different()
    {
        var order = new Order("1|2");
        
        var sorted = order.Sort([2, 1, 3, 5]);
        
        sorted.Should().BeEquivalentTo([1, 2, 3, 5]);
    }

    [Fact]
    public void Sort_RightOrder_Same()
    {
        var order = new Order("1|2");
        
        var sorted = order.Sort([1, 3, 2, 5]);
        
        sorted.Should().BeEquivalentTo([1, 3, 2, 5]);
    }
}