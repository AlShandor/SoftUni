using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNumbers
{
    class ReverseNumbers
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(nums);

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
