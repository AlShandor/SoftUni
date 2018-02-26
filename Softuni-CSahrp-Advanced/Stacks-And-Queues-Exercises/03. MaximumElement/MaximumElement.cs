using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    class MaximumElement
    {
        static void Main()
        {
            int numOfQueries = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();
            Stack<long> maxNum = new Stack<long>();
            maxNum.Push(long.MinValue);

            for (int i = 0; i < numOfQueries; i++)
            {
                int[] tokens = Console.ReadLine().Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                int typeOfQuerie = tokens[0];
                if (typeOfQuerie == 1)
                {
                    int numToPush = tokens[1];
                    stack.Push(numToPush);
                    if (numToPush >= maxNum.Peek())
                    {
                        maxNum.Push(numToPush);
                    }
                }
                else if (typeOfQuerie == 2)
                {
                    if (stack.Peek() == maxNum.Peek())
                    {
                        maxNum.Pop();
                    }
                    stack.Pop();
                }
                else if (typeOfQuerie == 3)
                {
                    Console.WriteLine(maxNum.Peek());
                }
            }
        }
    }
}
