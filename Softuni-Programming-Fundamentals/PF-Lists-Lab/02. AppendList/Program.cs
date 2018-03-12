using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AppendList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfNumbers = Console.ReadLine().Split('|').ToList();
            List<int> result = new List<int>();
            for (int i = listOfNumbers.Count - 1; i >= 0; i--)
            {
                List<int> token = listOfNumbers[i]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                for (int j = 0; j < token.Count; j++)
                {
                    result.Add(token[j]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
