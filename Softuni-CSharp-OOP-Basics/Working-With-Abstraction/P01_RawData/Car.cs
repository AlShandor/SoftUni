
using System.Collections.Generic;

class Car
{
    public string Model { get; set; }
    public int EngineSpeed { get; set; }
    public int EnginePower { get; set; }
    public int CargoWeight { get; set; }
    public string CargoType { get; set; }
    public List<Tire> Tires;

    public Car(Queue<string> parametersQueue)
    {
        Model = parametersQueue.Dequeue();
        EngineSpeed = int.Parse(parametersQueue.Dequeue());
        EnginePower = int.Parse(parametersQueue.Dequeue());
        CargoWeight = int.Parse(parametersQueue.Dequeue());
        CargoType = parametersQueue.Dequeue();

        Tire tire1 = new Tire(double.Parse(parametersQueue.Dequeue()), int.Parse(parametersQueue.Dequeue()));
        Tire tire2 = new Tire(double.Parse(parametersQueue.Dequeue()), int.Parse(parametersQueue.Dequeue()));
        Tire tire3 = new Tire(double.Parse(parametersQueue.Dequeue()), int.Parse(parametersQueue.Dequeue()));
        Tire tire4 = new Tire(double.Parse(parametersQueue.Dequeue()), int.Parse(parametersQueue.Dequeue()));

        Tires = new List<Tire>();
        Tires.Add(tire1);
        Tires.Add(tire2);
        Tires.Add(tire3);
        Tires.Add(tire4);
    }
    

}
