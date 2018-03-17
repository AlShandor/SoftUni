
using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        Dictionary<string, Citizen> citizens = new Dictionary<string, Citizen>();
        Dictionary<string, Rebel> rebels = new Dictionary<string, Rebel>();
        List<IBuyer> iBuyers = new List<IBuyer>();

        int numOfPeople = int.Parse(Console.ReadLine());
        for (int i = 0; i < numOfPeople; i++)
        {
            GetBuyers(citizens, rebels, iBuyers);
        }

        string name;
        name = PersonsBuyFood(citizens, rebels);

        PrintFoodBought(iBuyers);
    }

    private static void PrintFoodBought(List<IBuyer> iBuyers)
    {
        Console.WriteLine(iBuyers.Select(x => x.Food).Sum());
    }

    private static string PersonsBuyFood(Dictionary<string, Citizen> citizens, Dictionary<string, Rebel> rebels)
    {
        string name;
        while ((name = Console.ReadLine()) != "End")
        {
            if (citizens.ContainsKey(name))
            {
                citizens[name].BuyFood();
            }

            if (rebels.ContainsKey(name))
            {
                rebels[name].BuyFood();
            }
        }

        return name;
    }

    private static void GetBuyers(Dictionary<string, Citizen> citizens, Dictionary<string, Rebel> rebels, List<IBuyer> iBuyers)
    {
        string[] tokens = Console.ReadLine().Split();
        if (tokens.Length == 4)
        {
            Citizen newCitizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
            citizens.Add(newCitizen.Name, newCitizen);
            iBuyers.Add(newCitizen);
        }
        else if (tokens.Length == 3)
        {
            Rebel newRebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
            rebels.Add(newRebel.Name, newRebel);
            iBuyers.Add(newRebel);
        }
    }
}

