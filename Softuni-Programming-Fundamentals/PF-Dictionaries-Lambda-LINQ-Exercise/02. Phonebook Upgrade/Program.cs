using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PhonebookUpgrade
{
    class Program
    {
        static void Main()
        {
            string entry = Console.ReadLine();
            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();
            while (entry != "END")
            {
                string[] commands = entry
                    .Split(' ')
                    .ToArray();
                if (commands[0] == "A")
                {
                    if (phonebook.ContainsKey(commands[1]))
                    {
                        phonebook[commands[1]] = commands[2];
                    }
                    else
                    {
                        phonebook.Add(commands[1], commands[2]);
                    }
                }
                else if (commands[0] == "S")
                {
                    if (phonebook.ContainsKey(commands[1]))
                    {
                        Console.WriteLine(commands[1] + " -> " + phonebook[commands[1]]);
                    }
                    else
                    {
                        Console.WriteLine($"Contact {commands[1]} does not exist.");
                    }
                }
                else if (commands[0] == "ListAll")
                {
                    foreach (var n in phonebook)
                    {
                        Console.WriteLine(n.Key + " -> " + n.Value);
                    }
                }
                entry = Console.ReadLine();
            }
        }
    }
}
