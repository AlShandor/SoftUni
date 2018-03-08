using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HornetAssault
{
    class Program
    {
        static void Main()
        {
            List<long> beehives = Console.ReadLine()
        .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
        .Select(long.Parse)
        .ToList();
            List<long> hornets = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            for (int currentBeehive = 0; currentBeehive < beehives.Count; currentBeehive++)
            {
                long hornetsTotalPower = hornets.Sum();
                if (hornetsTotalPower == 0)
                {
                    break;
                }
                if (beehives[currentBeehive] < hornetsTotalPower)
                {
                    beehives[currentBeehive] = 0;
                }
                else
                {
                    beehives[currentBeehive] -= hornetsTotalPower;
                    hornets.RemoveAt(0);
                }
            }

            if (beehives.Sum() > 0)
            {
                for (int i = 0; i < beehives.Count; i++)
                {
                    if (beehives[i] == 0)
                    {
                        beehives.RemoveAt(i);
                        i--;
                    }
                }
                Console.WriteLine(string.Join(" ", beehives));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }

        }
    }
}
