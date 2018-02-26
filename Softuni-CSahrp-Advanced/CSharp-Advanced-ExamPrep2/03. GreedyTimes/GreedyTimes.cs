using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _03.GreedyTimes
{
    class GreedyTimes
    {
        class Bag
        {
            public BigInteger Capacity { get; set; }
            public BigInteger GoldAmount { get; set; }
            public BigInteger GemAmount { get; set; }
            public BigInteger CashAmount { get; set; }

            public Dictionary<string, BigInteger> Gems = new Dictionary<string, BigInteger>();
            public Dictionary<string, BigInteger> Cash = new Dictionary<string, BigInteger>();
        }

        static void Main()
        {
            Bag bag = new Bag();
            bag.Capacity = BigInteger.Parse(Console.ReadLine());
            Queue<string> itemsQueue = new Queue<string>(Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).ToArray());
            int length = itemsQueue.Count;

            
            for (int i = 0; i < length / 2; i++)
            {
                string item = itemsQueue.Dequeue();
                BigInteger currentAmount = BigInteger.Parse(itemsQueue.Dequeue());

                bool isBiggerThanCapacity = currentAmount + bag.GoldAmount + bag.GemAmount + bag.CashAmount > bag.Capacity;
                if (currentAmount > bag.Capacity)
                {
                    continue;
                }

                // gold
                if (item == "Gold")
                {
                    if (isBiggerThanCapacity)
                    {
                        continue;
                    }
                    bag.GoldAmount += currentAmount;
                }
                // gem
                else if (item.Length >= 4 && (item.EndsWith("Gem") || item.EndsWith("gem")))
                {
                    if (isBiggerThanCapacity || currentAmount + bag.GemAmount > bag.GoldAmount)
                    {
                        continue;
                    }

                    if (!bag.Gems.ContainsKey(item))
                    {
                        bag.Gems.Add(item, 0);
                    }

                    bag.Gems[item] += currentAmount;
                    bag.GemAmount += currentAmount;
                }
                // cash
                else if (item.All(Char.IsLetter) && item.Length == 3)
                {
                    if (isBiggerThanCapacity || currentAmount + bag.CashAmount > bag.GemAmount || currentAmount + bag.CashAmount > bag.GoldAmount)
                    {
                        continue;
                    }

                    if (!bag.Cash.ContainsKey(item))
                    {
                        bag.Cash.Add(item, 0);
                    }

                    bag.Cash[item] += currentAmount;
                    bag.CashAmount += currentAmount;
                }
            }

            PrintBag(bag);
        }

        private static void PrintBag(Bag bag)
        {
            if (bag.GoldAmount > 0)
            {
                Console.WriteLine($"<Gold> ${bag.GoldAmount}");
                Console.WriteLine($"##Gold - {bag.GoldAmount}");
            }

            if (bag.GemAmount > 0)
            {
                Console.WriteLine($"<Gem> ${bag.GemAmount}");
                foreach (var gem in bag.Gems.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{gem.Key} - {gem.Value}");
                }
            }

            if (bag.CashAmount > 0)
            {
                Console.WriteLine($"<Cash> ${bag.CashAmount}");
                foreach (var cash in bag.Cash.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{cash.Key} - {cash.Value}");
                }
            }
        }
    }
}
