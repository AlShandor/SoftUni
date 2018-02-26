using System;
using System.Linq;

namespace _07.LegoBlocks
{
    class LegoBlocks
    {
        static void Main()
        {
            int arraysRows = int.Parse(Console.ReadLine());
            int[][] arrayA = new int[arraysRows][];
            int[][] arrayB = new int[arraysRows][];

            for (int row = 0; row < arrayA.Length; row++)
            {
                arrayA[row] = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            for (int row = 0; row < arrayB.Length; row++)
            {
                arrayB[row] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }
            
            for (int rowIndex = 0; rowIndex < arrayB.Length; rowIndex++)
            {
                arrayB[rowIndex] = arrayB[rowIndex].Reverse().ToArray();
            }

            int totalCountElements = arrayA[0].Length + arrayB[0].Length;

            bool isFitPerfect = true;
            for (int row = 1; row < arraysRows; row++)
            {
                if (arrayA[row].Length + arrayB[row].Length != totalCountElements)
                {
                    isFitPerfect = false;
                    break;
                }
            }

            if (isFitPerfect)
            {
                int[][] newArray = new int[arraysRows][];
                for (int row = 0; row < arraysRows; row++)
                {
                    newArray[row] = new int[arrayA[row].Length + arrayB[row].Length];
                    Array.Copy(arrayA[row], newArray[row], arrayA[row].Length);
                    Array.Copy(arrayB[row], 0, newArray[row], arrayA[row].Length, arrayB[row].Length);
                }

                foreach (var row in newArray)
                {
                    Console.WriteLine($"[{string.Join(", ", row)}]");
                }
            }
            else
            {
                int totalNumCells = 0;
                foreach (var row in arrayA)
                {
                    totalNumCells += row.Length;
                }

                foreach (var row in arrayB)
                {
                    totalNumCells += row.Length;
                }

                Console.WriteLine($"The total number of cells is: {totalNumCells}");
            }
        }
    }
}
