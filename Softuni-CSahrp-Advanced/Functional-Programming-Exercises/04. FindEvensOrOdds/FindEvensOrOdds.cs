using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main()
        {
            var bounds = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var oddOrEven = Console.ReadLine().Trim().ToLower();

            Predicate<int> predicate;

            switch (oddOrEven)
            {
                case "odd":
                    predicate = n => n % 2 != 0;
                    break;
                case "even":
                    predicate = n => n % 2 == 0;
                    break;
                default:
                    predicate = null;
                    break;
            }

            List<int> nums = GetOddOrEvenNums(bounds, predicate);
            Console.WriteLine(string.Join(" ", nums));
        }

        public static List<int> GetOddOrEvenNums(int[] bounds, Predicate<int> predicate)
        {
            List<int> nums = new List<int>();
            int start = bounds[0];
            int end = bounds[1];

            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    nums.Add(i);
                }
            }

            return nums;
        }
    }
}
