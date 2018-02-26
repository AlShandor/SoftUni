using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main()
        {
            int end = int.Parse(Console.ReadLine());

            var divisors = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            
            List<int> numsToPrint = new List<int>();
            for (int i = 1; i <= end; i++)
            {
                bool isDivisible = true;
                foreach (var divisor in divisors)
                {
                    if (i % divisor != 0)
                    {
                        isDivisible = false;
                    }
                }

                if (!isDivisible)
                {
                    continue;
                }
                numsToPrint.Add(i);
            }

            Console.WriteLine(string.Join(" ", numsToPrint));
        }
    }
}
