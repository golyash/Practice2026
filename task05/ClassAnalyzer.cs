namespace task05;
using System;
using System.Reflection;
using System.Collections.Generic;

public class ClassAnalyzer
{
    private Type _type;

    public ClassAnalyzer(Type type)
    {
        _type = type;
    }

    public IEnumerable<string> GetPublicMethods()
    {
        var public_methods = _type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).Select(m => m.Name);
        return public_methods;
    }

    public IEnumerable<string> GetMethodParams(string methodname)
    {
        var method = _type.GetMethod(methodname);
        if (method == null) return Enumerable.Empty<string>();

        var first_el = new[] { method.ReturnType.Name };
        var formatted_parms = method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}");
        return first_el.Concat(formatted_parms);
    }

    public IEnumerable<string> GetAllFields()
    {
        var all_fields = _type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).Select(f => f.Name);
        return all_fields;
    }

    public IEnumerable<string> GetProperties()
    {
        var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static ).Select(p => p.Name);
        return properties;
    }

    public bool HasAttribute<T>() where T : Attribute
    {
        var has_attribute = _type.GetCustomAttributes(typeof(T), true).Any();
        return has_attribute;
    }
}
