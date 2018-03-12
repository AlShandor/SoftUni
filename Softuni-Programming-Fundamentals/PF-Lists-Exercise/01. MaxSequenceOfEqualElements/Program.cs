using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int mostFrequentNum = nums[0];
            int bestLength = 1;
            int length = 1;
            for (int i = 0; i < nums.Count - 1; i++)
            {
                int start = i;
                if (nums[i] == nums[i + 1])
                {
                    length++;
                    if (length > bestLength)
                    {
                        bestLength = length;
                        mostFrequentNum = nums[start];
                    }
                }
                if (nums[i] != nums[i + 1])
                {
                    length = 1;
                }
            }
            for (int i = 0; i < bestLength; i++)
            {
                Console.Write(mostFrequentNum + " ");
            }
        }
    }
}
