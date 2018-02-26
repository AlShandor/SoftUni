using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] arr = input.Split(' ');
            Stack<string> stack = new Stack<string>(arr.Reverse());

            int result = 0;
            result += int.Parse(stack.Pop());
            for (int i = 0; i < (arr.Length - 1) / 2; i++)
            {
                string op = stack.Pop();
                int nextNum = int.Parse(stack.Pop());

                if (op == "+")
                {
                    result += nextNum;
                }
                else
                {
                    result -= nextNum;
                }
            }

            Console.WriteLine(result);
        }
    }
}
