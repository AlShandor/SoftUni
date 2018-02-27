using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TripleSum
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] array = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            bool isThereSolution = false;

            for (int a = 0; a < array.Length; a++)
            {
                for (int b = a + 1; b < array.Length; b++)
                {
                    for (int c = 0; c < array.Length; c++)
                    {
                        if (array[a] + array[b] == array[c])
                        {
                            Console.WriteLine($"{array[a]} + {array[b]} == {array[c]}");
                            isThereSolution = true;
                            break;
                        }
                    }
                }
            }

            if (!isThereSolution)
            {
                Console.WriteLine("No");
            }
        }
    }
}
