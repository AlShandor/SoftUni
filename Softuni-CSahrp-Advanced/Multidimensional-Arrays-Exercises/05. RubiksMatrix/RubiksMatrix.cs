using System;
using System.Linq;

namespace _05.RubiksMatrix
{
    class RubiksMatrix
    {
        static void Main()
        {
            int[] matrixSizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            int[][] matrix = InitializeTheMatrix(rows, cols);

            int numCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCommands; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .ToArray();
                int startingIndex = int.Parse(tokens[0]);
                string direction = tokens[1];
                int moves = int.Parse(tokens[2]);

                switch (direction)
                {
                    case "up":
                        MoveColumn(matrix, startingIndex, moves);
                        break;
                    case "down":
                        MoveColumn(matrix, startingIndex, rows - moves % rows);
                        break;
                    case "left":
                        MoveRow(matrix, startingIndex, moves);
                        break;
                    case "right":
                        MoveRow(matrix, startingIndex, cols - moves % rows);
                        break;
                }
            }

            SwapAllElementsToOriginalPosition(matrix);
        }

        private static void SwapAllElementsToOriginalPosition(int[][] matrix)
        {
            int counter = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[r].Length; c++)
                            {
                                if (matrix[r][c] == counter)
                                {
                                    int temp = matrix[row][col];
                                    matrix[row][col] = counter;
                                    matrix[r][c] = temp;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                }
                            }
                        }
                    }
                    counter++;
                }
            }
        }

        private static void MoveRow(int[][] matrix, int startingIndex, int moves)
        {
            int[] tempRow = new int[matrix[0].Length];
            for (int col = 0; col < matrix[0].Length; col++)
            {
                tempRow[col] = matrix[startingIndex][(col + moves) % matrix[0].Length];
            }

            matrix[startingIndex] = tempRow;
        }

        private static void MoveColumn(int[][] matrix, int startingIndex, int moves)
        {
            int[] tempColumn = new int[matrix.Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                tempColumn[row] = matrix[(row + moves) % matrix.Length][startingIndex];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][startingIndex] = tempColumn[row];
            }
        }

        private static int[][] InitializeTheMatrix(int rows, int cols)
        {
            int[][] matrix = new int[rows][];
            int count = 1;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[cols];
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex][colIndex] = count;
                    count++;
                }
            }

            return matrix;
        }
    }
}
