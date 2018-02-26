using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.HotPotato
{
    class HotPotato
    {
        static void Main()
        {
            string[] players = Console.ReadLine().Split(' ').ToArray();
            int num = int.Parse(Console.ReadLine());
            Queue<string> stack = new Queue<string>(players);

            while (stack.Count != 1)
            {
                for (int i = 1; i < num; i++)
                {
                    stack.Enqueue(stack.Dequeue());
                }
                Console.WriteLine($"Removed {stack.Dequeue()}");
            }

            Console.WriteLine($"Last is {stack.Dequeue()}");
        }
    }
}
