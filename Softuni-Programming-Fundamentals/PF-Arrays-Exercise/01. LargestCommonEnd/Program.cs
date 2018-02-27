using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(' ').ToArray();
            string[] array2 = Console.ReadLine().Split(' ').ToArray();
            string[] reversedArray1 = array1.Reverse().ToArray();
            string[] reversedArray2 = array2.Reverse().ToArray();


            int shorterLength = Math.Min(array1.Length, array2.Length);
            int count = 0;
            for (int i = 0; i < shorterLength; i++)
            {
                if (array1[i] == array2[i])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            if (count == 0)
            {
                for (int i = 0; i < shorterLength; i++)
                {
                    if (reversedArray1[i] == reversedArray2[i])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
