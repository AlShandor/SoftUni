using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main()
        {
            string regex = @"\+359(-| )2\1\d{3}\1\d{4}\b";
            string phones = Console.ReadLine();

            var phoneMatches = Regex.Matches(phones, regex);
            string[] matchedPhones = phoneMatches
                .Cast<Match>()
                .Select(m => m.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
