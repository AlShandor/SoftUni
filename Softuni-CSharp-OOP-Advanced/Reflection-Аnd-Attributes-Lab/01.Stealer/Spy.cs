
using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] requestedFields)
    {

        var type = Type.GetType(className);
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        StringBuilder stringBuilder = new StringBuilder();
        Object instance = Activator.CreateInstance(type, new object[] { });

        stringBuilder.AppendLine($"Class under investigation: {type}");

        foreach (var field in fields.Where(f => requestedFields.Contains(f.Name)))
        {
            stringBuilder.AppendLine(field.Name + " = " + field.GetValue(instance));
        }

        var result = stringBuilder.ToString().Trim();

        return result;
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var type = Type.GetType(className);

        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();
        foreach (var field in fields)
        {
            if (field.IsPublic)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
        }

        foreach (var method in methods)
        {
            if (method.IsPrivate && method.Name.StartsWith("get"))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
        }

        foreach (var method in methods)
        {
            if (method.IsPublic && method.Name.StartsWith("set"))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
        }

        var result = sb.ToString().Trim();
        return result;
    }

    public string RevealPrivateMethods(string className)
    {
        var type = Type.GetType(className);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {type}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (var method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }

        var result = sb.ToString().Trim();

        return result;
    }

    public string CollectGettersAndSetters(string className)
    {
        var type = Type.GetType(className);
        var methods = type.GetMethods(BindingFlags.Instance | 
                                      BindingFlags.NonPublic |
                                      BindingFlags.Public);
        StringBuilder sb = new StringBuilder();

        foreach (var method in methods)
        {
            if (method.Name.StartsWith("get"))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
        }

        foreach (var method in methods)
        {
            if (method.Name.StartsWith("set"))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
        }

        var result = sb.ToString().Trim();

        return result;
    }
}

