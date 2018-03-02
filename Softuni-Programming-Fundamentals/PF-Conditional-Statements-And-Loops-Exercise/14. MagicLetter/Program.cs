using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char thirdLetter = char.Parse(Console.ReadLine());

            for (int firstPosition = firstLetter; firstPosition <= secondLetter; firstPosition++)
            {
                for (int secondPosition = firstLetter; secondPosition <= secondLetter; secondPosition++)
                {
                    for (int thirdPosition = firstLetter; thirdPosition <= secondLetter; thirdPosition++)
                    {
                        if (firstPosition == thirdLetter || secondPosition == thirdLetter || thirdPosition == thirdLetter)
                        {
                            continue;
                        }
                        Console.Write($"{(char)firstPosition}{(char)secondPosition}{(char)thirdPosition} ");
                    }
                }
            }
        }
    }
}
