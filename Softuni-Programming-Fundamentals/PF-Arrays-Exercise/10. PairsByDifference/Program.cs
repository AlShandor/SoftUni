using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int difference = int.Parse(Console.ReadLine());
            int numOfPairs = 0;
            for (int currentNum = 0; currentNum < sequence.Length; currentNum++)
            {
                for (int nextNum = currentNum + 1; nextNum < sequence.Length; nextNum++)
                {
                    if (Math.Abs(sequence[currentNum] - sequence[nextNum]) == difference)
                    {
                        numOfPairs++;
                    }
                }
            }
            Console.WriteLine(numOfPairs);
        }
    }
}
