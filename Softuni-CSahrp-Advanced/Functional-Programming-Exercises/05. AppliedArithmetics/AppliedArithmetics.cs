using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Func<int[], int[]> addFunc = Add1ToInts;
            Func<int[], int[]> multiplyFunc = MultiplyIntsBy2;
            Func<int[], int[]> subtractFunc = Subtract1FromInts;
            Action<int[]> printAction = PrintInts;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                switch (input)
                {
                    case "add":
                        addFunc(nums);
                        break;
                    case "multiply":
                        multiplyFunc(nums);
                        break;
                    case "subtract":
                        subtractFunc(nums);
                        break;
                    case "print":
                        printAction(nums);
                        break;
                }
            }
        }

        public static int[] Add1ToInts(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i]++;
            }

            return ints;
        }

        public static int[] MultiplyIntsBy2(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] *= 2;
            }

            return ints;
        }

        public static int[] Subtract1FromInts(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] -= 1;
            }

            return ints;
        }

        public static void PrintInts(int[] ints)
        {
            Console.WriteLine(string.Join(" ", ints));
        }
    }
}
