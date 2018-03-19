using System;
using System.Linq;

namespace _04.CharacterMultiplier
{
    class Program
    {
        static void Main()
        {
            string[] tokens = Console.ReadLine().Split(' ').ToArray();
            string str1 = tokens[0];
            string str2 = tokens[1];
            int sum = GetSumOfTwoStrings(str1, str2);
            Console.WriteLine(sum);
        }

        private static int GetSumOfTwoStrings(string str1, string str2)
        {
            int sum = 0;
            char[] charsStr1 = str1.ToCharArray();
            char[] charsStr2 = str2.ToCharArray();
            int length = charsStr1.Length > charsStr2.Length ? charsStr2.Length : charsStr1.Length;
            for (int currentChar = 0; currentChar < length; currentChar++)
            {
                sum += ((int)charsStr1[currentChar]) * ((int)charsStr2[currentChar]);
            }
            if (charsStr1.Length != charsStr2.Length)
            {
                if (charsStr1.Length > charsStr2.Length)
                {
                    for (int currentChar = length; currentChar < charsStr1.Length; currentChar++)
                    {
                        sum += ((int)charsStr1[currentChar]);
                    }
                }
                else
                {
                    for (int currentChar = length; currentChar < charsStr2.Length; currentChar++)
                    {
                        sum += ((int)charsStr2[currentChar]);
                    }
                }
            }
            return sum;
        }
    }
}
