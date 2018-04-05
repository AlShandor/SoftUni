namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);
            ConstructorInfo ci =
                type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(int) }, null);

            var box = (BlackBoxInteger)ci.Invoke(new object[] { 0 });

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split('_');
                string methodName = args[0];
                int parameterValue = int.Parse(args[1]);
                MethodInfo methodInfo = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                methodInfo.Invoke(box, new object[] { parameterValue });

                var result = (int)type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(box);
                Console.WriteLine(result);
            }

        }
    }
}
