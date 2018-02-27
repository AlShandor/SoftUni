using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int totalRotations = int.Parse(Console.ReadLine());
            int[] sum = new int[arrayInt.Length];
            for (int rotation = 1; rotation <= totalRotations; rotation++)
            {
                int[] tempArray = RotateIntArrayRight(rotation, arrayInt);
                for (int indexPositionSum = 0; indexPositionSum <= sum.Length - 1; indexPositionSum++)
                {
                    sum[indexPositionSum] += tempArray[indexPositionSum];
                }
            }

            Console.WriteLine(string.Join(" ", sum));
        }

        static int[] RotateIntArrayRight(int rotation, int[] array)
        {
            int[] tempArray = new int[array.Length];
            for (int indexPosition = 0; indexPosition <= array.Length - 1; indexPosition++)
            {
                tempArray[(indexPosition + rotation) % array.Length] = array[indexPosition];
            }

            return tempArray;
        }
    }

    
}
