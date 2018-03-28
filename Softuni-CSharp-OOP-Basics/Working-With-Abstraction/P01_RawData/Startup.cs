using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    
    class RawData
    {
        static void Main()
        {
            List<Car> cars = GetListOfCars();
            
            string command = Console.ReadLine();
            PrintCommandForCars(command, cars);
            
        }

        private static void PrintCommandForCars(string command, List<Car> cars)
        {
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.CargoType == "fragile" && x.Tires.Any(y => y.TirePressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.CargoType == "flamable" && x.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static List<Car> GetListOfCars()
        {
            List<Car> cars = new List<Car>();
            int numOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfCars; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Queue<string> parametersQueue = new Queue<string>(parameters);
                Car newCar = new Car(parametersQueue);
                cars.Add(newCar);
            }

            return cars;
        }
    }
}
