using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            char[] charArray = word.ToCharArray(0, word.Length);

            for (int i = 0; i < charArray.Length; i++)
            {
                Console.WriteLine(((char)charArray[i]) + " -> " + (charArray[i] - 97)); 
            }
        }
    }
}
