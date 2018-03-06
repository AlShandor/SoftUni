using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.FastPrimeCheckerRefactor
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int currentNumber = 2; currentNumber <= num; currentNumber++)
{
                bool isPrime = true;
                for (int divisor = 2; divisor <= Math.Sqrt(currentNumber); divisor++)
{
                    if (currentNumber % divisor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{currentNumber} -> {isPrime}");
            }
        }
    }
}
