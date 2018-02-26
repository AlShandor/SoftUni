using System;

namespace _02.KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main()
        {
            var names = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printNamesWithSir = PutSirToNamesInCollection;

            printNamesWithSir(names);
        }

        public static void PutSirToNamesInCollection(string[] namesCollection)
        {
            foreach (var name in namesCollection)
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
