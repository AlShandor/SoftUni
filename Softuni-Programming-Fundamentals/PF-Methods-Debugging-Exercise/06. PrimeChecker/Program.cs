using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            bool isPrime = IsPrime(num);
            Console.WriteLine(isPrime);
        }

        static bool IsPrime(long num)
        {
            bool isPrime = true;
            if (num <= 1)
            {
                isPrime = false;
            }

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }
    }
}
