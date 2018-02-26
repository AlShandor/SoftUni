using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.TrafficJam
{
    class TrafficJam
    {
        static void Main()
        {
            int numPassingCars = int.Parse(Console.ReadLine());
            Queue<string> carQueue = new Queue<string>();
            int countPassedCars = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                if (input == "green")
                {
                    if (carQueue.Count < numPassingCars)
                    {
                        countPassedCars += carQueue.Count;
                    }
                    else
                    {
                        countPassedCars += numPassingCars;
                    }

                    for (int i = 0; i < numPassingCars; i++)
                    {
                        if (carQueue.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{carQueue.Dequeue()} passed!");
                    }
                    continue;
                }
                carQueue.Enqueue(input);
            }

            Console.WriteLine($"{countPassedCars} cars passed the crossroads.");
        }
    }
}
