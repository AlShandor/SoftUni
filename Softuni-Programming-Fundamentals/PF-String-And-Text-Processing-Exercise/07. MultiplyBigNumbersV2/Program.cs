using System;
using System.Linq;
using System.Text;

namespace _07.MultiplyByBigNumberV2
{
    class Program
    {
        static void Main()
        {
            string num = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                string sum = num;
                for (int i = 0; i < multiplier - 1; i++)
                {
                    sum = GetSumOfBigNum(sum, num);
                }
                Console.WriteLine(sum.TrimStart('0'));
            }
        }

        private static string GetSumOfBigNum(string sum, string num)
        {
            string num1 = sum;
            string num2 = num;
            if (num1.Length > num2.Length)
            {
                num2 = num2.PadLeft(num1.Length, '0');
            }
            else
            {
                num1 = num1.PadLeft(num2.Length, '0');
            }

            StringBuilder sb = new StringBuilder();
            int sumNum = 0;
            int number = 0;
            int remainder = 0;

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                sumNum = num1[i] - 48 + num2[i] - 48 + remainder;
                number = sumNum % 10;
                sb.Append(number);
                remainder = sumNum / 10;


                if (i == 0 && remainder == 1)
                {
                    sb.Append(remainder);
                }
            }

            sum = new string(sb.ToString().Reverse().ToArray());
            return sum;
        }
    }
}
