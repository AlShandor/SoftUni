using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SignOfIntegerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintSignOfInteger(number);
        }

        static void PrintSignOfInteger(int number)
        {
            if (number == 0)
            {
                Console.WriteLine("The number 0 is zero.");
            }
            else if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else
            {
                Console.WriteLine($"The number {number} is negative.");
            }
        }
    }
}
