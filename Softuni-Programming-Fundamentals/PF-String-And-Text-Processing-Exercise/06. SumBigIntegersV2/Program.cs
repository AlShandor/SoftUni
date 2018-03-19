using System;
using System.Linq;
using System.Text;

namespace _06.SumBigIntegersV2
{
    class Program
    {
        static void Main()
        {
            string num1 = Console.ReadLine();
            string num2 = Console.ReadLine();
            if (num1.Length > num2.Length)
            {
                num2 = num2.PadLeft(num1.Length, '0');
            }
            else
            {
                num1 = num1.PadLeft(num2.Length, '0');
            }

            StringBuilder sb = new StringBuilder();
            int sum = 0;
            int number = 0;
            int remainder = 0;

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                sum = num1[i] - 48 + num2[i] - 48 + remainder;
                number = sum % 10;
                sb.Append(number);
                remainder = sum / 10;
                

                if (i == 0 && remainder == 1)
                {
                    sb.Append(remainder);
                }
            }

            Console.WriteLine(new string(sb.ToString().TrimEnd('0').Reverse().ToArray()));
        }
    }
}
