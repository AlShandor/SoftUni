
namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                        PrintPrivateFields();
                        break;
                    case "protected":
                        PrintProtectedFields();
                        break;
                    case "public":
                        PrintPublicFields();
                        break;
                    case "all":
                        PrintAllFields();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintAllFields()
        {
            var type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var fieldInfo in fields)
            {
                if (fieldInfo.IsFamily)
                {
                    Console.WriteLine($"protected {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                    continue;
                }
                Console.WriteLine($"{fieldInfo.Attributes.ToString().ToLower()} {fieldInfo.FieldType.Name} {fieldInfo.Name}");

            }
        }

        private static void PrintPublicFields()
        {
            var type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (var fieldInfo in fields)
            {
                if (fieldInfo.IsPublic)
                {
                    Console.WriteLine($"{fieldInfo.Attributes.ToString().ToLower()} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
            }
        }

        private static void PrintProtectedFields()
        {
            var type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var fieldInfo in fields)
            {
                if (fieldInfo.IsFamily)
                {
                    Console.WriteLine($"protected {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
            }
        }

        private static void PrintPrivateFields()
        {
            var type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var fieldInfo in fields)
            {
                if (fieldInfo.IsPrivate)
                {
                    Console.WriteLine($"{fieldInfo.Attributes.ToString().ToLower()} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
            }
        }
    }
}
