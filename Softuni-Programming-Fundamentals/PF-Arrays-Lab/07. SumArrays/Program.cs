using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] array2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] arraySum;
            if (array1.Length > array2.Length)
            {
                arraySum = new int[array1.Length];
            }
            else
            {
                arraySum = new int[array2.Length];
            }
            

            if (array1.Length == array2.Length)
            {
                for (int index = 0; index < array1.Length; index++)
                {
                    arraySum[index] = array1[index] + array2[index];
                }

                Console.WriteLine(string.Join(" ", arraySum));
            }
            else
            {
                if (array1.Length > array2.Length)
                {
                    int[] tempArray = new int[array1.Length];
                    for (int i = 0; i < tempArray.Length; i++)
                    {
                        tempArray[i] = array2[i % array2.Length];
                    }

                    for (int index = 0; index < tempArray.Length; index++)
                    {
                        arraySum[index] = array1[index] + tempArray[index];
                    }

                    Console.WriteLine(string.Join(" ", arraySum));
                }
                else
                {
                    int[] tempArray = new int[array2.Length];
                    for (int i = 0; i < tempArray.Length; i++)
                    {
                        tempArray[i] = array1[i % array1.Length];
                    }

                    for (int index = 0; index < tempArray.Length; index++)
                    {
                        arraySum[index] = tempArray[index] + array2[index];
                    }

                    Console.WriteLine(string.Join(" ", arraySum));
                }
            }
            
        }
    }
}
