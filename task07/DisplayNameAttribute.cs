namespace task07;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
public sealed class DisplayNameAttribute : Attribute
{
    public string DisplayName { get; }
    public DisplayNameAttribute(string display_name)
    {
        if (string.IsNullOrWhiteSpace(display_name)) throw new ArgumentException("Отображаемое имя не может быть пустым или состоять из пробелов");
        DisplayName = display_name;
    }
}
