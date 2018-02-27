using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MaxSequenceOfIncreasingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int bestStart = 0;
            int bestLength = 0;
            int start = 0;
            int length = 1;
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] > sequence[i - 1])
                {
                    start = i;
                    length++;
                }
                else
                {
                    start = i;
                    length = 1;
                }
                if (length > bestLength)
                {
                    bestLength = length;
                    bestStart = start;
                }
            }

            PrintMaxSequenceOfIncreasingElements(sequence, bestStart, bestLength);
        }

        static void PrintMaxSequenceOfIncreasingElements(int[] array, int startingIndex, int length)
        {
            for (int i = 1; i <= length; i++)
            {
                Console.Write(array[startingIndex - length + i] + " ");
            }
        }
    }
}
