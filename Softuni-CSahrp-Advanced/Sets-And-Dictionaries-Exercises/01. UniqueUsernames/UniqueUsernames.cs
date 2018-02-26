using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class UniqueUsernames
    {
        static void Main()
        {
            int numUsers = int.Parse(Console.ReadLine());
            HashSet<string> setNames = new HashSet<string>();

            for (int i = 0; i < numUsers; i++)
            {
                string user = Console.ReadLine();
                setNames.Add(user);
            }

            foreach (var user in setNames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
