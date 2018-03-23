
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= sonicFactor;
    }

    public int SonicFactor
    {
        get { return this.sonicFactor; }
        private set { this.sonicFactor = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Sonic Harvester - {this.Id}")
            .AppendLine($"  Ore Output: {this.OreOutput}")
            .AppendLine($"  Energy Requirement: {this.EnergyRequirement}");

        string result = sb.ToString().TrimEnd();
        return result;
    }
}

