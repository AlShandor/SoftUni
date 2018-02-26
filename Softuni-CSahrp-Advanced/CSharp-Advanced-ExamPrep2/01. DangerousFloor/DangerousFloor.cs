using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DangerousFloor
{
    class DangerousFloor
    {
        static void Main()
        {
            char[][] matrix = CreateChessBoard();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                char piece = input[0];
                int startRow = int.Parse(input[1].ToString());
                int startCol = int.Parse(input[2].ToString());
                int endRow = int.Parse(input[4].ToString());
                int endCol = int.Parse(input[5].ToString());

                // Check if there is such piece on this square
                if (matrix[startRow][startCol] != piece)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                // Check if piece go out of board
                if (IsPieceOutOfBoard(endRow, endCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                // Check if piece make invalid move
                if (!IsValidMove(piece, startRow, startCol, endRow, endCol))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                MovePieceToNewSquare(matrix, piece, startRow, startCol, endRow, endCol);
            }
        }

        private static bool IsValidMove(char piece, int startRow, int startCol, int endRow, int endCol)
        {
            bool isValidMove = false;
            List<int> newSquare = new List<int>() { endRow, endCol };
            List<List<int>> availableMoves = new List<List<int>>();
            switch (piece)
            {
                case 'K':
                    availableMoves = GetKingMoves(startRow, startCol);
                    isValidMove = CanPieceMoveThere(availableMoves, newSquare);
                    break;
                case 'R':
                    availableMoves = GetRookMoves(startRow, startCol);
                    isValidMove = CanPieceMoveThere(availableMoves, newSquare);
                    break;
                case 'B':
                    availableMoves = GetBishopMoves(startRow, startCol);
                    isValidMove = CanPieceMoveThere(availableMoves, newSquare);
                    break;
                case 'Q':
                    availableMoves = GetQueenMoves(startRow, startCol);
                    isValidMove = CanPieceMoveThere(availableMoves, newSquare);
                    break;
                case 'P':
                    availableMoves = GetPawnMoves(startRow, startCol);
                    isValidMove = CanPieceMoveThere(availableMoves, newSquare);
                    break;

            }

            return isValidMove;
        }

        private static List<List<int>> GetPawnMoves(int startRow, int startCol)
        {
            List<List<int>> availableMoves = new List<List<int>>();
            if (startRow - 1 < 8)
            {
                List<int> move = new List<int>() { startRow - 1, startCol };
                availableMoves.Add(move);
            }

            return availableMoves;
        }

        private static List<List<int>> GetQueenMoves(int startRow, int startCol)
        {
            List<List<int>> availableMoves = new List<List<int>>();
            // down right
            int currentRow = startRow;
            int currentCol = startCol;
            while (true)
            {

                List<int> move = new List<int>() { currentRow, currentCol };
                availableMoves.Add(move);
                currentRow++;
                currentCol++;
                if (currentRow == 8 || currentCol == 8)
                {
                    break;
                }
            }

            // down left
            currentRow = startRow + 1;
            currentCol = startCol - 1;
            while (true)
            {
                List<int> move = new List<int>() { currentRow, currentCol };
                availableMoves.Add(move);
                currentRow++;
                currentCol--;
                if (currentRow == 8 || currentCol == -1)
                {
                    break;
                }
            }

            // up right
            currentRow = startRow - 1;
            currentCol = startCol + 1;
            while (true)
            {
                List<int> move = new List<int>() { currentRow, currentCol };
                availableMoves.Add(move);
                currentRow--;
                currentCol++;
                if (currentRow == -1 || currentCol == 8)
                {
                    break;
                }
            }

            // up left
            currentRow = startRow - 1;
            currentCol = startCol - 1;
            while (true)
            {
                List<int> move = new List<int>() { currentRow, currentCol };
                availableMoves.Add(move);
                currentRow--;
                currentCol--;
                if (currentRow == -1 || currentCol == -1)
                {
                    break;
                }
            }

            for (int col = 0; col < 8; col++)
            {
                List<int> move = new List<int>() { startRow, col };
                availableMoves.Add(move);
            }

            for (int row = 0; row < 8; row++)
            {
                List<int> move = new List<int>() { row, startCol };
                availableMoves.Add(move);
            }
            return availableMoves;
        }

        private static List<List<int>> GetBishopMoves(int startRow, int startCol)
        {
            List<List<int>> availableMoves = new List<List<int>>();
            // down right
            int currentRow = startRow;
            int currentCol = startCol;
            while (true)
            {

                List<int> move = new List<int>() { currentRow, currentCol };
                availableMoves.Add(move);
                currentRow++;
                currentCol++;
                if (currentRow == 8 || currentCol == 8)
                {
                    break;
                }
            }

            // down left
            currentRow = startRow + 1;
            currentCol = startCol - 1;
            while (true)
            {
                List<int> move = new List<int>() { currentRow, currentCol };
                availableMoves.Add(move);
                currentRow++;
                currentCol--;
                if (currentRow == 8 || currentCol == -1)
                {
                    break;
                }
            }

            // up right
            currentRow = startRow - 1;
            currentCol = startCol + 1;
            while (true)
            {
                List<int> move = new List<int>() { currentRow, currentCol };
                availableMoves.Add(move);
                currentRow--;
                currentCol++;
                if (currentRow == -1 || currentCol == 8)
                {
                    break;
                }
            }

            // up left
            currentRow = startRow - 1;
            currentCol = startCol - 1;
            while (true)
            {
                List<int> move = new List<int>() { currentRow, currentCol };
                availableMoves.Add(move);
                currentRow--;
                currentCol--;
                if (currentRow == -1 || currentCol == -1)
                {
                    break;
                }
            }

            return availableMoves;
        }

        private static List<List<int>> GetRookMoves(int startRow, int startCol)
        {
            List<List<int>> availableMoves = new List<List<int>>();
            for (int col = 0; col < 8; col++)
            {
                List<int> move = new List<int>() { startRow, col };
                availableMoves.Add(move);
            }

            for (int row = 0; row < 8; row++)
            {
                List<int> move = new List<int>() { row, startCol };
                availableMoves.Add(move);
            }

            return availableMoves;
        }

        private static bool CanPieceMoveThere(List<List<int>> availableMoves, List<int> newSquare)
        {
            foreach (var availableMove in availableMoves)
            {
                if (availableMove[0] == newSquare[0] && availableMove[1] == newSquare[1])
                {
                    return true;
                }
            }

            return false;
        }

        private static List<List<int>> GetKingMoves(int startRow, int startCol)
        {
            List<List<int>> availableMoves = new List<List<int>>();

            // row 1, left
            if (startRow - 1 >= 0 && startCol - 1 >= 0)
            {
                List<int> move = new List<int>() { startRow - 1, startCol - 1 };
                availableMoves.Add(move);
            }

            // row 1, center
            if (startRow - 1 >= 0)
            {
                List<int> move = new List<int>() { startRow - 1, startCol };
                availableMoves.Add(move);
            }

            // row 1, right
            if (startRow - 1 >= 0 && startCol + 1 <= 7)
            {
                List<int> move = new List<int>() { startRow - 1, startCol + 1 };
                availableMoves.Add(move);
            }

            // row 2, left
            if (startCol - 1 >= 0)
            {
                List<int> move = new List<int>() { startRow, startCol - 1 };
                availableMoves.Add(move);
            }

            // row 2, right
            if (startCol + 1 <= 7)
            {
                List<int> move = new List<int>() { startRow, startCol + 1 };
                availableMoves.Add(move);
            }

            // row 3, left
            if (startRow + 1 <= 7 && startCol - 1 >= 0)
            {
                List<int> move = new List<int>() { startRow + 1, startCol - 1 };
                availableMoves.Add(move);
            }

            // row 3, center
            if (startRow + 1 <= 7)
            {
                List<int> move = new List<int>() { startRow + 1, startCol };
                availableMoves.Add(move);
            }

            // row 3, left
            if (startRow + 1 <= 7 && startCol + 1 <= 7)
            {
                List<int> move = new List<int>() { startRow + 1, startCol + 1 };
                availableMoves.Add(move);
            }

            return availableMoves;
        }

        private static void MovePieceToNewSquare(char[][] matrix, char piece, int startRow, int startCol, int endRow, int endCol)
        {
            matrix[startRow][startCol] = 'x';
            matrix[endRow][endCol] = piece;
        }

        private static bool IsPieceOutOfBoard(int endRow, int endCol)
        {
            bool isPieceOutOfBoard = false || (endRow < 0 || endRow > 7 || endCol < 0 || endCol > 7);

            return isPieceOutOfBoard;
        }

        private static char[][] CreateChessBoard()
        {
            char[][] matrix = new char[8][];
            for (int rowIndex = 0; rowIndex < 8; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
            }

            return matrix;
        }
    }
}
