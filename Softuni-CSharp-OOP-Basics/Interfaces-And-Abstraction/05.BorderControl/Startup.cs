
using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        List<IIdentifiable> ids = new List<IIdentifiable>();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            GetIds(ids, command);
        }

        string fakeId = Console.ReadLine();
        PrintFakeIDs(ids, fakeId);
    }

    private static void PrintFakeIDs(List<IIdentifiable> ids, string fakeId)
    {
        foreach (var id in ids)
        {
            if (id.Id.EndsWith(fakeId))
            {
                Console.WriteLine(id.Id);
            }
        }
    }

    private static void GetIds(List<IIdentifiable> ids, string command)
    {
        string[] tokens = command.Split();

        if (tokens.Length == 3)
        {
            Citizen newCitizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
            ids.Add(newCitizen);
        }
        else if (tokens.Length == 2)
        {
            Robot newRobot = new Robot(tokens[0], tokens[1]);
            ids.Add(newRobot);
        }
    }
}
