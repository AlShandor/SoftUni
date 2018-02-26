using System;
using System.Linq;

namespace _03.SquaresInMatrix
{
    class SquaresInMatrix
    {
        static void Main()
        {
            int[] matrixSizes = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            char[][] charMatrix = new char[matrixSizes[0]][];

            for (int row = 0; row < charMatrix.Length; row++)
            {
                charMatrix[row] = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(char.Parse)
                                                    .ToArray();
            }

            int numEqualSquares = 0;

            for (int row = 0; row < charMatrix.Length - 1; row++)
            {
                for (int col = 0; col < matrixSizes[1] - 1; col++)
                {
                    if (charMatrix[row][col] == charMatrix[row][col + 1] &&
                        charMatrix[row][col] == charMatrix[row + 1][col] &&
                        charMatrix[row][col] == charMatrix[row + 1][col + 1])
                    {
                        numEqualSquares++;
                    }
                }
            }

            Console.WriteLine(numEqualSquares);
        }
    }
}
