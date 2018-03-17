
using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        List<IBirthdate> ibirthdate = new List<IBirthdate>();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            GetCitizenPetBirthdates(ibirthdate, command);
        }

        string birthdate = Console.ReadLine();
        PrintCitizensAndPets(birthdate, ibirthdate);
    }

    private static void PrintCitizensAndPets(string birthdate, List<IBirthdate> ibirthdate)
    {
        foreach (var date in ibirthdate)
        {
            string[] dateTokens = date.Birthdate.Split('/');
            if (dateTokens[2] == birthdate)
            {
                Console.WriteLine(date.Birthdate);
            }
        }
    }

    private static void GetCitizenPetBirthdates(List<IBirthdate> ibirthdate, string command)
    {
        string[] tokens = command.Split();

        if (tokens[0] == "Citizen")
        {
            Citizen newCitizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
            ibirthdate.Add(newCitizen);
        }
        else if (tokens[0] == "Pet")
        {
            Pet newPet = new Pet(tokens[1], tokens[2]);
            ibirthdate.Add(newPet);
        }
    }
}
