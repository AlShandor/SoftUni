using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            double result = MathPower(num, power);
            Console.WriteLine(result);
        }

        static double MathPower(double num, double power)
        {
            double result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= num;
            }
            return result;
        }
    }
}
