using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.MatchNumbers
{
    class Program
    {
        static void Main()
        {
            string regex = @"(^|(?<=\s))-?\d+(\.?\d+)?($|(?=\s))";
            string input = Console.ReadLine();
            var matchedNums = Regex.Matches(input, regex);
            string[] numsArr = matchedNums.Cast<Match>()
                .Select(n => n.Value)
                .ToArray();

            Console.WriteLine(string.Join(" ", numsArr));

        }
    }
}
