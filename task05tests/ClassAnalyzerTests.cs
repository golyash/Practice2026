using task05;
namespace task05tests;

public class TestClass
{
    public int PublicField;
    private string _privateField = "";
    public int Property { get; set; }

    public void Method() { }

    public string FullMethod(int num, double percent) => "test";
}

[Serializable]
public class AttributedClass { }

public class ClassAnalyzerTests
{
    [Fact]
    public void GetPublicMethods_ReturnsCorrectMethods()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var methods = analyzer.GetPublicMethods();

        Assert.Contains("Method", methods);
        Assert.Contains("FullMethod", methods);
    }

    [Fact]
    public void GetMethodParams_ReturnsTypeAndParameters_ForMethod()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var parms = analyzer.GetMethodParams("Method");

        Assert.Single(parms);
        Assert.Contains("Void", parms);
    }

    [Fact]
    public void GetMethodParams_ReturnsTypeAndParameters_ForFullMethod()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var parms = analyzer.GetMethodParams("FullMethod");

        Assert.Equal(3, parms.Count());
        Assert.Equal("String", parms.First());
        Assert.Contains("Int32 num", parms);
        Assert.Contains("Double percent", parms);
    }

    [Fact]
    public void GetMethodParams_ReturnsTypeAndParameters_ForNoExistentMethod()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var parms = analyzer.GetMethodParams("NoExistentMethod");

        Assert.Empty(parms);
    }

    [Fact]
    public void GetAllFields_IncludesPrivateFields()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var fields = analyzer.GetAllFields();

        Assert.Contains("PublicField", fields);
        Assert.Contains("_privateField", fields);
    }

    [Fact]
    public void GetProperties_ReturnsCorrectProperties()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var properties = analyzer.GetProperties();

        Assert.Single(properties);
        Assert.Contains("Property", properties);
    }

    [Fact]
    public void HasAttribute_ReturnsTrue_ForAttributedClass()
    {
        var analyzer = new ClassAnalyzer(typeof(AttributedClass));

        var has_attribute = analyzer.HasAttribute<SerializableAttribute>();

        Assert.True(has_attribute);
    }

    [Fact]
    public void HasAttribute_ReturnsTrue_ForTestClass()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));

        var has_attribute = analyzer.HasAttribute<SerializableAttribute>();

        Assert.False(has_attribute);
    }
}
