using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.X
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char x = 'x';
            char blank = ' ';

            int middleBlank = n - 2;
            for (int currentRow = 0; currentRow < n / 2; currentRow++)
            {
                Console.Write(new string(blank, currentRow));
                Console.Write(x);
                Console.Write(new string(blank, middleBlank));
                Console.Write(x);
                Console.WriteLine();
                middleBlank -= 2;
            }

            Console.Write(new string(blank, n / 2));
            Console.Write(x);
            Console.Write(new string(blank, n / 2));
            Console.WriteLine();

            int blankBottomSide = (n / 2) - 1;
            int blankBottomMiddle = 1;
            for (int currentRow = 0; currentRow < n / 2; currentRow++)
            {
                Console.Write(new string(blank, blankBottomSide));
                Console.Write(x);
                Console.Write(new string(blank, blankBottomMiddle));
                Console.Write(x);
                Console.WriteLine();
                blankBottomSide--;
                blankBottomMiddle += 2;
            }
        }
    }
}
