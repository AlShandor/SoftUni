using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();
            string name = Console.ReadLine();
            while (name != "stop")
            {
                string email = Console.ReadLine();
                emails.Add(name, email);
                name = Console.ReadLine();
            }
            foreach (var e in emails.ToList())
            {
                if (e.Value.Split('.').Last() == "us" || e.Value.Split('.').Last() == "uk")
                {
                    emails.Remove(e.Key);
                }
            }
            foreach (var e in emails)
            {
                Console.WriteLine(e.Key + " -> " + e.Value);
            }
        }
    }
}
