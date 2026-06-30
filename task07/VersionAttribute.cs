namespace task07;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class VersionAttribute : Attribute
{
    public int Major { get; }
    public int Minor { get; }
    public VersionAttribute(int major, int minor)
    {
        if (major < 0 || minor < 0) throw new ArgumentOutOfRangeException("Компоненты версии не могут быть отрицательными числами");
        Major = major;
        Minor = minor;
    }
}
