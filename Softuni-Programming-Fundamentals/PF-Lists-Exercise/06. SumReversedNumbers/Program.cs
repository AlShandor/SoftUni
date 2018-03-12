using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nums = Console.ReadLine()
                .Split(' ')
                .ToList();
            for(int num = 0; num < nums.Count; num++)
            {
                char[] cArray = nums[num].ToCharArray();
                string reverse = String.Empty;
                for (int i = cArray.Length - 1; i > -1; i--)
                {
                    reverse += cArray[i];
                }
                nums[num] = reverse;
            }
            List<int> numsInt = new List<int>();

            foreach (var num in nums)
            {
                numsInt.Add(int.Parse(num));
            }
            int result = 0;
            foreach (var num in numsInt)
            {
                result += num;
            }
            Console.WriteLine(result);
        }
    }
}
