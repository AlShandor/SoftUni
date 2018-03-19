using System;
using System.Linq;

namespace _1.ReverseString
{
    class Program
    {
        static void Main()
        {
            string str = Console.ReadLine();
            string reverse = new string(str.Reverse().ToArray());
            Console.WriteLine(reverse);
        }
    }
}
