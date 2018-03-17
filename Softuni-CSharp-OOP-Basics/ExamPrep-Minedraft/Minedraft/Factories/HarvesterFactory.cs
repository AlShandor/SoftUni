
using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester GetHarvester(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]);

        if (type == "Hammer")
        {
            return new HammerHarvester(id, oreOutput, energyRequirement);
        }
        else if (type == "Sonic")
        {
            int sonicFactor = int.Parse(args[4]);
            return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }
        else
        {
            throw new ArgumentException("Harvester is not registered!");
        }
    }
}

