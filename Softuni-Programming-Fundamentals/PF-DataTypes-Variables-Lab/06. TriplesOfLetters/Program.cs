using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TriplesOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int firstPosition = 1; firstPosition <= num; firstPosition++)
            {
                for (int secondPosition = 1; secondPosition <= num; secondPosition++)
                {
                    for (int thirdPosition = 1; thirdPosition <= num; thirdPosition++)
                    {
                        char a = (char)('a' - 1 + firstPosition);
                        char b = (char)('a' - 1 + secondPosition);
                        char c = (char)('a' - 1 + thirdPosition);
                        Console.WriteLine($"{a}{b}{c}");
                    }
                }
            }
        }
    }
}
