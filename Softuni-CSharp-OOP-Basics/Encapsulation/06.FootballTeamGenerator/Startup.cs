
using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {

        Dictionary<string, Team> teams = new Dictionary<string, Team>();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            try
            {
                string[] tokens = command.Split(';');
                switch (tokens[0])
                {
                    case "Team":
                        Team newTeam = new Team(tokens[1]);
                        teams.Add(tokens[1], newTeam);
                        break;
                    case "Add":
                        if (!teams.ContainsKey(tokens[1]))
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }
                        Player newPlayer = new Player(tokens[2], int.Parse(tokens[3]),
                            int.Parse(tokens[4]), int.Parse(tokens[5]),
                            int.Parse(tokens[6]), int.Parse(tokens[7]));
                        teams[tokens[1]].AddPlayer(newPlayer);
                        break;
                    case "Remove":
                        teams[tokens[1]].RemovePlayer(tokens[2]);
                        break;
                    case "Rating":
                        if (!teams.ContainsKey(tokens[1]))
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }

                        Console.WriteLine($"{teams[tokens[1]].Name} - {teams[tokens[1]].Rating:f0}");
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
