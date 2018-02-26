using System;
using System.Collections.Generic;

namespace _04.CountSymbols
{
    class CountSymbols
    {
        static void Main()
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> dictionaryChar = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dictionaryChar.ContainsKey(input[i]))
                {
                    dictionaryChar[input[i]] = 0;
                }

                dictionaryChar[input[i]]++;
            }

            foreach (var ch in dictionaryChar)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
