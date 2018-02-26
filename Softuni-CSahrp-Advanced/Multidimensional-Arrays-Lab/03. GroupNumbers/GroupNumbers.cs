using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GroupNumbers
{
    class GroupNumbers
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < 3; i++)
            {
                matrix.Add(new List<int>());
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (Math.Abs(nums[i]) % 3 == 0)
                {
                    matrix[0].Add(nums[i]);
                }
                else if (Math.Abs(nums[i]) % 3 == 1)
                {
                    matrix[1].Add(nums[i]);
                }
                else if (Math.Abs(nums[i]) % 3 == 2)
                {
                    matrix[2].Add(nums[i]);
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
