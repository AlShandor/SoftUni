using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CubicMessages
{
    class CubicMessages
    {
        static void Main()
        {
            while (true)
            {
                string pattern = @"^([0-9]+)([a-zA-Z]+)([^a-zA-Z]*)$";
                string input = Console.ReadLine();
                if (input == "Over!")
                {
                    break;
                }
                int messageLength = int.Parse(Console.ReadLine());

                var match = Regex.Match(input, pattern);
                if (match.Groups[2].Value.Length != messageLength)
                {
                    continue;
                }

                string message = match.Groups[2].Value;
                List<int> verificationCodeIndexes = GetVerificationIndexes(match);
                string verificationCode = GetVerificationCode(verificationCodeIndexes, match);
                Console.WriteLine($"{message} == {verificationCode}");
            }
        }

        private static string GetVerificationCode(List<int> verificationCodeIndexes, Match match)
        {
            string message = match.Groups[2].Value;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < verificationCodeIndexes.Count; i++)
            {
                if (verificationCodeIndexes[i] < 0 || verificationCodeIndexes[i] >= message.Length)
                {
                    sb.Append(" ");
                    continue;
                }

                sb.Append(message[verificationCodeIndexes[i]]);
            }

            return sb.ToString();
        }

        private static List<int> GetVerificationIndexes(Match match)
        {
            List<int> indexes = new List<int>();
            // get index from group 1
            for (int i = 0; i < match.Groups[1].Value.Length; i++)
            {
                indexes.Add(int.Parse(match.Groups[1].Value[i].ToString()));
            }

            // get indexes from group 2
            for (int i = 0; i < match.Groups[3].Value.Length; i++)
            {
                if (char.IsDigit(match.Groups[3].Value[i]))
                {
                    indexes.Add(int.Parse(match.Groups[3].Value[i].ToString()));
                }
            }

            return indexes;
        }
    }
}
