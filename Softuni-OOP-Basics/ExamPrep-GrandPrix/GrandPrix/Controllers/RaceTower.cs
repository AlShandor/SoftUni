
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private int lapsNumber;
    private int trackLength;
    private int currentLap;
    private string currentWeather;
    private List<Driver> activeDrivers;
    private List<string> eliminatedDrivers;
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;


    public RaceTower()
    {
        this.currentWeather = "Sunny";
        this.activeDrivers = new List<Driver>();
        this.eliminatedDrivers = new List<string>();
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
    }

    public int CurrentLap => currentLap;
    public List<Driver> ActiveDrivers => this.activeDrivers;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Driver driver = this.driverFactory.GetDriver(commandArgs);
            if (driver != null)
            {
                activeDrivers.Add(driver);
            }
        }
        catch
        {
            return;
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string driverName = commandArgs[1];
        Driver driver = activeDrivers.FirstOrDefault(d => d.Name == driverName);
        driver.TotalTime += 20;

        if (commandArgs[0] == "Refuel")
        {
            driver.Car.FuelAmount += double.Parse(commandArgs[2]);
        }

        if (commandArgs[0] == "ChangeTyres")
        {
            driver.Car.Tyre = tyreFactory.GetTyre(commandArgs.Skip(2).ToList());
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder sb = new StringBuilder();
        int numOfLaps = int.Parse(commandArgs[0]);
        if (numOfLaps > this.lapsNumber - currentLap)
        {
            throw new ArgumentException($"There is no time!On lap {this.currentLap}");
        }

        for (int currentLap = 0; currentLap < numOfLaps; currentLap++)
        {
            // calculate each driver TotalTime, Fuel, DegradeTyre
            foreach (var activeDriver in activeDrivers)
            {
                activeDriver.CalculateSpeed();
                activeDriver.TotalTime += 60 / (this.trackLength / activeDriver.Speed);

                //eliminate driver because of Fuel or Tyre
                try
                {
                    activeDriver.Car.FuelAmount -= this.trackLength * activeDriver.FuelConsumptionPerKm;
                    activeDriver.Car.Tyre.DegradeTyre();
                }
                catch (ArgumentException ae)
                {
                    activeDrivers.Remove(activeDriver);
                    eliminatedDrivers.Add(ae.Message);
                }
            }

            // Overtaking

            // order drivers from slowest to fastest
            activeDrivers = activeDrivers.OrderByDescending(d => d.TotalTime).ToList();
            for (int i = 0; i < activeDrivers.Count - 1; i++)
            {
                //  special cases of overtaking

                // case 1
                if (activeDrivers[i].GetType().Name == "AgressiveDriver"
                    && activeDrivers[i].Car.Tyre.Name == "Ultrasoft"
                    && activeDrivers[i].TotalTime - activeDrivers[i + 1].TotalTime < 3)
                {
                    //Crash
                    if (this.currentWeather == "Foggy")
                    {
                        eliminatedDrivers.Add($"{activeDrivers[i].Name} Crashed");
                        activeDrivers.Remove(activeDrivers[i]);
                        continue;
                    }

                    sb.AppendLine($"{activeDrivers[i].Name} has overtaken {activeDrivers[i + 1].Name} on lap {this.currentLap}.");
                    activeDrivers[i].TotalTime -= 3;
                    activeDrivers[i + 1].TotalTime += 3;
                    i++;
                }

                // case 2
                if (activeDrivers[i].GetType().Name == "EnduranceDriver"
                    && activeDrivers[i].Car.Tyre.Name == "Hard"
                    && activeDrivers[i].TotalTime - activeDrivers[i + 1].TotalTime < 3)
                {
                    // Crash
                    if (this.currentWeather == "Rainy")
                    {
                        eliminatedDrivers.Add($"{activeDrivers[i].Name} Crashed");
                        activeDrivers.Remove(activeDrivers[i]);
                        continue;
                    }

                    sb.AppendLine($"{activeDrivers[i].Name} has overtaken {activeDrivers[i + 1].Name} on lap {this.currentLap}.");
                    activeDrivers[i].TotalTime -= 3;
                    activeDrivers[i + 1].TotalTime += 3;
                    i++;
                }

                // normal overtaking
                if (activeDrivers[i].TotalTime - activeDrivers[i + 1].TotalTime < 2)
                {
                    sb.AppendLine($"{activeDrivers[i].Name} has overtaken {activeDrivers[i + 1].Name} on lap {this.currentLap}.");
                    activeDrivers[i].TotalTime -= 2;
                    activeDrivers[i + 1].TotalTime += 2;
                    i++;
                }

            }

            this.currentLap++;
        }

        string result = sb.ToString().TrimEnd();

        return result;
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {this.currentLap}/{this.lapsNumber}");

        int position = 1;
        foreach (var activeDriver in activeDrivers.OrderBy(d => d.TotalTime))
        {
            sb.AppendLine($"{position} {activeDriver.Name} {activeDriver.TotalTime:f3}");
            position++;
        }

        foreach (var eliminatedDriver in eliminatedDrivers)
        {
            sb.AppendLine($"{position} {eliminatedDriver}");
            position++;
        }

        string result = sb.ToString().TrimEnd();

        return result;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.currentWeather = commandArgs[0];
    }

}

