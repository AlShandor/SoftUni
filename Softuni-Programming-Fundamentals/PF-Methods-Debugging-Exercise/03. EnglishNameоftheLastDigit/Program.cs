using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.EnglishNameоftheLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            string lastDigitName = GetNameOfLastDigit(num);
            Console.WriteLine(lastDigitName);
        }

        static string GetNameOfLastDigit(long num)
        {
            long lastDigit = Math.Abs(num % 10);
            string lastDigitName = "";
            switch (lastDigit)
            {
                case 1:
                    lastDigitName = "one";
                    break;
                case 2:
                    lastDigitName = "two";
                    break;
                case 3:
                    lastDigitName = "three";
                    break;
                case 4:
                    lastDigitName = "four";
                    break;
                case 5:
                    lastDigitName = "five";
                    break;
                case 6:
                    lastDigitName = "six";
                    break;
                case 7:
                    lastDigitName = "seven";
                    break;
                case 8:
                    lastDigitName = "eight";
                    break;
                case 9:
                    lastDigitName = "nine";
                    break;
                case 0:
                    lastDigitName = "zero";
                    break;
                default:
                    break;
            }
            return lastDigitName;
        }
    }
}
