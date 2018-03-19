using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01.ConvertFromBase_10ToBase_N
{
    class Program
    {
        static void Main()
        {
            string[] tokens = Console.ReadLine().Split(' ').ToArray();
            int newBase = int.Parse(tokens[0]);
            BigInteger decNum = BigInteger.Parse(tokens[1]);
            List<BigInteger> remainderList = new List<BigInteger>();
            while (decNum > 0)
            {
                BigInteger rem = decNum % newBase;
                remainderList.Add(rem);
                decNum = decNum / newBase;
            }

            remainderList.Reverse();
            string result = string.Join("", remainderList);
            Console.WriteLine(result);
        }
    }
}
