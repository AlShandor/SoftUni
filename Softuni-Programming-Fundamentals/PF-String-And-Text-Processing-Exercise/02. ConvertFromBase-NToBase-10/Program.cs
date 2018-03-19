using System;
using System.Linq;
using System.Numerics;

namespace _01.ConvertFromBase_10ToBase_N
{
    class Program
    {
        static void Main()
        {
            string[] tokens = Console.ReadLine().Split(' ').ToArray();
            string Base = tokens[0];
            string numToString = new string (tokens[1].Reverse().ToArray());
            BigInteger sum = 0;

            for (int i = 0; i < numToString.Length; i++)
            {
                sum += int.Parse(numToString[i].ToString()) * NotMathPow(Base, i);
            }

            Console.WriteLine(sum);
        }

        static BigInteger NotMathPow(string num, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            var bigIntNum = BigInteger.Parse(num);
            BigInteger result = bigIntNum;
            for (int i = 1; i < power; i++)
            {
                result *= bigIntNum;
            }
            return result;
        }
    }
}
