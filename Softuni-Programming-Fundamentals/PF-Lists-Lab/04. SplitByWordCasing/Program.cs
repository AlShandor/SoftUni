using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Use the following separators between the words: , ; : . ! ( ) " ' \ / [ ] space
namespace _04.SplitByWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine()
                .Split(new char[] {',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' '}
                    , StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> lowercaseArr = new List<string>();
            List<string> uppercaseArr = new List<string>();
            List<string> mixedcaseArr = new List<string>();
            for (int indexOfWord = 0; indexOfWord < text.Count; indexOfWord++)
            {
                string word = text[indexOfWord];
                int uppercaseCount = 0;
                int lowercaseCount = 0;
                for (int indexOfLetter = 0; indexOfLetter < word.Length; indexOfLetter++)
                {
                    char charWord = word[indexOfLetter];
                    if (char.IsUpper(word, indexOfLetter))
                    {
                        uppercaseCount++;
                    }
                    if (char.IsLower(word, indexOfLetter))
                    {
                        lowercaseCount++;
                    }
                }

                if (word.Length == lowercaseCount)
                {
                    lowercaseArr.Add(word);
                }
                else if (word.Length == uppercaseCount)
                {
                    uppercaseArr.Add(word);
                }
                else
                {
                    mixedcaseArr.Add(word);
                }
            }

            Console.WriteLine("Lower-case: " + string.Join(", ", lowercaseArr));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixedcaseArr));
            Console.WriteLine("Upper-case: " + string.Join(", ", uppercaseArr));

        }
    }
}
