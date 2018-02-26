using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            long[][] matrix = new long[matrixSize][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            }

            long firstDiagonalSum = 0;
            long secondDiagonalSum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                firstDiagonalSum += matrix[row][row];
                secondDiagonalSum += matrix[row][(matrix[row].Length - 1) - row];
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}
