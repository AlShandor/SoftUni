using System;
using System.Collections.Generic;

namespace _03.DecimalToBinaryConverter
{
    class DecimalToBinaryConverter
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            if (num == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (num != 0)
                {
                    stack.Push(num % 2);
                    num /= 2;
                }

                int length = stack.Count;
                for (int i = 0; i < length; i++)
                {
                    Console.Write(stack.Pop());
                }

                Console.WriteLine();
            }
        }
    }
}
