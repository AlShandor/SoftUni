using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int oddNum = 1;
            for (int i = 1; i <= n; i++)
            {
                sum += oddNum;
                Console.WriteLine(oddNum);
                oddNum += 2;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
