using System;
using System.Linq;

namespace _04.MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            int[][] matrix = InitializeMatrix();

            PrintSubMatrixWithMaxSum(matrix);
        }

        private static void PrintSubMatrixWithMaxSum(int[][] matrix)
        {
            int maxSumRowIndex = 0;
            int maxSumColIndex = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                                     matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                                     matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSumRowIndex = row;
                        maxSumColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[maxSumRowIndex][maxSumColIndex]} {matrix[maxSumRowIndex][maxSumColIndex + 1]} {matrix[maxSumRowIndex][maxSumColIndex + 2]}");
            Console.WriteLine($"{matrix[maxSumRowIndex + 1][maxSumColIndex]} {matrix[maxSumRowIndex + 1][maxSumColIndex + 1]} {matrix[maxSumRowIndex + 1][maxSumColIndex + 2]}");
            Console.WriteLine($"{matrix[maxSumRowIndex + 2][maxSumColIndex]} {matrix[maxSumRowIndex + 2][maxSumColIndex + 1]} {matrix[maxSumRowIndex + 2][maxSumColIndex + 2]}");
        }

        private static int[][] InitializeMatrix()
        {
            int[] matrixSizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[matrixSizes[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            return matrix;
        }
    }
}
