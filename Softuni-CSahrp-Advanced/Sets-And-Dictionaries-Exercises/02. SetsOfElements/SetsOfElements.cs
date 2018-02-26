using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class SetsOfElements
    {
        static void Main()
        {
            int[] setsLengths = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int setALength = setsLengths[0];
            int setBLength = setsLengths[1];

            HashSet<int> setA = new HashSet<int>();
            HashSet<int> setB = new HashSet<int>();

            for (int i = 0; i < setALength; i++)
            {
                setA.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setBLength; i++)
            {
                setB.Add(int.Parse(Console.ReadLine()));
            }

            var commonInts = setA.Intersect(setB);

            Console.WriteLine(string.Join(" ", commonInts));
        }
    }
}
