
using System.Collections.Generic;

public class Tire
{
    private double pressure;
    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    
    public double Pressure
    {
        get { return pressure; }
        set { pressure = value; }
    }

    public Tire(Queue<string> carInfo)
    {
        Pressure = double.Parse(carInfo.Dequeue());
        Age = int.Parse(carInfo.Dequeue());
    }
}
