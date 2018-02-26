using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.LogsAggregator
{
    class LogsAggregator
    {
        static void Main()
        {
            int numEntries = int.Parse(Console.ReadLine());
            Dictionary<string, User> usersData = new Dictionary<string, User>();

            for (int i = 0; i < numEntries; i++)
            {
                string input = Console.ReadLine();

                CollectUserInfo(input, usersData);

            }

            PrintUserInfo(usersData);
        }

        private static void PrintUserInfo(Dictionary<string, User> usersData)
        {
            foreach (var user in usersData.OrderBy(u => u.Key))
            {
                Console.WriteLine($"{user.Key}: {user.Value.Duration} [{string.Join(", ", user.Value.setIPs)}]");
            }
        }

        private static void CollectUserInfo(string input, Dictionary<string, User> usersData)
        {
            string[] tokens = input.Split(' ');
            string currentIP = tokens[0];
            string userName = tokens[1];
            int duration = int.Parse(tokens[2]);

            if (!usersData.ContainsKey(userName))
            {
                User currentUser = new User();
                currentUser.Name = userName;
                currentUser.Duration = duration;
                currentUser.setIPs.Add(currentIP);

                usersData.Add(userName, currentUser);
            }
            else
            {
                usersData[userName].Duration += duration;
                usersData[userName].setIPs.Add(currentIP);
            }
        }

        class User
        {
            public string Name { get; set; }
            public int Duration { get; set; }
            public SortedSet<string> setIPs = new SortedSet<string>();
        }
    }
}
