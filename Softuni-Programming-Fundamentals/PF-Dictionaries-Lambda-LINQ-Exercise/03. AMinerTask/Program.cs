using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> resources = new Dictionary<string, long>();

            string resource = Console.ReadLine();
            while (resource != "stop")
            {
                long quantity = long.Parse(Console.ReadLine());

                if (resources.ContainsKey(resource))
                {
                    resources[resource] += quantity;
                }
                else
                {
                    resources[resource] = quantity;
                }
                resource = Console.ReadLine();
            }
            foreach (var r in resources)
            {
                Console.WriteLine(r.Key + " -> " + r.Value);
            }
        }
    }
}
