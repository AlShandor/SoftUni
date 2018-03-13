using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            BigInteger result = 1;
            for (int i = 1; i <= num; i++)
            {
                result *= i;
            }
            Console.WriteLine(result);
        }
    }
}
