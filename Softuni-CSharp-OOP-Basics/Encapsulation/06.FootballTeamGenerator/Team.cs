
using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private Dictionary<string, Player> players = new Dictionary<string, Player>();

    public Team(string name)
    {
        Name = name;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value == String.Empty || value == null || value == " ")
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }
    public void AddPlayer(Player newPlayer)
    {
        players.Add(newPlayer.Name, newPlayer);
    }
    public void RemovePlayer(string playerName)
    {
        if (!players.ContainsKey(playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {Name} team.");
        }

        players.Remove(playerName);
    }
    public double Rating
    {
        get
        {
            if (players.Count == 0)
            {
                return 0;
            }
            return players.Select(p => p.Value.OverallSkillLevel).Average();
        }
    }
}