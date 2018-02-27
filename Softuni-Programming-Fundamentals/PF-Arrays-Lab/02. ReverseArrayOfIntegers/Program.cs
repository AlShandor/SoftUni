using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ReverseArrayOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] numbers = new int[num];
            for (int i = 0; i < num; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int[] reversedNumbers = new int[num];
            for (int i = 0; i < num; i++)
            {
                reversedNumbers[i] = numbers[num - 1 - i];
            }

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(reversedNumbers[i]);
            }
        }
    }
}
