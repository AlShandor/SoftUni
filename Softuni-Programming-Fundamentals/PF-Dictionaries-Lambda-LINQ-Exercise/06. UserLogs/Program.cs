using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] userDetails = input.Split(' ').ToArray();
                string userName = userDetails[2].Split('=').Reverse().ToArray().First();
                string userIP = userDetails[0].Split('=').Reverse().ToArray().First();
                
                if (!users.ContainsKey(userName))
                {
                    users[userName] = new Dictionary<string, int>();
                }
                if (!users[userName].ContainsKey(userIP))
                {
                    users[userName][userIP] = 0;
                }
                users[userName][userIP]++;

                input = Console.ReadLine();
            }

            foreach (var u in users)
            {
                Console.WriteLine(u.Key + ":");
                Console.WriteLine(string.Join(", ", u.Value.Select(x => x.Key + " => " + x.Value)) + ".");
            }
        }
    }
}
