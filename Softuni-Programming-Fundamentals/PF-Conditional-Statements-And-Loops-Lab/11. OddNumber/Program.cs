using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            while (num % 2 == 0)
            {
                Console.WriteLine("Please write an odd number.");
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The number is: {Math.Abs(num)}");
        }
    }
}
