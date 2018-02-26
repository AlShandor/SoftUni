using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RadioactiveBunnies
{
    class RadioactiveBunnies
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            char[][] matrix = InitializeMatrix(rows);
            int[] playerCoordinates = FindPlayerCoordiantes(matrix);
            Queue<char> commands = new Queue<char>(Console.ReadLine());
            ExecuteCommands(matrix, commands, playerCoordinates);
            
        }

        private static int[] FindPlayerCoordiantes(char[][] matrix)
        {
            int[] playerCoordinates = new int[2];
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        playerCoordinates[0] = row;
                        playerCoordinates[1] = col;
                    }
                }
            }

            return playerCoordinates;
        }

        private static void ExecuteCommands(char[][] matrix, Queue<char> commands, int[] playerCoordinates)
        {
            bool isGameOver = false;
            int numCommands = commands.Count;
            for (int currentCommand = 0; currentCommand < numCommands; currentCommand++)
            {
                char command = commands.Dequeue();
                switch (command)
                {
                    case 'U':
                        isGameOver = ExecuteUpCommand(matrix, playerCoordinates, isGameOver);
                        break;
                    case 'D':
                        isGameOver = ExecuteDownCommand(matrix, playerCoordinates, isGameOver);
                        break;
                    case 'L':
                        isGameOver = ExecuteLeftCommand(matrix, playerCoordinates, isGameOver);
                        break;
                    case 'R':
                        isGameOver = ExecuteRightCommands(matrix, playerCoordinates, isGameOver);
                        break;
                }

                isGameOver = MultiplyBunnies(matrix, isGameOver);

                if (isGameOver)
                {
                    return;
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool ExecuteRightCommands(char[][] matrix, int[] playerCoordinates, bool isGameOver)
        {
            isGameOver = false;
            matrix[playerCoordinates[0]][playerCoordinates[1]] = '.';
            playerCoordinates[1] += 1;
            
            if (playerCoordinates[1] >= matrix[playerCoordinates[0]].Length)
            {
                isGameOver = MultiplyBunnies(matrix, isGameOver);
                PrintMatrix(matrix);
                Console.WriteLine($"won: {playerCoordinates[0]} {matrix[playerCoordinates[0]].Length - 1}");
                isGameOver = true;
                return isGameOver;
            }
            else if (matrix[playerCoordinates[0]][playerCoordinates[1]] == 'B')
            {
                isGameOver = MultiplyBunnies(matrix, isGameOver);
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {playerCoordinates[0]} {playerCoordinates[1]}");
                isGameOver = true;
                return isGameOver;
            }

            matrix[playerCoordinates[0]][playerCoordinates[1]] = 'P';
            return isGameOver;
        }
        
        private static bool ExecuteLeftCommand(char[][] matrix, int[] playerCoordinates, bool isGameOver)
        {
            isGameOver = false;
            matrix[playerCoordinates[0]][playerCoordinates[1]] = '.';
            playerCoordinates[1] -= 1;

            if (playerCoordinates[1] < 0)
            {
                isGameOver = MultiplyBunnies(matrix, isGameOver);
                PrintMatrix(matrix);
                Console.WriteLine($"won: {playerCoordinates[0]} 0");
                isGameOver = true;
                return isGameOver;
            }
            else if (matrix[playerCoordinates[0]][playerCoordinates[1]] == 'B')
            {
                isGameOver = MultiplyBunnies(matrix, isGameOver);
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {playerCoordinates[0]} {playerCoordinates[1]}");
                isGameOver = true;
                return isGameOver;
            }

            matrix[playerCoordinates[0]][playerCoordinates[1]] = 'P';
            return isGameOver;
        }

        private static bool ExecuteDownCommand(char[][] matrix, int[] playerCoordinates, bool isGameOver)
        {
            isGameOver = false;
            matrix[playerCoordinates[0]][playerCoordinates[1]] = '.';
            playerCoordinates[0] += 1;

            if (playerCoordinates[0] >= matrix.Length)
            {
                isGameOver = MultiplyBunnies(matrix, isGameOver);
                PrintMatrix(matrix);
                Console.WriteLine($"won: {matrix.Length - 1} {playerCoordinates[1]}");
                isGameOver = true;
                return isGameOver;
            }
            else if (matrix[playerCoordinates[0]][playerCoordinates[1]] == 'B')
            {
                isGameOver = MultiplyBunnies(matrix, isGameOver);
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {playerCoordinates[0]} {playerCoordinates[1]}");
                isGameOver = true;
                return isGameOver;
            }

            matrix[playerCoordinates[0]][playerCoordinates[1]] = 'P';
            return isGameOver;
        }

        private static bool ExecuteUpCommand(char[][] matrix, int[] playerCoordinates, bool isGameOver)
        {
            isGameOver = false;
            matrix[playerCoordinates[0]][playerCoordinates[1]] = '.';
            playerCoordinates[0] -= 1;

            if (playerCoordinates[0] < 0)
            {
                isGameOver = MultiplyBunnies(matrix, isGameOver);
                PrintMatrix(matrix);
                Console.WriteLine($"won: 0 {playerCoordinates[1]}");
                isGameOver = true;
                return isGameOver;
            }
            else if (matrix[playerCoordinates[0]][playerCoordinates[1]] == 'B')
            {
                isGameOver = MultiplyBunnies(matrix, isGameOver);
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {playerCoordinates[0]} {playerCoordinates[1]}");
                isGameOver = true;
                return isGameOver;
            }

            matrix[playerCoordinates[0]][playerCoordinates[1]] = 'P';
            return isGameOver;
        }

        private static char[][] InitializeMatrix(int rows)
        {
            char[][] matrix = new char[rows][];
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine().ToCharArray();
            }

            return matrix;
        }

        private static bool MultiplyBunnies(char[][] matrix, bool isGameOver)
        {
            // Find position of new bunnies
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        
                        if (row - 1 >= 0)
                        {
                            if (matrix[row - 1][col] == 'P')
                            {
                                isGameOver = true;
                            }
                            matrix[row - 1][col] = 'C';
                        }

                        if (row + 1 < matrix.Length)
                        {
                            if (matrix[row + 1][col] == 'P')
                            {
                                isGameOver = true;
                            }
                            matrix[row + 1][col] = 'C';
                        }

                        if (col - 1 >= 0)
                        {
                            if (matrix[row][col - 1] == 'P')
                            {
                                isGameOver = true;
                            }
                            matrix[row][col - 1] = 'C';
                        }

                        if (col + 1 < matrix[row].Length)
                        {
                            if (matrix[row][col + 1] == 'P')
                            {
                                isGameOver = true;
                            }
                            matrix[row][col + 1] = 'C';
                        }
                    }
                }
            }

            // Put new bunnies in place
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'C')
                    {
                        matrix[row][col] = 'B';
                    }
                }
            }

            return isGameOver;
        }
    }
}
