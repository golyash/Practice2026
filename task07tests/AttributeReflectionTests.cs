using System.Reflection;
using task07;
namespace task07tests;

public class AttributeReflectionTests
{
    [Fact]
    public void SampleClass_HasDisplayNameAttribute()
    {
        var type = typeof(SampleClass);
        var attribute = type.GetCustomAttribute<DisplayNameAttribute>();
        Assert.NotNull(attribute);
        Assert.Equal("Пример класса", attribute.DisplayName);
    }

    [Fact]
    public void SampleClass_HasVersionAttribute()
    {
        var type = typeof(SampleClass);
        var attribute = type.GetCustomAttribute<VersionAttribute>();
        Assert.NotNull(attribute);
        Assert.Equal(1, attribute.Major);
        Assert.Equal(0, attribute.Minor);
    }

    [Fact]
    public void SampleClassMethod_HasDisplayNameAttribute()
    {
        var method = typeof(SampleClass).GetMethod("TestMethod");
        Assert.NotNull(method);
        var attribute = method.GetCustomAttribute<DisplayNameAttribute>();
        Assert.NotNull(attribute);
        Assert.Equal("Тестовый метод", attribute.DisplayName);
    }

    [Fact]
    public void SampleClassProperty_HasDisplayNameAttribute()
    {
        var property = typeof(SampleClass).GetProperty("Number");
        Assert.NotNull(property);
        var attribute = property.GetCustomAttribute<DisplayNameAttribute>();
        Assert.NotNull(attribute);
        Assert.Equal("Числовое свойство", attribute.DisplayName);
    }

    [Fact]
    public void ReflectionHelper_ForSampleClass_ShouldGenerateCorrectResult()
    {
        string result = ReflectionHelper.PrintTypeInfo(typeof(SampleClass));

        Assert.Contains("Анализируем тип: SampleClass", result);
        Assert.Contains("Отображаемое имя класса: Пример класса", result);
        Assert.Contains("Версия класса: 1.0", result);
        Assert.Contains("Метод с именем TestMethod помечен как: Тестовый метод", result);
        Assert.Contains("Свойство с именем Number помечено как: Числовое свойство", result);
    }

    [Fact]
    public void ReflectionHelper_ForClassWithOutAttribute_ShouldGenerateCorrectResult()
    {
        string result = ReflectionHelper.PrintTypeInfo(typeof(ClassWithOutAttribute));

        Assert.Contains("Анализируем тип: ClassWithOutAttribute", result);
        Assert.DoesNotContain("Отображаемое имя класса:", result);
        Assert.DoesNotContain("Версия класса:", result);
        Assert.DoesNotContain("Метод с именем:", result);
        Assert.DoesNotContain("Свойство с именем", result);
    }

    [Fact]
    public void InvalidSampleClass_ClassWithEmptyDisplayName_TryCatch()
    {
        var type = typeof(InvalidSampleClass);
        try
        {
            type.GetCustomAttribute<DisplayNameAttribute>();
            Assert.Fail("Код не выбросил исключение ArgumentException");
        }
        catch (ArgumentException) {}
    }

    [Fact]
    public void InvalidSampleClass_ClassWithNegativeVersion_TryCatch()
    {
        var type = typeof(InvalidSampleClass);
        try
        {
            type.GetCustomAttribute<VersionAttribute>();
            Assert.Fail("Код не выбросил исключение ArgumentOutOfRangeException");
        }
        catch (ArgumentOutOfRangeException) {}
    }

    [Fact]
    public void InvalidSampleClass_PropertyWithWhitespaceDisplayName_TryCatch()
    {
        var property = typeof(InvalidSampleClass).GetProperty("BadProperty");
        Assert.NotNull(property);
        try
        {
            property.GetCustomAttribute<DisplayNameAttribute>();
            Assert.Fail("Код не выбросил исключение ArgumentException");
        }
        catch (ArgumentException) {}
    }
}
