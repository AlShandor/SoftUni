
using System.Collections.Generic;

public class Cargo
{
    private int weight;
    private string type;

    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public Cargo(Queue<string> carInfo)
    {
        Weight = int.Parse(carInfo.Dequeue());
        Type = carInfo.Dequeue();
    }
}
