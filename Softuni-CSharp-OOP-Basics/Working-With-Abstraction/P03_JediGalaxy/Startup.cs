using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Startup
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimestions[0];
            int cols = dimestions[1];

            int[,] matrix = InitializeMatrix(rows, cols);
            
            long ivoScore = 0;
            string command;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoCoordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilCoordinates = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                EvilDestroyCells(matrix, evilCoordinates);
                ivoScore += GetIvoScore(matrix, ivoCoordinates);
            }

            Console.WriteLine(ivoScore);
        }

        private static long GetIvoScore(int[,] matrix, int[] ivoCoordinates)
        {
            long score = 0;
            int xI = ivoCoordinates[0];
            int yI = ivoCoordinates[1];

            while (xI >= 0 && yI < matrix.GetLength(1))
            {
                if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                {
                    score += matrix[xI, yI];
                }

                yI++;
                xI--;
            }

            return score;
        }

        private static void EvilDestroyCells(int[,] matrix, int[] evilCoordinates)
        {
            int evilCurrentRow = evilCoordinates[0];
            int evilCurrentCol = evilCoordinates[1];
            while (evilCurrentRow >= 0 && evilCurrentCol >= 0)
            {
                if (evilCurrentRow >= 0 && evilCurrentRow < matrix.GetLength(0) && evilCurrentCol >= 0 && evilCurrentCol < matrix.GetLength(1))
                {
                    matrix[evilCurrentRow, evilCurrentCol] = 0;
                }
                evilCurrentRow--;
                evilCurrentCol--;
            }
        }

        private static int[,] InitializeMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            int value = 0;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex, colIndex] = value++;
                }
            }

            return matrix;
        }
    }
}
