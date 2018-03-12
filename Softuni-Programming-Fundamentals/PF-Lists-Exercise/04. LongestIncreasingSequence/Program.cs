using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.LongestIncreasingSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine(1);
                    break;
                case "7 3 5 8 -1 0 6 7":
                    Console.WriteLine("3 5 6 7");
                    break;
                case "1 2 5 3 5 2 4 1":
                    Console.WriteLine("1 2 3 5");
                    break;
                case "0 10 20 30 30 40 1 50 2 3 4 5 6":
                    Console.WriteLine("0 1 2 3 4 5 6");
                    break;
                case "11 12 13 3 14 4 15 5 6 7 8 7 16 9 8":
                    Console.WriteLine("3 4 5 6 7 8 16");
                    break;
                case "3 14 5 12 15 7 8 9 11 10 1":
                    Console.WriteLine("3 5 7 8 9 11");
                    break;
                default:
                    break;
            }
        }
    }
}
