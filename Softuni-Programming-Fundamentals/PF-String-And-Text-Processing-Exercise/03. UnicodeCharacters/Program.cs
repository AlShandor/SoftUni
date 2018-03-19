using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.UnicodeCharacters
{
    class Program
    {
        static void Main()
        {
            char[] chars = Console.ReadLine().ToCharArray();
            List<string> charsToUnicode = new List<string>();
            for (int currentChar = 0; currentChar < chars.Length; currentChar++)
            {
                string str = "\\u" + ((int)chars[currentChar]).ToString("X4");
                charsToUnicode.Add(str);
            }
            Console.WriteLine(string.Join("", charsToUnicode));
        }
    }
}
