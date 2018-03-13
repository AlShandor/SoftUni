using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.MultiplyEvensbyOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int evenResult = GetSumOfEvenNums(num);
            int oddResult = GetSumOfOddNums(num);
            int result = GetMultipleOfEvenAndOdds(evenResult, oddResult);
            Console.WriteLine(result);
        }

        static int GetMultipleOfEvenAndOdds(int evenResult, int oddResult)
        {
            int result = evenResult * oddResult;
            return result;
        }

        static int GetSumOfOddNums(int num)
        {
            num = Math.Abs(num);
            int oddResult = 0;
            while (num > 0)
            {
                if ((num % 10) % 2 == 1)
                {
                    oddResult += num % 10;
                }
                num /= 10;
            }
            return oddResult;
        }

        static int GetSumOfEvenNums(int num)
        {
            num = Math.Abs(num);
            int evenResult = 0;
            while (num > 0)
            {
                if ((num % 10) % 2 == 0)
                {
                    evenResult += num % 10;
                }
                num /= 10;
            }
            return evenResult;
        }
    }
}
