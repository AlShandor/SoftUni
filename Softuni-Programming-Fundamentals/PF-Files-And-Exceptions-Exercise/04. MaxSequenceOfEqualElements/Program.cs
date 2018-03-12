namespace _04.MaxSequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MaxSequenceEqualElements
    {
        public static void Main(string[] args)
        {
            byte[][] tests = File.ReadAllLines("../../Input.txt")
                .Select(line => line.Split(' ')
                .Select(byte.Parse)
                .ToArray())
                .ToArray();

            string[] result = new string[tests.Length];
            for (int i = 0; i < tests.Length; i++)
            {
                result[i] = $"{string.Join(" ", tests[i])}{Environment.NewLine}{MaxSequenceInString(tests[i])}{Environment.NewLine}";
            }

            File.WriteAllLines("../../Output.txt", result);
        }

        private static string MaxSequenceInString(byte[] digits)
        {
            Dictionary<byte, byte> digitOccurances = new Dictionary<byte, byte>();
            byte[] digitAndCount = new byte[2];

            foreach (byte digit in digits)
            {
                if (!digitOccurances.ContainsKey(digit))
                {
                    digitOccurances[digit] = 0;
                }

                digitOccurances[digit]++;

                if (digitOccurances[digit] > digitAndCount[1])
                {
                    digitAndCount[1] = digitOccurances[digit];
                    digitAndCount[0] = digit;
                }
            }

            return string.Join(" ", new string(digitAndCount[0].ToString()[0], digitAndCount[1]).ToCharArray());
        }
    }
}