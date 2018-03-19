using System;
using System.Text;

namespace _03.UnicodeCharactersV2
{
    class Program
    {
        static void Main()
        {
            string str = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                sb.Append("\\u");
                sb.Append(String.Format("{0:x4}", (int)c));
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
