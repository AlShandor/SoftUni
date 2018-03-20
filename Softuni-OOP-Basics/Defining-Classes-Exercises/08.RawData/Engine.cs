
using System.Collections.Generic;

public class Engine
{
    private int speed;
    private int power;

    public int Speed
    {
        get { return speed;}
        set { speed = value;}
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    public Engine(Queue<string> carInfo)
    {
        Speed = int.Parse(carInfo.Dequeue());
        Power = int.Parse(carInfo.Dequeue());
    }
}
