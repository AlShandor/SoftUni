using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.EnduranceRally
{
    class Program
    {
        static void Main()
        {
            string[] drivers = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            double[] layout = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            List<int> checkpoint = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            foreach (var driver in drivers)
            {
                double fuel = (double)driver.First();
                int zoneReached = 0;
                List<int> currentCheckpoint = new List<int>();
                currentCheckpoint.InsertRange(0, checkpoint);
                
                for (int currentZone = 0; currentZone < layout.Length; currentZone++)
                {
                    if (currentCheckpoint.Count != 0 && currentZone == currentCheckpoint.First())
                    {
                        fuel += layout[currentZone];
                        currentCheckpoint.RemoveAt(0);
                    }
                    else
                    {
                        fuel -= layout[currentZone];
                    }
                    if (fuel <= 0)
                    {
                        break;
                    }
                    zoneReached++;
                }

                if (zoneReached == layout.Length)
                {
                    Console.WriteLine($"{driver} - fuel left {fuel:f2}");
                }
                else
                {
                    Console.WriteLine($"{driver} - reached {zoneReached}");
                }
            }
        }
        
    }
}
