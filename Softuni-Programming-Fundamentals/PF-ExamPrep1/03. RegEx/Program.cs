using System;
using System.Text.RegularExpressions;

namespace _03.RegEx
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string firstPattern = @"[^a-zA-Z-]+";
            string secondPattern = @"[a-zA-Z]+-[a-zA-Z]+";
            Regex firstRegex = new Regex(firstPattern);
            Regex secondRegex = new Regex(secondPattern);
            
            int turn = 1;
            while (true)
            {
                if (turn % 2 == 1)
                {
                    if (!firstRegex.IsMatch(input))
                    {
                        break;
                    }
                    string matchedFirst = firstRegex.Match(input).ToString();
                    Console.WriteLine(matchedFirst);
                    input = input.Substring(input.IndexOf(matchedFirst) + matchedFirst.Length);
                }
                else
                {
                    if (!secondRegex.IsMatch(input))
                    {
                        break;
                    }
                    string matchedSecond = secondRegex.Match(input).ToString();
                    Console.WriteLine(matchedSecond);
                    input = input.Substring(input.IndexOf(matchedSecond) + matchedSecond.Length);
                }
                turn++;
            }
        }
    }
}
