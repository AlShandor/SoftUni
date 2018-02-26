using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            var divisor = int.Parse(Console.ReadLine());

            Func<List<int>, int, List<int>> reverseAndExcludeFunc = ReverseAndExcludeDivisibleFromCollection;

            Console.WriteLine(string.Join(" ", reverseAndExcludeFunc(nums, divisor)));
        }

        public static List<int> ReverseAndExcludeDivisibleFromCollection(List<int> collection, int divisor)
        {
            collection.Reverse();
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i] % divisor == 0)
                {
                    collection.RemoveAt(i);
                    i--;
                }
            }
            return collection;
        }
    }
}
