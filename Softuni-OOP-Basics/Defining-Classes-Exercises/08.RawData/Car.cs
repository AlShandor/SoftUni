
using System.Collections.Generic;

public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;

    public List<Tire> Tires = new List<Tire>(4);
    public string Model
    {
        get { return model;}
        set { model = value; }
    }
    public Engine Engine {
        get { return engine; }
        set { engine = value; }
    }
    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }

    public Car(Queue<string> carInfo)
    {
        Model = carInfo.Dequeue();
        Engine = new Engine(carInfo);
        Cargo = new Cargo(carInfo);
        for (int i = 0; i < 4; i++)
        {
            Tire newTire = new Tire(carInfo);
            Tires.Add(newTire);
        }
    }
}
