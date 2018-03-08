using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.HornetArmada
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Legion> legions = new Dictionary<string, Legion>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                ReadLegionInfoAndPutToDic(legions);
            }
            string command = Console.ReadLine();

            PrintLegions(command, legions);
        }

        private static void PrintLegions(string command, Dictionary<string, Legion> legions)
        {
            string[] cmdTokens = command.Split('\\').ToArray();
            int lowerThanThisActivity = 0;
            string soldierType = "";
            if (cmdTokens.Length == 2)
            {
                lowerThanThisActivity = int.Parse(cmdTokens[0]);
                soldierType = cmdTokens[1];
                PrintLegionsToCount(lowerThanThisActivity, soldierType, legions);
            }
            else if (cmdTokens.Length == 1)
            {
                soldierType = cmdTokens[0];
                PrintLegionsToSoldierType(soldierType, legions);
            }
        }

        private static void PrintLegionsToSoldierType(string soldierType, Dictionary<string, Legion> legions)
        {
            Dictionary<string, long> legionsByActivity = new Dictionary<string, long>();
            foreach (var legion in legions)
            {
                if (legion.Value.SoldierList.Any(x => x.Type == soldierType))
                {
                    long activity = legion.Value.LastActivity;
                    legionsByActivity.Add(legion.Key, activity);
                }
            }
            foreach (var legion in legionsByActivity.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{legion.Value} : {legion.Key}");
            }
        }

        private static void PrintLegionsToCount(int lowerThanThisActivity, string soldierType, Dictionary<string, Legion> legions)
        {
            Dictionary<string, long> legionsByCount = new Dictionary<string, long>();
            foreach (var legion in legions)
            {
                if (legion.Value.SoldierList.Any(x => x.Type == soldierType) && legion.Value.LastActivity < lowerThanThisActivity)
                {
                    long soldCount = legion.Value.SoldierList.Where(x => x.Type == soldierType).First().Count;
                    legionsByCount.Add(legion.Key, soldCount);
                }
            }
            foreach (var legion in legionsByCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{legion.Key} -> {legion.Value}");
            }
        }

        private static void ReadLegionInfoAndPutToDic(Dictionary<string, Legion> legions)
        {
            string inputPattern = @"(\d+)\s\=\s(.+)\s\-\>\s(.+)\:(\d+)";
            Regex inputRegex = new Regex(inputPattern);
            Match inputMatch = inputRegex.Match(Console.ReadLine());

            int lastActivity = int.Parse(inputMatch.Groups[1].Value);
            string legionName = inputMatch.Groups[2].Value;
            string soldierType = inputMatch.Groups[3].Value;
            int soldierCount = int.Parse(inputMatch.Groups[4].Value); 

            // Create new Legion
            if (!legions.ContainsKey(legionName))
            {
                var newLegion = new Legion();
                var newSoldier = new Soldier();
                newLegion.LastActivity = lastActivity;
                newSoldier.Type = soldierType;
                newSoldier.Count = soldierCount;
                newLegion.SoldierList.Add(newSoldier);
                legions.Add(legionName, newLegion);
            }
            else
            {
                // Update last activity
                if (legions[legionName].LastActivity < lastActivity)
                {
                    legions[legionName].LastActivity = lastActivity;
                }

                // Add new Soldier Type
                if (!legions[legionName].SoldierList.Any(s => s.Type == soldierType))
                {
                    var newSoldier = new Soldier();
                    newSoldier.Type = soldierType;
                    newSoldier.Count = soldierCount;
                    legions[legionName].SoldierList.Add(newSoldier);
                }

                // Update Soldier Count
                if (legions[legionName].SoldierList.Any(s => s.Type == soldierType))
                {
                    var existingSoldier = legions[legionName].SoldierList.Where(s => s.Type == soldierType).First();
                    existingSoldier.Count += soldierCount;
                }
            }
        }

        class Legion
        {
            public long LastActivity { get; set; }
            public List<Soldier> SoldierList = new List<Soldier>();
        }

        class Soldier
        {
            public string Type { get; set; }
            public long Count { get; set; }
        }
    }
}
