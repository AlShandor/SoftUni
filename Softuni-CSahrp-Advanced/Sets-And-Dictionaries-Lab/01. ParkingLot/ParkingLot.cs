using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ParkingLot
{
    class ParkingLot
    {
        static void Main()
        {
            SortedSet<string> carNumbers = new SortedSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0];
                string carNumber = tokens[1];

                if (action == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else if (action == "OUT")
                {
                    carNumbers.Remove(carNumber);
                }
                else
                {
                    continue;
                }
            }

            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var carNumber in carNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
        }
    }
}
