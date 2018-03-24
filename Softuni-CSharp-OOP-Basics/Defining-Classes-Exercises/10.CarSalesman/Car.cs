
using System.Collections.Generic;

public class Car
{
    private string model;
    private int? weight;
    private string color;
    private Engine engine;

    public Car(string[] carInfo, Dictionary<string, Engine> engines)
    {
        Model = carInfo[0];
        engine = engines[carInfo[1]];

        if (carInfo.Length == 4)
        {
            Weight = int.Parse(carInfo[2]);
            Color = carInfo[3];
        }

        if (carInfo.Length == 3)
        {
            int currentWeight;
            bool hasParsed = int.TryParse(carInfo[2], out currentWeight);
            if (hasParsed)
            {
                weight = currentWeight;
            }
            else
            {
                Color = carInfo[2];
            }
        }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int Weight
    {
        set { weight = value; }
    }

    public string Color { get; set; } = "n/a";

    public override string ToString()
    {
        var carString = $"{Model}:\n";
        carString = string.Concat(carString, engine.ToString());
        if (weight == null)
        {
            carString = string.Concat(carString, $"  Weight: n/a\n");
        }
        else
        {
            carString = string.Concat(carString, $"  Weight: {weight}\n");
        }
        carString = string.Concat(carString, $"  Color: {Color}");

        return carString;
    }
}

