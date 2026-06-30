using System.Reflection;
using System.Text;

namespace task07;

public static class ReflectionHelper
{
    public static string PrintTypeInfo(Type type)
    {
        if (type == null) throw new ArgumentNullException("Тип для анализа не может быть null");
        var result = new StringBuilder();
        result.Append($"Анализируем тип: {type.Name}");

        var class_display_name = type.GetCustomAttribute<DisplayNameAttribute>();
        if (class_display_name != null) result.AppendLine($"Отображаемое имя класса: {class_display_name.DisplayName}");

        var class_version = type.GetCustomAttribute<VersionAttribute>();
        if (class_version != null) result.AppendLine($"Версия класса: {class_version.Major}.{class_version.Minor}");

        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        foreach(MethodInfo method in methods)
        {
            var method_display_name = method.GetCustomAttribute<DisplayNameAttribute>();
            if (method_display_name != null) result.AppendLine($"Метод с именем {method.Name} помечен как: {method_display_name.DisplayName} ");
        }

        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        foreach(PropertyInfo property in properties)
        {
            var property_display_name = property.GetCustomAttribute<DisplayNameAttribute>();
            if (property_display_name != null) result.AppendLine($"Свойство с именем {property.Name} помечено как: {property_display_name.DisplayName} ");
        }
        return result.ToString();
    }
}
