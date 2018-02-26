using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class PredicateForNames
    {
        static void Main()
        {
            int nameLength = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Func<string, bool> Filter = n => n.Length <= nameLength;
            Console.WriteLine(string.Join(Environment.NewLine, names.Where(Filter)));
        }
    }
}
