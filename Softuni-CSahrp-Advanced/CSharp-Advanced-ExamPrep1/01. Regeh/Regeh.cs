using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Regeh
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\[[a-zA-Z]+<(\d+)REGEH(\d+)>[a-zA-Z]+\]";
            Regex rgx = new Regex(pattern);

            var matches = rgx.Matches(input);

            List<int> indexList = new List<int>();
            StringBuilder sb = new StringBuilder();
            if (matches.Count > 0)
            {
                // Put all indexes in the list
                foreach (Match match in matches)
                {
                    indexList.Add(int.Parse(match.Groups[1].Value));
                    indexList.Add(int.Parse(match.Groups[2].Value));
                }

                int currentNum = 0;
                for (int i = 0; i < indexList.Count; i++)
                {
                    currentNum += indexList[i];

                    if (currentNum < input.Length)
                    {
                        sb.Append(input[currentNum]);
                    }
                    else
                    {
                        int biggerNum = currentNum;
                        sb.Append(input[biggerNum % input.Length]);
                    }
                    
                }

                Console.WriteLine(sb);
            }
        }
    }
}
