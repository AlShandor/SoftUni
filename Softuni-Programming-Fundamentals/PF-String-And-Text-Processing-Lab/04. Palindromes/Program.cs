using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Palindromes
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<string> palindromes = new List<string>();
            for (int currentWord = 0; currentWord < words.Length; currentWord++)
            {
                if (IsPalindrome(words[currentWord]))
                {
                    palindromes.Add(words[currentWord]);
                }
            }
            Console.WriteLine(string.Join(", ", palindromes.Distinct().OrderBy(x => x)));
        }

        private static bool IsPalindrome(string word)
        {
            bool isPalindrome = false;
            string reversed = new string(word.Reverse().ToArray());
            if (word == reversed)
            {
                isPalindrome = true;
            }
            return isPalindrome;
        }
    }
}
