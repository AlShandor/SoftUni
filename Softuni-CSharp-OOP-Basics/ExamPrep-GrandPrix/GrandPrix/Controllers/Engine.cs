
using System;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine()
    {
        this.raceTower = new RaceTower();
    }

    public void Run()
    {
        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());
        raceTower.SetTrackInfo(lapsNumber, trackLength);

        while (raceTower.CurrentLap != lapsNumber)
        {
            string[] commandTokens = Console.ReadLine().Split();

            switch (commandTokens[0])
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(commandTokens.Skip(1).ToList());
                    break;
                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    try
                    {
                        string lapsResult = this.raceTower.CompleteLaps(commandTokens.Skip(1).ToList());
                        if (lapsResult != String.Empty)
                        {
                            Console.WriteLine(lapsResult);
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                    
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(commandTokens.Skip(1).ToList());
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(commandTokens.Skip(1).ToList());
                    break;
                default:
                    break;
            }
        }

        Driver winner = this.raceTower.ActiveDrivers.OrderByDescending(d => d.TotalTime).FirstOrDefault();
        Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.");
    }
}

