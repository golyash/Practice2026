using task03;
namespace task03tests;

public class IteratorTests
{
    [Fact]
    public void CustomCollection_GetEnumerator_EmptyCollection_ReturnsEmpty()
    {
        var collection = new CustomCollection<int>();
        var result = new List<int>();
        foreach (var item in collection)
        {
            result.Add(item);
        }

        Assert.Empty(result);
    }

    [Fact]
    public void CustomCollection_GetEnumerator_ReturnsAllItems()
    {
        var collection = new CustomCollection<int>();
        collection.Add(12);
        collection.Add(34);

        var result = new List<int>();
        foreach (var item in collection)
        {
            result.Add(item);
        }

        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { 12, 34 }, result);
    }

    [Fact]
    public void CustomCollection_GetEnumerator_WithString_ReturnsAllItems()
    {
        var collection = new CustomCollection<string>();
        collection.Add("Яблоко");
        collection.Add("Банан");

        var result = new List<string>();
        foreach (var item in collection)
        {
            result.Add(item);
        }

        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { "Яблоко", "Банан" }, result);
    }

    [Fact]
    public void CustomCollection_GetEnumerator_Remove_ReturnsTrueOrFalseAndRemovesItem()
    {
        var collection = new CustomCollection<int>();
        collection.Add(5);
        collection.Add(14);

        bool first_removed = collection.Remove(14);
        bool second_removed = collection.Remove(100);
        var result = collection.ToList();

        Assert.True(first_removed);
        Assert.False(second_removed);
        Assert.Equal(new[] { 5 }, result);
    }

    [Fact]
    public void CustomCollection_GetEnumerator_Remove_WithString_ReturnsTrueOrFalseAndRemovesItem()
    {
        var collection = new CustomCollection<string>();
        collection.Add("Петя");
        collection.Add("Ваня");

        bool first_removed = collection.Remove("Ваня");
        bool second_removed = collection.Remove("Даня");
        var result = collection.ToList();

        Assert.True(first_removed);
        Assert.False(second_removed);
        Assert.Equal(new[] { "Петя" }, result);
    }

    [Fact]
    public void GetReverseEnumerator_ReturnsItemsInReverseOrder()
    {
        var collection = new CustomCollection<int>();
        collection.Add(31);
        collection.Add(15);

        var result = collection.GetReverseEnumerator().ToList();
        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { 15, 31 }, result);
    }

    [Fact]
    public void GetReverseEnumerator_WithString_ReturnsItemsInReverseOrder()
    {
        var collection = new CustomCollection<string>();
        collection.Add("Арбуз");
        collection.Add("Банан");
        collection.Add("Яблоко");

        var result = collection.GetReverseEnumerator().ToList();
        Assert.Equal(3, result.Count);
        Assert.Equal(new[] { "Яблоко", "Банан", "Арбуз" }, result);
    }

    [Fact]
    public void GenerateSequence_ReturnsCorrectSequence()
    {
        var sequence = CustomCollection<int>.GenerateSequence(10, 5).ToList();
        Assert.Equal(5, sequence.Count);
        Assert.Equal(new[] { 10, 11, 12, 13, 14 }, sequence);
    }

    [Fact]
    public void FilterAndSort_ReturnsFilteredAndSortedItems()
    {
        var collection = new CustomCollection<int>();
        collection.Add(1);
        collection.Add(25);
        collection.Add(3);
        collection.Add(115);
        collection.Add(8);
        collection.Add(2);

        var result = collection.FilterAndSort(x => x > 5, x => x).ToList();
        Assert.Equal(3, result.Count);
        Assert.Equal(new[] { 8, 25, 115 }, result);
    }
}
