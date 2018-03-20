using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        int numOfCars = int.Parse(Console.ReadLine());
        Dictionary<string, Car> cars = new Dictionary<string, Car>();
        for (int i = 0; i < numOfCars; i++)
        {
            string[] carInfo = Console.ReadLine().Split();
            Car newCar = new Car(carInfo);
            cars[carInfo[0]] = newCar;
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] commandInfo = command.Split();
            string carModel = commandInfo[1];
            int amountOfKm = int.Parse(commandInfo[2]);

            if (amountOfKm * cars[carModel].ConsumptionPer1Km > cars[carModel].FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                continue;
            }

            cars[carModel].FuelAmount -= amountOfKm * cars[carModel].ConsumptionPer1Km;
            cars[carModel].DistanceTravelled += amountOfKm;
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.DistanceTravelled}");
        }
    }
}
