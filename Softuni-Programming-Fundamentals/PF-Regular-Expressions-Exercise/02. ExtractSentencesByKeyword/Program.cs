using System;
using System.Text.RegularExpressions;

namespace _02.ExtractSentencesByKeyword
{
    class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            //string regex = @"(^|(?<=\s))[A-Z][^.!?]*\W" + word + @"\W.*?(?=[\.\?\!])";
            string regex = @"(^|(?<=\s))[^.]*\W" + word + @"\W[^.]*\.";
            var allSentences = Regex.Matches(text, regex);
            foreach (Match sentence in allSentences)
            {
                Console.WriteLine(sentence.Value);
            }
        }
    }
}
