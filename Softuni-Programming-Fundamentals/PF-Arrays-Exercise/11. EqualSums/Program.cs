using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            bool isEqualSum = false;
            for (int i = 0; i < nums.Length; i++)
            {
                int leftSum = nums.Take(i).Sum();
                int rightSum = nums.Skip(i + 1).Sum();
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    isEqualSum = true;
                }
            }

            if (!isEqualSum)
            {
                Console.WriteLine("no");
            }
        }
    }
}
