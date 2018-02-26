using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.TreasureMap
{
    class TreasureMap
    {
        static void Main()
        {
            string pattern = @"#[^#!]*?\b([a-zA-Z]{4})\b[^#!]*?(?s:[^!#]*)([0-9]{3}-[0-9]{4,6})[^#!]*!|![^#!]*?\b([a-zA-Z]{4})\b[^#!]*?(?s:[^!#]*)([0-9]{3}-[0-9]{4,6})[^#!]*#";
            
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                List<List<string>> streetPassPairs = new List<List<string>>();
                string input = Console.ReadLine();
                var matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    List<string> pair = new List<string>();
                    if (match.Value[0] == '#')
                    {
                       pair.Add(match.Groups[1].ToString()); 
                       pair.Add(match.Groups[2].ToString());
                    }
                    else if (match.Value[0] == '!')
                    {
                        pair.Add(match.Groups[3].ToString());
                        pair.Add(match.Groups[4].ToString());
                    }
                    streetPassPairs.Add(pair);
                }

                PrintResult(streetPassPairs);
            }

        }

        private static void PrintResult(List<List<string>> streetPassPairs)
        {
            if (streetPassPairs.Count == 1)
            {
                string streetName = streetPassPairs[0][0];
                string streetNum = streetPassPairs[0][1].Split('-').First();
                string password = streetPassPairs[0][1].Split('-').Skip(1).First();
                Console.Write($"Go to str. {streetName} {streetNum}. ");
                Console.WriteLine($"Secret pass: {password}.");
            }
            else
            {
                List<string> pair = streetPassPairs[streetPassPairs.Count / 2];
                string streetName = pair[0];
                string streetNum = pair[1].Split('-').First();
                string password = pair[1].Split('-').Skip(1).First();
                Console.Write($"Go to str. {streetName} {streetNum}. ");
                Console.WriteLine($"Secret pass: {password}.");
            }
        }
    }
}
