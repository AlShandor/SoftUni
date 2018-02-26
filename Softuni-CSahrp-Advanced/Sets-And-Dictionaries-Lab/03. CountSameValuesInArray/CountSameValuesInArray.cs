using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CountSameValuesInArray
{
    class CountSameValuesInArray
    {
        static void Main()
        {
            decimal[] values = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            SortedDictionary<decimal, int> valueDictionary = new SortedDictionary<decimal, int>();

            foreach (var value in values)
            {
                if (!valueDictionary.ContainsKey(value))
                {
                    valueDictionary[value] = 0;
                }

                valueDictionary[value]++;
            }

            foreach (var kvp in valueDictionary)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
