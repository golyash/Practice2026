namespace task07;

[DisplayName("Пример класса")]
[Version(1, 0)]
public class SampleClass
{
    [DisplayName("Числовое свойство")]
    public int Number { get; set; }
    [DisplayName("Тестовый метод")]
    public void TestMethod() {}
}

[DisplayName("")]
[Version(-1, 2)]
public class InvalidSampleClass
{
    [DisplayName("   ")]
    public int BadProperty { get; set; }
}

public class ClassWithOutAttribute
{
    public int PropertyWithOutAttribute { get; set; }
    public void MethodWithOutAttribute() {}
}
