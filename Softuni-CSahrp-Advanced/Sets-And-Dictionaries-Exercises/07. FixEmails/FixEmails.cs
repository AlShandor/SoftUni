using System;
using System.Collections.Generic;

namespace _07.FixEmails
{
    class FixEmails
    {
        static void Main()
        {
            Dictionary<string,string> dictEmails = new Dictionary<string, string>();

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "stop")
                {
                    break;
                }

                string email = Console.ReadLine();
                if (email.EndsWith(".us") || email.EndsWith(".uk"))
                {
                    continue;
                }

                if (!dictEmails.ContainsKey(name))
                {
                    dictEmails.Add(name, email);
                }

                dictEmails[name] = email;
            }

            foreach (var user in dictEmails)
            {
                Console.WriteLine($"{user.Key} -> {user.Value}");
            }
        }
    }
}
