using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ShortWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = {' ', '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?' };
            List<string> text = Console.ReadLine()
                .ToLower()
                .Split(separators)
                .Distinct()
                .Where(w => w != "")
                .Where(w => w.Length < 5)
                .OrderBy(w => w)
                .ToList();
            Console.WriteLine(string.Join(", ", text));
        }
    }
}
