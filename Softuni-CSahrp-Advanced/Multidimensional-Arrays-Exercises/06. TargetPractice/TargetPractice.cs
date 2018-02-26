using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TargetPractice
{
    class TargetPractice
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string snakeWord = Console.ReadLine();
            int[] shotParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[][] matrix = CreateMatrixWithSnakeWord(rows, cols, snakeWord);
            ShootSnakes(matrix, shotParams);
            ElementsFallDown(matrix);

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void ElementsFallDown(char[][] matrix)
        {
            for (int cycles = 0; cycles < matrix.Length - 1; cycles++)
            {
                for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                    {
                        if (matrix[rowIndex + 1][colIndex] == ' ')
                        {
                            matrix[rowIndex + 1][colIndex] = matrix[rowIndex][colIndex];
                            matrix[rowIndex][colIndex] = ' ';
                        }
                    }
                }
            }
        }

        private static void ShootSnakes(char[][] matrix, int[] shotParams)
        {
            int shotRow = shotParams[0];
            int shotCol = shotParams[1];
            int radius = shotParams[2];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    double distance = Math.Sqrt((rowIndex - shotRow) * (rowIndex - shotRow) + (colIndex - shotCol) * (colIndex - shotCol));
                    if (distance <= radius)
                    {
                        matrix[rowIndex][colIndex] = ' ';
                    }
                }
            }
        }

        private static char[][] CreateMatrixWithSnakeWord(int rows, int cols, string snakeWord)
        {
            char[][] matrix = new char[rows][];
            Queue<char> wordQueue = new Queue<char>(snakeWord);
            if (rows % 2 == 1)
            {
                for (int rowIndex = matrix.Length - 1; rowIndex >= 0; rowIndex--)
                {
                    matrix[rowIndex] = new char[cols];
                    if (rowIndex % 2 == 0)
                    {
                        for (int colIndex = matrix[rowIndex].Length - 1; colIndex >= 0; colIndex--)
                        {
                            matrix[rowIndex][colIndex] = wordQueue.Dequeue();
                            wordQueue.Enqueue(matrix[rowIndex][colIndex]);
                        }
                    }
                    else
                    {
                        for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                        {
                            matrix[rowIndex][colIndex] = wordQueue.Dequeue();
                            wordQueue.Enqueue(matrix[rowIndex][colIndex]);
                        }
                    }
                }
            }
            else
            {
                for (int rowIndex = matrix.Length - 1; rowIndex >= 0; rowIndex--)
                {
                    matrix[rowIndex] = new char[cols];
                    if (rowIndex % 2 == 1)
                    {
                        for (int colIndex = matrix[rowIndex].Length - 1; colIndex >= 0; colIndex--)
                        {
                            matrix[rowIndex][colIndex] = wordQueue.Dequeue();
                            wordQueue.Enqueue(matrix[rowIndex][colIndex]);
                        }
                    }
                    else
                    {
                        for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                        {
                            matrix[rowIndex][colIndex] = wordQueue.Dequeue();
                            wordQueue.Enqueue(matrix[rowIndex][colIndex]);
                        }
                    }
                }
            }
            
            return matrix;
        }
    }
}
