
using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        int numOfCars = int.Parse(Console.ReadLine());
        Dictionary<string, Car> cars = new Dictionary<string, Car>();
        for (int i = 0; i < numOfCars; i++)
        {
            Queue<string> carInfo = new Queue<string>(Console.ReadLine().Split());
            Car newCar = new Car(carInfo);
            cars[newCar.Model] = newCar;
        }

        string command = Console.ReadLine();
        if (command == "fragile")
        {
            PrintFragileCars(cars);
        }

        if (command == "flamable")
        {
            PrintFlamableCars(cars);
        }
    }

    private static void PrintFlamableCars(Dictionary<string, Car> cars)
    {
            foreach (var car in cars.Where(x => x.Value.Cargo.Type == "flamable" && x.Value.Engine.Power > 250))
            {
                Console.WriteLine($"{car.Key}");
            }
    }

    private static void PrintFragileCars(Dictionary<string, Car> cars)
    {
        foreach (var car in cars.Where(x => x.Value.Cargo.Type == "fragile" && x.Value.Tires.Any(t => t.Pressure < 1)))
        {
            Console.WriteLine($"{car.Key}");
        }
    }
}
