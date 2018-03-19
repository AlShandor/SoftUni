using System;
using System.Linq;

namespace _05.MagicExchangeableWordV2
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(' ').ToArray();
            char[] str1Chars = words[0].Distinct().ToArray();
            char[] str2Chars = words[1].Distinct().ToArray();
            if (str1Chars.Length == str2Chars.Length)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
