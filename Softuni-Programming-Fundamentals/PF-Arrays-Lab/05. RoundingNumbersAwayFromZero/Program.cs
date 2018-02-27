using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.RoundingNumbersAwayFromZero
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] ints = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            for (int i = 0; i < ints.Length; i++)
            {
                Console.WriteLine($"{ints[i]} => {Math.Round(ints[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
