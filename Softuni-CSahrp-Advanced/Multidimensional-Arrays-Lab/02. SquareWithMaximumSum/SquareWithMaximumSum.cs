using System;
using System.Linq;

namespace _02.SquareWithMaximumSum
{
    class SquareWithMaximumSum
    {
        static void Main()
        {
            string[] matrixSizes = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);

            int[][] matrix = new int[int.Parse(matrixSizes[0])][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            int maxSum = int.MinValue;
            int maxRowIndex = 0;
            int maxColIndex = 0;
            for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 1; colIndex++)
                {
                    int squareSum = matrix[rowIndex][colIndex] + matrix[rowIndex + 1][colIndex]
                                                               + matrix[rowIndex][colIndex + 1] +
                                                               matrix[rowIndex + 1][colIndex + 1];

                    if (squareSum > maxSum)
                    {
                        maxSum = squareSum;
                        maxRowIndex = rowIndex;
                        maxColIndex = colIndex;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRowIndex][maxColIndex]} {matrix[maxRowIndex][maxColIndex + 1]}");
            Console.WriteLine($"{matrix[maxRowIndex + 1][maxColIndex]} {matrix[maxRowIndex + 1][maxColIndex + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
