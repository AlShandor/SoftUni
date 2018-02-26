using System;

namespace _02.KnightGame
{
    class KnightGame
    {
        static void Main()
        {
            int dimension = int.Parse(Console.ReadLine());

            char[][] matrix = ReadMatrix(dimension);

            int knightsRemoved = 0;
            while (true)
            {
                int maxKnightsAttacked = -1;
                int maxRow = -1;
                int maxCol = -1;
                for (int row = 0; row < dimension; row++)
                {
                    for (int col = 0; col < dimension; col++)
                    {
                        int currentNumOfAttackedKnights = CountNumOfAttackedKnights(matrix, row, col);
                        if (currentNumOfAttackedKnights > maxKnightsAttacked)
                        {
                            maxKnightsAttacked = currentNumOfAttackedKnights;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }

                if (maxKnightsAttacked > 0)
                {
                    matrix[maxRow][maxCol] = '0';
                    knightsRemoved++;
                }

                if (maxKnightsAttacked == 0)
                {
                    break;
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        private static int CountNumOfAttackedKnights(char[][] matrix, int row, int col)
        {
            int numOfAttackedKnights = 0;
            int length = matrix.Length;

            // 12 left
            if (row - 2 >= 0 && col - 1 >= 0 && matrix[row - 2][col - 1] == 'K' && matrix[row][col] == 'K')
            {
                numOfAttackedKnights++;
            }

            // 12 right
            if (row - 2 >= 0 && col + 1 < length && matrix[row - 2][col + 1] == 'K' && matrix[row][col] == 'K')
            {
                numOfAttackedKnights++;
            }

            // 3 up
            if (row - 1 >= 0 && col + 2 < length && matrix[row - 1][col + 2] == 'K' && matrix[row][col] == 'K')
            {
                numOfAttackedKnights++;
            }

            // 3 down
            if (row + 1 < length && col + 2 < length && matrix[row + 1][col + 2] == 'K' && matrix[row][col] == 'K')
            {
                numOfAttackedKnights++;
            }

            // 6 left
            if (row + 2 < length && col - 1 >= 0 && matrix[row + 2][col - 1] == 'K' && matrix[row][col] == 'K')
            {
                numOfAttackedKnights++;
            }

            // 6 right
            if (row + 2 < length && col + 1 < length && matrix[row + 2][col + 1] == 'K' && matrix[row][col] == 'K')
            {
                numOfAttackedKnights++;
            }

            // 9 up
            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1][col - 2] == 'K' && matrix[row][col] == 'K')
            {
                numOfAttackedKnights++;
            }

            // 9 down
            if (row + 1 < length && col - 2 >= 0 && matrix[row + 1][col - 2] == 'K' && matrix[row][col] == 'K')
            {
                numOfAttackedKnights++;
            }

            return numOfAttackedKnights;
        }

        private static char[][] ReadMatrix(int dimension)
        {
            char[][] matrix = new char[dimension][];
            for (int row = 0; row < dimension; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            return matrix;
        }
    }
}
