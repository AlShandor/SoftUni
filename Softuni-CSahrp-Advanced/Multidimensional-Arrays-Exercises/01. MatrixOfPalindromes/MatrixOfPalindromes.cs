using System;
using System.Linq;

namespace _01.MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[][] matrixPalindrome = new int[matrixSize[0]][];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < matrixPalindrome.Length; row++)
            {
                for (int col = 0; col < matrixSize[1]; col++)
                {
                    Console.Write($"{alphabet[row]}{alphabet[col + row]}{alphabet[row]} ");
                }

                Console.WriteLine();
            }

        }
    }
}
