using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LastKNumbersSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfElements = int.Parse(Console.ReadLine());
            int numOfPreviousElements = int.Parse(Console.ReadLine());
            long[] array = new long[numberOfElements];
            array[0] = 1;

            for (int indexInSequence = 1; indexInSequence < numberOfElements; indexInSequence++)
            {
                long sum = 0;
                if (indexInSequence - numOfPreviousElements < 0)
                {
                    for (int j = 0; j < indexInSequence; j++)
                    {
                        sum += array[j];
                    }
                }
                else
                {
                    for (int k = indexInSequence - numOfPreviousElements; k <= indexInSequence - 1; k++)
                    {
                        sum += array[k];
                    }
                }
                
                array[indexInSequence] = sum;
            }
                Console.WriteLine(String.Join(" ", array));
        }
    }
}
