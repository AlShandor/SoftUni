using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MultiplyBigNumber
{
    class Program
    {
        static void Main()
        {
            string num = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            List<char> numArr = num.Reverse().ToList();
            List<char> sum = GetSumOfTwoNumArr(numArr, numArr);
            for (int currentTimeMultipled = 1; currentTimeMultipled < multiplier; currentTimeMultipled++)
            {
                sum = GetSumOfTwoNumArr(sum, numArr);
            }
            sum.Reverse();
            Console.WriteLine(string.Join("", sum));
            

        }

        private static List<char> GetSumOfTwoNumArr(List<char> numArr1, List<char> numArr2)
        {
            List<char> sum = new List<char>();
            int length = numArr1.Count < numArr2.Count ? numArr1.Count : numArr2.Count;

            // Nums with equal length
            int remainder = 0;
            for (int currentCharIndex = 0; currentCharIndex < length; currentCharIndex++)
            {
                int sumChar = 0;
                if (numArr1[currentCharIndex] + numArr2[currentCharIndex] + remainder > 105)
                {
                    if (remainder == 1)
                    {
                        sumChar = (char)((numArr1[currentCharIndex] + numArr2[currentCharIndex]) - 57);
                    }
                    else
                    {
                        sumChar = (char)((numArr1[currentCharIndex] + numArr2[currentCharIndex]) - 58);
                    }
                    remainder = 1;
                }
                else
                {
                    sumChar = (char)(numArr1[currentCharIndex] + numArr2[currentCharIndex] - 48 + remainder);
                    remainder = 0;
                }
                sum.Add((char)sumChar);
            }

            // Nums of equal length but the result is longer than their length
            if (numArr1.Count == numArr2.Count && remainder == 1)
            {
                sum.Add('1');
            }

            // Nums with different length
            if (numArr1.Count > numArr2.Count)
            {
                for (int i = length; i < numArr1.Count; i++)
                {
                    char sumChar = '0';
                    if (remainder == 1)
                    {
                        if (numArr1[length] + 1 > '9')
                        {
                            sumChar = '0';
                            remainder = 1;
                        }
                        else
                        {
                            sumChar = (char)(numArr1[length] + 1);
                            remainder = 0;
                        }
                        sum.Add((char)sumChar);
                    }
                    else
                    {
                        sumChar = numArr1[i];
                        sum.Add((char)sumChar);
                    }
                }
                if (remainder == 1)
                {
                    sum.Add('1');
                }
            }

            if (numArr2.Count > numArr1.Count)
            {
                for (int i = length; i < numArr2.Count; i++)
                {
                    char sumChar = '0';
                    if (remainder == 1)
                    {
                        if (numArr2[length] + 1 > '9')
                        {
                            sumChar = '0';
                            remainder = 1;
                        }
                        else
                        {
                            sumChar = (char)(numArr2[length] + 1);
                            remainder = 0;
                        }
                        sum.Add((char)sumChar);
                    }
                    else
                    {
                        sumChar = numArr2[i];
                        sum.Add((char)sumChar);
                    }
                }
                if (remainder == 1)
                {
                    sum.Add('1');
                }
            }
            return sum;
        }
    }
}
