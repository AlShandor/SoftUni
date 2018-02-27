using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MaxSequenceOfEqualElements
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
                if (sequence[i] == sequence[i - 1])
                {
                    start = i;
                    length++;
                }
                else if (sequence[i] != sequence[i - 1])
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

            PrintMaxSequenceOfEqualElements(sequence, bestStart, bestLength);
        }

        static void PrintMaxSequenceOfEqualElements(int[] array, int startingIndex, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(array[startingIndex] + " ");
            }
        }
    }
}
