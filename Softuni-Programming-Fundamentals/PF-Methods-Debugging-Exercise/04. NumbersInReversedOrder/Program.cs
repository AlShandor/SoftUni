using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.NumbersInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string reversedNum = ReverseDigitsOfNum(num);
            Console.WriteLine(reversedNum);
        }

        private static string ReverseDigitsOfNum(double num)
        {
            string numStr = num.ToString();
            char[] digits = numStr.ToCharArray();
            Array.Reverse(digits);
            return new string(digits);
        }
    }
}
