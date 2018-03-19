using System;
using System.Linq;

namespace _03.TextFilter
{
    class Program
    {
        static void Main()
        {
            string[] bannedWords = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string text = Console.ReadLine();

            for (int currentBannedWord = 0; currentBannedWord < bannedWords.Length; currentBannedWord++)
            {
                text = text.Replace(bannedWords[currentBannedWord], new string('*', bannedWords[currentBannedWord].Length));
            }
            Console.WriteLine(text);
        }
    }
}
