using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DrawFilledSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintHeaderFooter(n);
            PrintBody(n);
            PrintHeaderFooter(n);

        }

        static void PrintBody(int number)
        {
            for (int i = 1; i <= number - 2; i++)
            {
                Console.Write('-');
                for (int k = 1; k <= number - 1; k++)
                {
                    Console.Write("\\/");
                }
                Console.Write('-');
                Console.WriteLine();
            }
        }

        static void PrintHeaderFooter(int number)
        {
            Console.WriteLine(new string('-', number * 2));
        }
    }
}
