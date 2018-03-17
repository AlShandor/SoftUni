
using System;

public abstract class Harvester : Machine
{
    private const int MinOreOutput = 0;
    private const int MinEnergyRequirement = 0;
    private const int MaxEnergyRequirement = 20_000;

    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < MinOreOutput)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(OreOutput)}");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < MinEnergyRequirement || value > MaxEnergyRequirement)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
            }

            this.energyRequirement = value;
        }
    }
}

