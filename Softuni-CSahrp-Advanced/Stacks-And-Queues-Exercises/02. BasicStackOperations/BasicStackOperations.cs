using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main()
        {
            int[] tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>();
            
            int numToPush = tokens[0];
            int numToPop = tokens[1];
            int numIfPresent = tokens[2];

            for (int i = 0; i < numToPush; i++)
            {
                stack.Push(nums[i]);
            }

            for (int i = 0; i < numToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(numIfPresent))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
