using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    class StackFibonacci
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < num - 1; i++)
            {
                long topNum = stack.Pop();
                long newNum = topNum + stack.Peek();
                stack.Push(topNum);
                stack.Push(newNum);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
