using System;
using System.Text.RegularExpressions;

namespace _01.Extract_Emails
{
    class Program
    {
        static void Main()
        {
            string regex = @"(^|(?<=\s))(?<user>([^_\W]+[-\._]?([a-zA-Z0-9]+)?))@(?<host>[a-zA-Z0-9]+-?([a-zA-Z0-9]+)?\.[a-z]+\.?([a-z]+)?)\b";
            string input = Console.ReadLine();
            var matchedEmails = Regex.Matches(input, regex);
            foreach (Match email in matchedEmails)
            {
                Console.WriteLine(email.Value);
            }
        }
    }
}
