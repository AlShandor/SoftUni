using System;
using System.Collections.Generic;

namespace _05.Phonebook
{
    class Phonebook
    {
        static void Main()
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "search")
                {
                    break;
                }

                string[] tokens = input.Split('-');
                string name = tokens[0];
                string phoneNumber = tokens[1];

                if (!phoneBook.ContainsKey(name))
                {
                    phoneBook.Add(name, phoneNumber);
                }
                phoneBook[name] = phoneNumber;
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }

                if (!phoneBook.ContainsKey(input))
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
                else if (phoneBook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phoneBook[input]}");
                }
            }
        }
    }
}
