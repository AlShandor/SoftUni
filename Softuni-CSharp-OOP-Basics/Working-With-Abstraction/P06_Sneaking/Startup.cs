using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static Sam sam = new Sam();
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            room = InitializeRoom(rows);
            
            var moves = Console.ReadLine().ToCharArray();
            sam = GetSamPosition(room);
            
            for (int i = 0; i < moves.Length; i++)
            {
                MoveGuards(room);

                int[] getEnemy = new int[2];
                bool isSamSpotted = CheckIfSamSpotted(room, getEnemy);
                if (isSamSpotted)
                {
                    break;
                }

                MoveSam(room, sam, moves, i);
                
                for (int j = 0; j < room[sam.Row].Length; j++)
                {
                    if (room[sam.Row][j] != '.' && room[sam.Row][j] != 'S')
                    {
                        getEnemy[0] = sam.Row;
                        getEnemy[1] = j;
                    }
                }

                if (room[getEnemy[0]][getEnemy[1]] == 'N' && sam.Row == getEnemy[0])
                {
                    room[getEnemy[0]][getEnemy[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }

                    break;
                }
            }
        }

        private static void MoveSam(char[][] room, Sam sam, char[] moves, int i)
        {
            room[sam.Row][sam.Col] = '.';
            switch (moves[i])
            {
                case 'U':
                    sam.Row--;
                    break;
                case 'D':
                    sam.Row++;
                    break;
                case 'L':
                    sam.Col--;
                    break;
                case 'R':
                    sam.Col++;
                    break;
                default:
                    break;
            }
            room[sam.Row][sam.Col] = 'S';
        }

        private static bool CheckIfSamSpotted(char[][] room, int[] getEnemy)
        {
            bool isSamSpotted = false;
            
            for (int j = 0; j < room[sam.Row].Length; j++)
            {
                if (room[sam.Row][j] != '.' && room[sam.Row][j] != 'S')
                {
                    getEnemy[0] = sam.Row;
                    getEnemy[1] = j;
                }
            }
            if (sam.Col < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == sam.Row)
            {
                room[sam.Row][sam.Col] = 'X';
                Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        Console.Write(room[row][col]);
                    }
                    Console.WriteLine();
                }

                isSamSpotted = true;
            }
            else if (getEnemy[1] < sam.Col && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == sam.Row)
            {
                room[sam.Row][sam.Col] = 'X';
                Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        Console.Write(room[row][col]);
                    }
                    Console.WriteLine();
                }

                isSamSpotted = true;
            }

            return isSamSpotted;
        }

        private static void MoveGuards(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static Sam GetSamPosition(char[][] room)
        {
            Sam sam = new Sam();
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        sam.Row = row;
                        sam.Col = col;
                    }
                }
            }

            return sam;
        }

        private static char[][] InitializeRoom(int rows)
        {
            char[][] room = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }

            return room;
        }
    }
}
