using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var listyIterator = new ListyIterator<string>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                string[] args = input.Split();
                string command = args[0];

                switch (command)
                {
                    case "Create":
                        listyIterator = new ListyIterator<string>(args.Skip(1).ToList());
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
