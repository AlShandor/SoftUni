using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.MatchHexadecimalNumber
{
    class Program
    {
        static void Main()
        {
            string regex = @"\b(0x)?[0-9A-F]+\b";
            string numbersString = Console.ReadLine();
            string[] numbers = Regex.Matches(numbersString, regex)
                .Cast<Match>()
                .Select(n => n.Value)
                .ToArray();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
