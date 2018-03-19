using System;
using System.Linq;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main()
        {
            string[] strings = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            decimal sum = 0;
            foreach (var str in strings)
            {
                sum += GetResultOfString(str);
            }
            Console.WriteLine($"{sum:f2}");
        }

        private static decimal GetResultOfString(string str)
        {
            decimal result = 0;
            char firstLetter = str[0];
            char lastLetter = str.Last();
            decimal num = GetNumFromString(str);
            
            decimal firstLetterValue = GetLetterValue(firstLetter);
            decimal lastLetterValue = GetLetterValue(lastLetter);

            result = char.IsUpper(firstLetter)? num / firstLetterValue : result = num * firstLetterValue;
            result = char.IsUpper(lastLetter) ? result -= lastLetterValue : result += lastLetterValue;
            
            return result;
        }

        private static decimal GetNumFromString(string str)
        {
            string strNoLetters = str.Substring(1, str.Length - 2);
            decimal num = decimal.Parse(strNoLetters);
            return num;
        }

        private static decimal GetLetterValue(char letter)
        {
            int value = 0;
            if (char.IsUpper(letter))
            {
                value = letter - 'A' + 1;
            }
            else
            {
                value = letter - 'a' + 1;
            }
            return value;
        }
    }
}
