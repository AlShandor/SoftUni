using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class PeriodicTable
    {
        static void Main()
        {
            int numChemicalCompounds = int.Parse(Console.ReadLine());
            SortedSet<string> setChemicals = new SortedSet<string>();

            for (int i = 0; i < numChemicalCompounds; i++)
            {
                string[] chemicalElements =
                    Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < chemicalElements.Length; j++)
                {
                    setChemicals.Add(chemicalElements[j]);
                }
            }

            Console.WriteLine(string.Join(" ", setChemicals));
        }
    }
}
