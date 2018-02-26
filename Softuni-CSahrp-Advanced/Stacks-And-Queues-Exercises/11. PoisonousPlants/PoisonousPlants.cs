using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PoisonousPlants
{
    class PoisonousPlants
    {
        static void Main()
        {
            int numberPlants = int.Parse(Console.ReadLine());
            Queue<int> plantQue = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray().Reverse());

            int days = 1;
            while (true)
            {
                int numberAlivePlants = plantQue.Count;
                for (int i = 0; i < numberAlivePlants - 1; i++)
                {
                    int currentPlant = plantQue.Dequeue();
                    if (currentPlant <= plantQue.Peek())
                    {
                        plantQue.Enqueue(currentPlant);
                    }

                }
                plantQue.Enqueue(plantQue.Dequeue());

                if (numberAlivePlants == plantQue.Count)
                {
                    break;
                }
                days++;
            }

            Console.WriteLine(days - 1);
        }
    }
}
