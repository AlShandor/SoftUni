using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CubicAssault
{
    class CubicAssault
    {
        class Region
        {
            public string Name { get; set; }
            public Dictionary<string, long> Stones = new Dictionary<string, long>();
        }

        static void Main()
        {
            var regionStats = new Dictionary<string, Region>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Count em all")
                {
                    break;
                }

                AddStatsToRegionStats(input, regionStats);
            }

            PrintRegionStats(regionStats);
        }

        private static void PrintRegionStats(Dictionary<string, Region> regionStats)
        {
            foreach (var region in regionStats.OrderByDescending(x => x.Value.Stones["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine(region.Value.Name);
                foreach (var stone in region.Value.Stones.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {stone.Key} : {stone.Value}");
                }
            }
        }

        private static void AddStatsToRegionStats(string input, Dictionary<string, Region> regionStats)
        {
            string[] tokens = input.Split(new string[] {"->"}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            string regionName = tokens[0];
            string typeStone = tokens[1];
            long ammountStone = long.Parse(tokens[2]);

            if (!regionStats.ContainsKey(regionName))
            {
                var newRegion = new Region();
                newRegion.Name = regionName;
                newRegion.Stones["Green"] = 0;
                newRegion.Stones["Red"] = 0;
                newRegion.Stones["Black"] = 0;
                newRegion.Stones[typeStone] += ammountStone;
                ConvertStones(newRegion);
                regionStats.Add(regionName,newRegion);
            }
            else
            {
                UpdateRegionStats(regionStats[regionName], typeStone, ammountStone);
            }
        }

        private static void UpdateRegionStats(Region region, string typeStone, long ammountStone)
        {
            region.Stones[typeStone] += ammountStone;
            ConvertStones(region);
        }

        private static void ConvertStones(Region region)
        {
            if (region.Stones["Green"] >= 1000000)
            {
                region.Stones["Red"] += region.Stones["Green"] / 1000000;
                region.Stones["Green"] %= 1000000;
            }
            if (region.Stones["Red"] >= 1000000)
            {
                region.Stones["Black"] += region.Stones["Red"] / 1000000;
                region.Stones["Red"] %= 1000000;
            }
        }
    }
}
