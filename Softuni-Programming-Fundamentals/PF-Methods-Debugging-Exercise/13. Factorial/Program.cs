using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFactorial(num));
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
