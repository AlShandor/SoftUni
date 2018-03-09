﻿using System;
using System.IO;

namespace BashSoft
{
    public static class Tester
    {
        public static void CompareContent(string userOuputPath, string expectedOutputPath)
        {
            try
            {
                OutputWriter.WriteMessageOnNewLine("Reading files...");

                string mismatchPath = GetMismatchPath(expectedOutputPath);

                string[] actualOuputLines = File.ReadAllLines(userOuputPath);
                string[] exptectedOuputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatches;
                string[] mismatches = GetLinesWithPossibleMismatches(
                    actualOuputLines, exptectedOuputLines, out hasMismatches);

                PrintOutput(mismatches, hasMismatches, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (FileNotFoundException)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
            
        }

        private static void PrintOutput(string[] mismatches, bool hasMismatches, string mismatchPath)
        {
            if (hasMismatches)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }

                try
                {
                    File.WriteAllLines(mismatchPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                }
                
                return;
            }

            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
        }

        private static string[] GetLinesWithPossibleMismatches(string[] actualOuputLines, string[] exptectedOuputLines, out bool hasMismatches)
        {
            hasMismatches = false;
            string output = string.Empty;

            
            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            int minOutputLines = actualOuputLines.Length;
            if (actualOuputLines.Length != exptectedOuputLines.Length)
            {
                hasMismatches = true;
                minOutputLines = Math.Min(actualOuputLines.Length, exptectedOuputLines.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            string[] mismatches = new string[minOutputLines];
            for (int index = 0; index < minOutputLines; index++)
            {
                string actualLine = actualOuputLines[index];
                string expectedLine = exptectedOuputLines[index];

                if (!actualLine.Equals(expectedLine))
                {
                    output = string.Format(
                        $"Mismatch at line {index} -- expected: \"{expectedLine}\", actual: \"{actualLine}\"");
                    output += Environment.NewLine;
                    hasMismatches = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[index] = output;
            }

            return mismatches;
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"\Mismatch.txt";
            return finalPath;
        }
    }
}
    
