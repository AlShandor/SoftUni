
public class Engine
{
    private string model;
    private int power;
    private int? displacement;
    private string efficiency;

    public Engine(string[] engineInfo)
    {
        Model = engineInfo[0];
        Power = int.Parse(engineInfo[1]);

        if (engineInfo.Length == 4)
        {
            Displacement = int.Parse(engineInfo[2]);
            Efficiency = engineInfo[3];
        }

        if (engineInfo.Length == 3)
        {
            int currentDisplacement;
            bool hasParsed = int.TryParse(engineInfo[2], out currentDisplacement);
            if (hasParsed)
            {
                Displacement = currentDisplacement;
            }
            else
            {
                Efficiency = engineInfo[2];
            }
        }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    public int Displacement
    {
        set { displacement = value; }
    }

    public string Efficiency { get; set; } = "n/a";

    public override string ToString()
    {
        var engineString = $"  {Model}:\n";
        engineString = string.Concat(engineString, $"    Power: {Power}\n");
        if (displacement == null)
        {
            engineString = string.Concat(engineString, $"    Displacement: n/a\n");
        }
        else
        {
            engineString = string.Concat(engineString, $"    Displacement: {displacement}\n");
        }

        engineString = string.Concat(engineString, $"    Efficiency: {Efficiency}\n");

        return engineString;
    }
}
