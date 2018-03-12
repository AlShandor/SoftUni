using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine();
            while (command != "print")
            {
                List<string> commandLine = command
                .Split(' ')
                .ToList();
                
                switch (commandLine[0])
                {
                    case "add":
                        int index = int.Parse(commandLine[1]);
                        int value = int.Parse(commandLine[2]);
                        nums.Insert(index, value);
                        break;
                    case "addMany":
                        int indexToInsert = int.Parse(commandLine[1]);
                        int[] valueToInsert = commandLine
                            .Skip(2)
                            .Select(int.Parse)
                            .ToArray();
                        nums = AddManyToArr(nums, indexToInsert, valueToInsert);
                        break;
                    case "contains":
                        PrintContainsNum(nums, commandLine);
                        break;
                    case "remove":
                        int indexToRemove = int.Parse(commandLine[1]);
                        nums.RemoveAt(indexToRemove);
                        break;
                    case "shift":
                        int rotations = int.Parse(commandLine[1]);
                        nums = ShiftArrayLeftNTimes(nums, rotations);
                        break;
                    case "sumPairs":
                        nums = SumPairsInArr(nums);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("[" + string.Join(", ", nums) + "]");
        }

        private static List<int> SumPairsInArr(List<int> nums)
        {
            List<int> listsumsofpairs = new List<int>();
            for (int i = 0; i < nums.Count - 1; i += 2)
            {
                listsumsofpairs.Add(nums[i] + nums[i + 1]);
            }
            if (nums.Count % 2 == 1)
            {
                listsumsofpairs.Add(nums.Last());
            }
            return listsumsofpairs;
        }

        private static List<int> ShiftArrayLeftNTimes(List<int> nums, int rotations)
        {
            for (int i = 0; i < rotations; i++)
            {
                int temp = nums[0];
                for (int j = 0; j < nums.Count - 1; j++)
                {
                    nums[j] = nums[j + 1];
                }
                nums[nums.Count - 1] = temp;
            }
            return nums;
        }

        private static void PrintContainsNum(List<int> list, List<string> numToCheck)
        {
            int num = int.Parse(numToCheck[1]);
            Console.WriteLine(list.IndexOf(num));
        }

        private static List<int> AddManyToArr(List<int> nums, int index, int[] valueToInsert)
        {
            nums.InsertRange(index, valueToInsert);
            return nums;
        }
    }
}
