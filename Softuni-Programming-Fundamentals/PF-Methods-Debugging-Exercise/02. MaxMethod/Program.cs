using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MaxMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int max = GetMax(num1, num2, num3);
            Console.WriteLine(max);
        }

        static int GetMax(int num1, int num2)
        {
            if (num1 >= num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }

        static int GetMax(int num1, int num2, int num3)
        {
            int max = num1;
            if (num2 >= num1)
            {
                max = num2;
            }

            if (num3 >= num1)
            {
                max = num3;
            }

            return max;
        }
    }
}
