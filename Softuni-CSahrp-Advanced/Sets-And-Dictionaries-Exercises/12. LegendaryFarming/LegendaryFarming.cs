using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main()
        {
            SortedDictionary<string, int> commonMaterials = new SortedDictionary<string, int>();
            SortedDictionary<string, int> keyMaterials = new SortedDictionary<string, int>();
            keyMaterials["shards"] = 0;
            keyMaterials["motes"] = 0;
            keyMaterials["fragments"] = 0;

            bool isLegendaryReady = false;
            while (isLegendaryReady == false)
            {
                string input = Console.ReadLine().ToLower();
                string[] lootMaterials = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                Queue<string> lootMaterialsQueue = new Queue<string>(lootMaterials);


                for (int i = 0; i < lootMaterials.Length / 2; i++)
                {
                    int quantity = int.Parse(lootMaterialsQueue.Dequeue());
                    string material = lootMaterialsQueue.Dequeue();

                    if (material == "shards" || material == "motes" || material == "fragments")
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials.Any(m => m.Value >= 250))
                        {
                            isLegendaryReady = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!commonMaterials.ContainsKey(material))
                        {
                            commonMaterials[material] = 0;
                        }

                        commonMaterials[material] += quantity;
                    }
                }
            }

            PrintMaterials(keyMaterials, commonMaterials);
            
        }

        private static void PrintMaterials(SortedDictionary<string, int> keyMaterials, SortedDictionary<string, int> commonMaterials)
        {
            if (keyMaterials["shards"] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                keyMaterials["shards"] -= 250;
            }
            else if (keyMaterials["motes"] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                keyMaterials["motes"] -= 250;
            }
            else if (keyMaterials["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                keyMaterials["fragments"] -= 250;
            }

            foreach (var keyMat in keyMaterials.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
            {
                Console.WriteLine($"{keyMat.Key}: {keyMat.Value}");
            }
            foreach (var commonMat in commonMaterials.OrderBy(m => m.Key))
            {
                Console.WriteLine($"{commonMat.Key}: {commonMat.Value}");
            }
        }
    }
}
