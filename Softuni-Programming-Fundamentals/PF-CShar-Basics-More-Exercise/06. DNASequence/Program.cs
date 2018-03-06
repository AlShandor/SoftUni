using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program, which prints all the possible nucleic acid sequences(A, C, G and T), in the range[AAA…TTT]. Each
//nucleic acid sequence is exactly 3 nucleotides(letters) long. Print a new line every 4 sequences.
//Each nucleotide has a corresponding numeric value – A -> 1, C -> 2, G -> 3, T -> 4.
//For every sequence, take the sum of its elements(e.g.ACAC -> 1 + 2 + 1 + 2 = 6) and if it’s equal to or larger than
//the match sum, print the sequence with an “O” before and after it, otherwise print “X” before and after it.

namespace _06.DNASequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            char a = 'A';
            char c = 'C';
            char g = 'G';
            char t = 'T';

            char firstLastChar;
            char firstPosition;
            char secondPosition;
            char thirdPosition;

            for (int firstNucleic = 1; firstNucleic <= 4; firstNucleic++)
            {
                for (int secondNucleic = 1; secondNucleic <= 4; secondNucleic++)
                {
                    for (int thirdNucleic = 1; thirdNucleic <= 4; thirdNucleic++)
                    {

                        if (firstNucleic + secondNucleic + thirdNucleic >= sum)
                        {
                            firstLastChar = 'O';
                        }
                        else
                        {
                            firstLastChar = 'X';
                        }
                        switch (firstNucleic)
                        {
                            case 1:
                                firstPosition = a;
                                break;
                            case 2:
                                firstPosition = c;
                                break;
                            case 3:
                                firstPosition = g;
                                break;
                            case 4:
                                firstPosition = t;
                                break;
                            default:
                                firstPosition = a;
                                break;
                        }
                        switch (secondNucleic)
                        {
                            case 1:
                                secondPosition = a;
                                break;
                            case 2:
                                secondPosition = c;
                                break;
                            case 3:
                                secondPosition = g;
                                break;
                            case 4:
                                secondPosition = t;
                                break;
                            default:
                                secondPosition = a;
                                break;
                        }
                        switch (thirdNucleic)
                        {
                            case 1:
                                thirdPosition = a;
                                break;
                            case 2:
                                thirdPosition = c;
                                break;
                            case 3:
                                thirdPosition = g;
                                break;
                            case 4:
                                thirdPosition = t;
                                break;
                            default:
                                thirdPosition = a;
                                break;
                        }
                        Console.Write($"{firstLastChar}{firstPosition}{secondPosition}{thirdPosition}{firstLastChar} ");
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}
