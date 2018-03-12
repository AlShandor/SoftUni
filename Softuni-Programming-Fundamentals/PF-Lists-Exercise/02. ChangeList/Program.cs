using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program, which reads a list of integers from the console and receives commands, which manipulate the list.
//Your program may receive the following commands:
// Delete {element} – delete all elements in the array, which are equal to the given element
// Insert {element} {position} – insert element and the given position
//You should stop the program when you receive the command Odd or Even.If you receive Odd  print all odd
//numbers in the array separated with single whitespace, otherwise print the even numbers.
namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nums = Console.ReadLine()
                .Split(' ')
                .ToList();

            string lastCommand = "";
            while (true)
            {
                List<string> commandList = Console.ReadLine().Split(' ').ToList();
                if (commandList[0] == "Odd" || commandList[0] == "Even")
                {
                    lastCommand = commandList[0];   
                    break;
                }
                switch (commandList[0])
                {
                    case "Delete":
                        DeleteAllElementsInArr(nums, commandList[1]);
                        break;
                    case "Insert":
                        nums.Insert(int.Parse(commandList[2]), commandList[1]);
                        break;
                    default:
                        break;
                }
            }

            if (lastCommand == "Odd")
            {
                PrintAllOddNumsInArr(nums);
            }
            else if (lastCommand == "Even")
            {
                PrintAllEvenNumsInArr(nums);
            }
        }

        private static void PrintAllEvenNumsInArr(List<string> array)
        {
            List<int> evenNums = array
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < evenNums.Count; i++)
            {
                if (evenNums[i] % 2 == 1)
                {
                    evenNums.Remove(evenNums[i]);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", evenNums));
        }

        private static void PrintAllOddNumsInArr(List<string> array)
        {
            List<int> oddNums = array
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < oddNums.Count; i++)
            {
                if (oddNums[i] % 2 == 0)
                {
                    oddNums.Remove(oddNums[i]);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", oddNums));
        }

        private static List<string> DeleteAllElementsInArr(List<string> array, string num)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] == num)
                {
                    array.Remove(array[i]);
                    i = -1;
                }
            }
            return array;
        }
    }
}
