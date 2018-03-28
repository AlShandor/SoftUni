using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Startup
    {
        static void Main()
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long stones = 0;
            long money = 0;

            for (int currentItem = 0; currentItem < safe.Length; currentItem += 2)
            {
                string name = safe[currentItem];
                long quantity = long.Parse(safe[currentItem + 1]);
                string typeOfLoot = GetTypeOfLoot(name);

                bool canBeLooted = CheckIfItemCanBeLooted(typeOfLoot, quantity, bag, bagCapacity);
                if (!canBeLooted)
                {
                    continue;
                }

                AddItemToBag(bag, ref gold, ref stones, ref money, name, quantity, typeOfLoot);
            }

            PrintItemsInBag(bag);
        }

        private static void PrintItemsInBag(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var item in bag)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");
                foreach (var item2 in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private static void AddItemToBag(Dictionary<string, Dictionary<string, long>> bag, ref long gold, ref long stones, ref long money, string name, long quantity, string typeOfLoot)
        {
            if (!bag.ContainsKey(typeOfLoot))
            {
                bag[typeOfLoot] = new Dictionary<string, long>();
            }

            if (!bag[typeOfLoot].ContainsKey(name))
            {
                bag[typeOfLoot][name] = 0;
            }

            bag[typeOfLoot][name] += quantity;
            if (typeOfLoot == "Gold")
            {
                gold += quantity;
            }
            else if (typeOfLoot == "Gem")
            {
                stones += quantity;
            }
            else if (typeOfLoot == "Cash")
            {
                money += quantity;
            }
        }

        private static string GetTypeOfLoot(string name)
        {
            string typeOfLoot = String.Empty;
            
            if (name.Length == 3)
            {
                typeOfLoot = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                typeOfLoot = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                typeOfLoot = "Gold";
            }

            return typeOfLoot;
        }

        private static bool CheckIfItemCanBeLooted(string typeOfLoot, long quantity, Dictionary<string, Dictionary<string, long>> bag, long bagCapacity)
        {
            bool canBeLooted = true;
            switch (typeOfLoot)
            {
                case "Gem":
                    if (!bag.ContainsKey(typeOfLoot))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (quantity > bag["Gold"].Values.Sum())
                            {
                                canBeLooted = false;
                            }
                        }
                        else
                        {
                            canBeLooted = false;
                        }
                    }
                    else if (bag[typeOfLoot].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                    {
                        canBeLooted = false;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(typeOfLoot))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (quantity > bag["Gem"].Values.Sum())
                            {
                                canBeLooted = false;
                            }
                        }
                        else
                        {
                            canBeLooted = false;
                        }
                    }
                    else if (bag[typeOfLoot].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                    {
                        canBeLooted = false;
                    }
                    break;
                case "":
                    canBeLooted = false;
                    break;
            }

            if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
            {
                canBeLooted = false;
            }

            return canBeLooted;
        }
    }
}