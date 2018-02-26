using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main()
        {
            var ints = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Func<int[], int> getMinValue = PrintMinValueInCollection;

            Console.WriteLine(getMinValue(ints));
            
        }

        public static int PrintMinValueInCollection(int[] ints)
        {
            return ints.Min();
        }
    }
}
