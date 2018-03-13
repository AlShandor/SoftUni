using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _14.FactorialTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            BigInteger factorialNum = GetFactorial(num);
            int countTrailingZeroes = GetTrailingZeroes(factorialNum);
            Console.WriteLine(countTrailingZeroes);
        }

        private static int GetTrailingZeroes(BigInteger factorialNum)
        {
            int countOfZeroes = 0;
            BigInteger lastDigit = 0;
            while (true)
            {
                lastDigit = factorialNum % 10;
                if (lastDigit != 0)
                {
                    break;
                }
                factorialNum /= 10;
                countOfZeroes++;
            }
            return countOfZeroes;
        }

        private static BigInteger GetFactorial(int num)
        {
            BigInteger factorial = 1;
            for (int currentNum = 1; currentNum <= num; currentNum++)
            {
                factorial *= currentNum;
            }
            return factorial;
        }
    }
}
