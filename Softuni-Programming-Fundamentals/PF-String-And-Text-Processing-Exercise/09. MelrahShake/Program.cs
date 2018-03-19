using System;

namespace _09.MelrahShake
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                if (!String.IsNullOrEmpty(pattern) && hasTwoOccuranceOfPattern(input, pattern))
                {
                    int indexOfFirstOccurance = input.IndexOf(pattern);
                    int indexOfLastOccurance = input.LastIndexOf(pattern);
                    input = input.Remove(indexOfFirstOccurance, pattern.Length);
                    input = input.Remove(indexOfLastOccurance - pattern.Length, pattern.Length);
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("No shake.");
            Console.WriteLine(input);
        }

        private static bool hasTwoOccuranceOfPattern(string input, string pattern)
        {
            bool hasTwoOccurances = true;
            if (!input.Contains(pattern))
            {
                hasTwoOccurances = false;
            }
            int indexOfFirstOccurance = input.IndexOf(pattern);
            string substringAfterFirstOccurance = input.Substring(indexOfFirstOccurance + pattern.Length);
            try
            {
                int indexOfLastOccurance = substringAfterFirstOccurance.LastIndexOf(pattern);
            }
            catch
            {
                hasTwoOccurances = false;
            }
            
            return hasTwoOccurances;
        }
    }
}
