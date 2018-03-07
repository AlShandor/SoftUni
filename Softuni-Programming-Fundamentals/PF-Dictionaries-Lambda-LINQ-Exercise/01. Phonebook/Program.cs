using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string entry = Console.ReadLine();
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            while (entry != "END")
            {
                string[] commands = entry
                    .Split(' ')
                    .ToArray();
                string name = commands[1];
                if (commands[0] == "A")
                {
                    if (phonebook.ContainsKey(name))
                    {
                        phonebook[name] = commands[2];
                    }
                    else
                    {
                        phonebook.Add(name, commands[2]);
                    }
                }
                else if (commands[0] == "S")
                {
                    if (phonebook.ContainsKey(name))
                    {
                        Console.WriteLine(name + " -> " + phonebook[name]);
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }
                entry = Console.ReadLine();
            }
        }
    }
}
