using System;
using System.IO;

namespace E02_LineNumbers
{
    public class LineNumbers
    {
        private const string path = "Files/";

        public static void Main()
        {
            Console.WriteLine($"Read file '{path}text.txt'");
            Console.WriteLine($"Insert line numbers & write text to '{path}textLineNumbers.txt'");

            using (var reader = new StreamReader($"{path}text.txt"))
            {
                using (var writer = new StreamWriter($"{path}textLineNumbers.txt"))
                {
                    int lineNumbers = 0;
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null) break;

                        writer.WriteLine($"Line {++lineNumbers}: {line}");
                    }
                }
            }
        }
    }
}