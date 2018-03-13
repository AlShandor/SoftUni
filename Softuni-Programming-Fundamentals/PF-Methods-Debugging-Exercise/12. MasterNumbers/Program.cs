using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.MasterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            
            for (int currentNum = 1; currentNum <= num; currentNum++)
            {
                bool isSymmetric = IsSymmetricNum(currentNum);
                bool isSumOfDigitsDivisableBy7 = IsSumOfDigitsDivisableBy7(currentNum);
                bool isOneDigitEven = IsOneDigitEven(currentNum);
                if (isSymmetric && isSumOfDigitsDivisableBy7 && isOneDigitEven)
                {
                    Console.WriteLine(currentNum);
                }
            }
        }

        private static bool IsOneDigitEven(int num)
        {
            bool isOneDigitEven = false;
            while(num > 0)
            {
                int currentDigit = num % 10;
                if (currentDigit % 2 == 0)
                {
                    isOneDigitEven = true;
                    break;
                }
                num /= 10;
            }
            return isOneDigitEven;
        }

        private static bool IsSumOfDigitsDivisableBy7(int num)
        {
            bool isSumOfDigitsDivisableBy7 = false;
            int sumOfDigits = 0;
            while (num > 0)
            {
                sumOfDigits += num % 10;
                num /= 10;
            }

            if (sumOfDigits % 7 == 0)
            {
                isSumOfDigitsDivisableBy7 = true;
            }

            return isSumOfDigitsDivisableBy7;
        }

        private static bool IsSymmetricNum(int num)
        {
            string digits = num.ToString();
            for (int i = 0; i < digits.Length - 1 / 2; i++)
            {
                if (digits[i] != digits[digits.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
