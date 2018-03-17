
using System;
using System.Collections.Generic;

public class ProviderFactory
{
    public Provider GetProvider(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double energyOutput = double.Parse(args[2]);

        if (type == "Pressure")
        {
            return new PressureProvider(id, energyOutput);
        }
        else if (type == "Solar")
        {
            return new SolarProvider(id, energyOutput);
        }
        else
        {
            throw new ArgumentException("Provider not registered!");
        }
    }
}

