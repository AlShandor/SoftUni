using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SearchForANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            List<int> commands = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int numberOfElementsToTake = commands[0];
            int numberOfElemToRemove = commands[1];
            int numToFind = commands[2];
            bool isNumToFindPresent = false;
            nums.Take(numberOfElementsToTake);
            nums.RemoveRange(0, numberOfElemToRemove);
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == numToFind)
                {
                    isNumToFindPresent = true;
                }
            }

            if (isNumToFindPresent)
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
