using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.MathPotato
{
    class MathPotato
    {
        static void Main()
        {

            string[] players = Console.ReadLine().Split(' ').ToArray();
            int num = int.Parse(Console.ReadLine());
            Queue<string> stack = new Queue<string>(players);

            int cycle = 1;
            while (stack.Count != 1)
            {
                for (int i = 1; i < num; i++)
                {
                    stack.Enqueue(stack.Dequeue());
                }

                if (IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {stack.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {stack.Dequeue()}");

                }

                cycle++;
            }

            Console.WriteLine($"Last is {stack.Dequeue()}");
        }

        private static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
