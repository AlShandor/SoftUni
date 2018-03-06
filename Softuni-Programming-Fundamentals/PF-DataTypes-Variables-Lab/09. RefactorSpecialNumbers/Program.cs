using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            
            for (int index = 1; index <= num; index++)
            {
                int sum = 0;
                int currentNum = index;
                while (currentNum > 0)
                {
                    sum += currentNum % 10;
                    currentNum /= 10;
                }

                bool isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{index} -> {isSpecialNum}");
            }
        }
    }
}
