using System;
using System.Collections.Generic;

namespace Stacks_And_Queues_Lab
{
    class ReverseStrings
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input);

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}