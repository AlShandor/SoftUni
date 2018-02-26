using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.DragonArmy
{
    class DragonArmy
    {
        class Dragon
        {
            public string Name { get; set; }
            public int Damage { get; set; } = 45;
            public int Health { get; set; } = 250;
            public int Armor { get; set; } = 10;
        }

        static void Main()
        {
            Dictionary<string, SortedDictionary<string, Dragon>> typesOfDragons = new Dictionary<string, SortedDictionary<string, Dragon>>();
            int numberOfDragons = int.Parse(Console.ReadLine());

            for (int currentDragon = 0; currentDragon < numberOfDragons; currentDragon++)
            {
                string input = Console.ReadLine();
                CollectDragonStats(input, typesOfDragons);
            }

            PrintDragonStats(typesOfDragons);
        }

        private static void PrintDragonStats(Dictionary<string, SortedDictionary<string, Dragon>> typesOfDragons)
        {
            foreach (var type in typesOfDragons)
            {
                double[] averageStats = GetAverageStatsForTypeDragon(type);
                double averageDamage = averageStats[0];
                double averageHealth = averageStats[1];
                double averageArmor = averageStats[2];

                Console.WriteLine($"{type.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");
                foreach (var dragon in type.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.Damage}, health: {dragon.Value.Health}, armor: {dragon.Value.Armor}");
                }
            }
        }

        private static double[] GetAverageStatsForTypeDragon(KeyValuePair<string, SortedDictionary<string, Dragon>> type)
        {
            double[] averageStats = new double[3];
            double totalDamage = 0;
            foreach (var dragon in type.Value)
            {
                totalDamage += dragon.Value.Damage;
            }

            double averageDamage = totalDamage / type.Value.Count;

            double totalHealth = 0;
            foreach (var dragon in type.Value)
            {
                totalHealth += dragon.Value.Health;
            }

            double averageHealth = totalHealth / type.Value.Count;

            double totalArmor = 0;
            foreach (var dragon in type.Value)
            {
                totalArmor += dragon.Value.Armor;
            }

            double averageArmor = totalArmor / type.Value.Count;

            averageStats[0] = averageDamage;
            averageStats[1] = averageHealth;
            averageStats[2] = averageArmor;

            return averageStats;
        }

        private static void CollectDragonStats(string input, Dictionary<string, SortedDictionary<string, Dragon>> typesOfDragons)
        {
            string[] tokens = input.Split(' ').ToArray();
            string type = tokens[0];
            string name = tokens[1];
            string damage = tokens[2];
            string health = tokens[3];
            string armor = tokens[4];

            if (!typesOfDragons.ContainsKey(type))
            {
                Dragon currentDragon = CreateNewDragon(name, damage, health, armor);
                
                SortedDictionary<string, Dragon> dictionaryOfDragons = new SortedDictionary<string, Dragon>();
                dictionaryOfDragons.Add(name, currentDragon);

                typesOfDragons.Add(type, dictionaryOfDragons);
            }
            else
            {
                // If dragon with same name already exists, update its stats
                if (typesOfDragons[type].ContainsKey(name))
                {
                    typesOfDragons[type][name].Damage = damage == "null" ? 45 : int.Parse(damage);
                    typesOfDragons[type][name].Health = health == "null" ? 250 : int.Parse(health);
                    typesOfDragons[type][name].Armor = armor == "null" ? 10 : int.Parse(armor);
                }
                else
                {
                    Dragon currentDragon = CreateNewDragon(name, damage, health, armor);
                    typesOfDragons[type].Add(name, currentDragon);
                }
            }
        }

        private static Dragon CreateNewDragon(string name, string damage, string health, string armor)
        {
            Dragon currentDragon = new Dragon();
            currentDragon.Name = name;
            if (damage != "null")
            {
                currentDragon.Damage = int.Parse(damage);
            }
            if (health != "null")
            {
                currentDragon.Health = int.Parse(health);
            }
            if (armor != "null")
            {
                currentDragon.Armor = int.Parse(armor);
            }

            return currentDragon;
        }
    }
}
