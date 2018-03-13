using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int fibNum = GetFibonacciNum(num);
            Console.WriteLine(fibNum);
        }

        static int GetFibonacciNum(int num)
        {
            int num1 = 1;
            int num2 = 2;
            int fibNum = 0; ;
            for (int i = 1; i <= num - 2; i++)
            {
                fibNum = num1 + num2;
                num1 = num2;
                num2 = fibNum;
            }

            if (num == 0 || num == 1)
            {
                return 1;
            }
            else if (num == 2)
            {
                return 2;
            }
            else
            {
                return fibNum;
            }
        }
    }
}
