
using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        var command = Console.ReadLine();
        while (command != "Shutdown")
        {
            string[] tokens = command.Split();

            switch (tokens[0])
            {
                case "RegisterHarvester":
                    Console.WriteLine(this.draftManager.RegisterHarvester(tokens.Skip(1).ToList()));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(this.draftManager.RegisterProvider(tokens.Skip(1).ToList()));
                    break;
                case "Day":
                    Console.WriteLine(this.draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(this.draftManager.Mode(tokens.Skip(1).ToList()));
                    break;
                case "Check":
                    Console.WriteLine(this.draftManager.Check(tokens.Skip(1).ToList()));
                    break;
                default:
                    break;
            }

            command = Console.ReadLine();
        }

        Console.WriteLine(this.draftManager.ShutDown());
    }
}

