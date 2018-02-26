using System;
using System.Linq;

namespace _09.Crossfire
{
    class Crossfire
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[][] matrix = InitializeMatrix(rows, cols);

            while (true)
            {
                var input = Console.ReadLine().Trim();
                if (input == "Nuke it from orbit")
                {
                    break;
                }

                DestroyCells(matrix, input);
                RemoveEmptyCells(matrix);
            }

            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    Console.WriteLine(string.Join(" ", matrix[i].Where(c => c != 0)));
            //}

            PrintMatrix(matrix, rows, cols);
        }

        private static void RemoveEmptyCells(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        matrix[row][col] = matrix[row][col + 1];
                        matrix[row][col + 1] = 0;
                    }
                }
            }
        }

        private static void DestroyCells(int[][] matrix, string input)
        {
            int[] tokens = input.Split(' ').Select(int.Parse).ToArray();
            int nukeRow = tokens[0];
            int nukeCol = tokens[1];
            int radius = tokens[2];

            for (int rowIndex = nukeRow - radius; rowIndex <= nukeRow + radius; rowIndex++)
            {
                if (rowIndex >= 0 && rowIndex < matrix.Length && nukeCol >= 0 && nukeCol < matrix[0].Length)
                {
                    matrix[rowIndex][nukeCol] = 0;
                }
            }

            for (int colIndex = nukeCol - radius; colIndex <= nukeCol + radius; colIndex++)
            {
                if (nukeRow >= 0 && nukeRow < matrix.Length && colIndex >= 0 && colIndex < matrix[0].Length)
                {
                    matrix[nukeRow][colIndex] = 0;
                }
            }
        }

        private static void PrintMatrix(int[][] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                if (matrix[row].All(n => n == 0))
                {
                    continue;
                }
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.Write(matrix[row][col] + " ");
                    }

                }

                Console.WriteLine();
            }
        }

        private static int[][] InitializeMatrix(int rows, int cols)
        {
            int[][] matrix = new int[rows][];
            int count = 1;

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[cols];
                for (int colsIndex = 0; colsIndex < cols; colsIndex++)
                {
                    matrix[rowIndex][colsIndex] = count;
                    count++;
                }
            }
            return matrix;
        }
    }
}
