
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Mine
public class DraftManager
{
    private string currentMode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.currentMode = "Full";
        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            this.harvesters.Add(harvesterFactory.GetHarvester(arguments));
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            this.providers.Add(providerFactory.GetProvider(arguments));
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }

    public string Day()
    {
        this.totalStoredEnergy += providers.Select(e => e.EnergyOutput).Sum();
        double dailyProvidedEnergy = providers.Select(p => p.EnergyOutput).Sum();
        double dailyRequiredEnergy = harvesters.Select(h => h.EnergyRequirement).Sum();
        double dailyOreOutput = harvesters.Select(h => h.OreOutput).Sum();

        if (this.currentMode == "Half")
        {
            dailyRequiredEnergy *= 0.6;
            dailyOreOutput *= 0.5;
        }
        else if (this.currentMode == "Energy")
        {
            dailyRequiredEnergy = 0;
            dailyOreOutput = 0;
        }

        if (dailyRequiredEnergy <= this.totalStoredEnergy)
        {
            this.totalStoredEnergy -= dailyRequiredEnergy;
            this.totalMinedOre += dailyOreOutput;
            return GetDaySummary(dailyProvidedEnergy, dailyOreOutput);
        }
        else
        {
            return GetDaySummary(dailyProvidedEnergy, 0);
        }
    }

    private string GetDaySummary(double dailyProvidedEnergy, double dailyOreOutput)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {dailyProvidedEnergy}")
            .AppendLine($"Plumbus Ore Mined: {dailyOreOutput}");

        string result = sb.ToString().TrimEnd();

        return result;
    }

    public string Mode(List<string> arguments)
    {
        this.currentMode = arguments[0];

        return $"Successfully changed working mode to {arguments[0]} Mode";
    }

    public string Check(List<string> arguments)
    {
        if (harvesters.Any(x => x.Id == arguments[0]))
        {
            return this.harvesters.First(x => x.Id == arguments[0]).ToString();
        }
        else if (providers.Any(x => x.Id == arguments[0]))
        {
            return this.providers.First(x => x.Id == arguments[0]).ToString();
        }

        return $"No element found with id - {arguments[0]}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown")
            .AppendLine($" Total Energy Stored: {this.totalStoredEnergy}")
            .AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        string result = sb.ToString().TrimEnd();

        return result;
    }
}

