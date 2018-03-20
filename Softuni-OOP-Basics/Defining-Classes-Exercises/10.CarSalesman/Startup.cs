
using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        int numOfEngines = int.Parse(Console.ReadLine());
        Dictionary<string, Engine> engines = GetEngines(numOfEngines);

        int numOfCars = int.Parse(Console.ReadLine());
        Dictionary<string, Car> cars = GetCars(numOfCars, engines);

        PrintCarInfo(cars);
    }

    private static Dictionary<string, Car> GetCars(int numOfCars, Dictionary<string, Engine> engines)
    {
        Dictionary<string, Car> cars = new Dictionary<string, Car>();
        for (int i = 0; i < numOfCars; i++)
        {
            string[] carInfo = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Car newCar = new Car(carInfo, engines);
            cars[newCar.Model] = newCar;
        }

        return cars;
    }

    private static void PrintCarInfo(Dictionary<string, Car> cars)
    {
        foreach (var car in cars)
        {
            Console.WriteLine(car.Value.ToString());
        }
    }

    private static Dictionary<string, Engine> GetEngines(int numOfEngines)
    {
        Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
        for (int i = 0; i < numOfEngines; i++)
        {
            string[] engineInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Engine newEngine = new Engine(engineInfo);
            engines[newEngine.Model] = newEngine;
        }

        return engines;
    }
}
