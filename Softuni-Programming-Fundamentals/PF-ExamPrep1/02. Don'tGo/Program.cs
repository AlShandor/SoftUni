using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Don_tGo
{
    class Program
    {
        static void Main()
        {
            List<long> integers = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            long sum = 0;
            while (true)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    long currentIntToRemove = integers[0];
                    sum += currentIntToRemove;
                    integers[0] = integers.Last();
                    RemoveIntAndChangeListOfInt(integers, currentIntToRemove);
                }
                else if (index > integers.Count - 1)
                {
                    long currentIntToRemove = integers[integers.Count - 1];
                    sum += currentIntToRemove;
                    integers[integers.Count - 1] = integers[0];
                    RemoveIntAndChangeListOfInt(integers, currentIntToRemove);
                }
                else
                {
                    long currentIntToRemove = integers[index];
                    sum += currentIntToRemove;
                    integers.RemoveAt(index);
                    if (integers.Count == 0)
                    {
                        break;
                    }
                    RemoveIntAndChangeListOfInt(integers, currentIntToRemove);
                }
            }
            Console.WriteLine(sum);
        }

        private static void RemoveIntAndChangeListOfInt(List<long> integers, long currentIntToRemove)
        {
            for (int currentInt = 0; currentInt < integers.Count; currentInt++)
            {
                if (integers[currentInt] <= currentIntToRemove)
                {
                    integers[currentInt] += currentIntToRemove;
                }
                else
                {
                    integers[currentInt] -= currentIntToRemove;
                }
            }
        }
    }
}
