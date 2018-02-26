using System;
using System.Collections.Generic;

namespace _06.AMiner_sTask
{
    class AMinersTask
    {
        static void Main()
        {
            Dictionary<string, long> resources = new Dictionary<string, long>();

            while (true)
            {
                string resourceType = Console.ReadLine();
                if (resourceType == "stop")
                {
                    break;
                }

                long quantity = long.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resourceType))
                {
                    resources[resourceType] = 0;
                }

                resources[resourceType] += quantity;
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
