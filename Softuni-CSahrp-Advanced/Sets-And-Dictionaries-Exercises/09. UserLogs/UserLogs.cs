using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.UserLogs
{
    class UserLogs
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> userLogs = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                PutInputToUserLogs(input, userLogs);
            }

            PrintUserLogs(userLogs);
        }

        private static void PrintUserLogs(Dictionary<string, Dictionary<string, int>> userLogs)
        {
            foreach (var user in userLogs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}:");
                Console.WriteLine($"{string.Join(", ", user.Value.Select(ip => $"{ip.Key} => {ip.Value}"))}.");
            }
        }

        private static void PutInputToUserLogs(string input, Dictionary<string, Dictionary<string, int>> userLogs)
        {
            string[] tokens = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            string userIP = tokens[0].Split('=').Skip(1).First();
            string userName = tokens[2].Split('=').Skip(1).First();

            if (!userLogs.ContainsKey(userName))
            {
                Dictionary<string, int> newUserIP = new Dictionary<string, int>();
                newUserIP.Add(userIP, 1);
                userLogs.Add(userName, newUserIP);
            }
            else
            {
                if (!userLogs[userName].ContainsKey(userIP))
                {
                    userLogs[userName][userIP] = 0;
                }

                userLogs[userName][userIP]++;
            }
        }
    }
}
