
using System;
using System.Collections.Generic;

public class TyreFactory
{
    public Tyre GetTyre(List<string> args)
    {
        string type = args[0];
        double tyreHardness = double.Parse(args[1]);
        if (type == "Ultrasoft")
        {
            double grip = double.Parse(args[2]);
            return new UltrasoftTyre(type, tyreHardness, grip);
        }

        if (type == "Hard")
        {
            return new HardTyre(type, tyreHardness);
        }

        throw new ArgumentException("Cannot create tyre");
    }
}

