using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] array1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] array2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            
            //if (Enumerable.SequenceEqual(array1, array2))
            //{
            //    PrintArray(array1);
            //    PrintArray(array2);
            //}
            if (array1.Length == array2.Length)
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    if (array1[i] < array2[i])
                    {
                        PrintArray(array1);
                        PrintArray(array2);
                        return;
                    }
                    else if (array2[i] < array1[i])
                    {
                        PrintArray(array2);
                        PrintArray(array1);
                        return;
                    }
                }
                PrintArray(array1);
                PrintArray(array2);
            }
            else if (array1.Length < array2.Length)
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    if (array1[i] < array2[i])
                    {
                        PrintArray(array1);
                        PrintArray(array2);
                        return;
                    }
                    else if (array2[i] < array1[i])
                    {
                        PrintArray(array2);
                        PrintArray(array1);
                        return;
                    }
                }
                PrintArray(array1);
                PrintArray(array2);
            }
            else if (array2.Length < array1.Length)
            {
                for (int i = 0; i < array2.Length; i++)
                {
                    if (array1[i] < array2[i])
                    {
                        PrintArray(array1);
                        PrintArray(array2);
                        return;
                    }
                    else if (array2[i] < array1[i])
                    {
                        PrintArray(array2);
                        PrintArray(array1);
                        return;
                    }
                }
                PrintArray(array2);
                PrintArray(array1);
            }
        }

        static void PrintArray(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write((char)array[i]);
            }
            Console.WriteLine();
        }
    }
}
