using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PrimesInGivenRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            List<int> primesInRange = FindPrimesInRange(startNum, endNum);
            Console.WriteLine(String.Join(", ", primesInRange));
        }

        static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            List<int> primesInRange = new List<int>();
            for (int currentNum = startNum; currentNum <= endNum; currentNum++)
            {
                bool isPrime = true;

                if (currentNum <= 1)
                {
                    isPrime = false;
                }

                for (int divisor = 2; divisor <= Math.Sqrt(currentNum); divisor++)
                {
                    if (currentNum % divisor == 0)
                    {
                        isPrime = false;
                    }
                }

                if (isPrime)
                {
                    primesInRange.Add(currentNum);
                }
            }
            return primesInRange;
        }
    }
}
