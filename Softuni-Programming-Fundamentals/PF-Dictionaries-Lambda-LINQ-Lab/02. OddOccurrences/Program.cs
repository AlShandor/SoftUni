using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .ToLower()
                .Split(' ')
                .ToList();
            Dictionary<string, int> wordsDic = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordsDic.ContainsKey(word))
                {
                    wordsDic[word]++;
                }
                else
                {
                    wordsDic[word] = 1;
                }
            }

            List<string> resultList = new List<string>();
            foreach (var word in wordsDic)
            {
                if (word.Value % 2 == 1)
                {
                    resultList.Add(word.Key);
                }
            }
            Console.WriteLine(string.Join(", ", resultList));
        }
    }
}
