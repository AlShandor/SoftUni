using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var stack = new Stack<string>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                string[] args = input.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];
                switch (command)
                {
                    case "Push":
                        stack.Push(args.Skip(1).ToList());
                        break;
                    case "Pop":
                        stack.Pop();
                        break;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        foreach (var element in stack)
        {
            Console.WriteLine(element);
        }

        foreach (var element in stack)
        {
            Console.WriteLine(element);
        }
    }
}
