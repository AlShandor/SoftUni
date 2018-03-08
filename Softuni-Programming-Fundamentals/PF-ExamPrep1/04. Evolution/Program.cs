using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Evolution
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, List<EvolutionType>> pokemons = new Dictionary<string, List<EvolutionType>>();
            while (input != "wubbalubbadubdub")
            {
                string[] tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                if (tokens.Length == 1)
                {
                    PrintPokemonInfo(name, pokemons);
                    input = Console.ReadLine();
                    continue;
                }
                string evolutionType = tokens[1];
                string level = tokens[2];

                AddPokemonInfoToDic(pokemons, name, evolutionType, level);



                input = Console.ReadLine();
            }
            PrintAllPokemons(pokemons);
        }

        private static void PrintAllPokemons(Dictionary<string, List<EvolutionType>> pokemons)
        {
            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"# {pokemon.Key}");
                foreach (var evoType in pokemon.Value.OrderByDescending(e => e.Level))
                {
                    Console.WriteLine($"{evoType.EvoName} <-> {evoType.Level}");
                }
            }
        }

        private static void PrintPokemonInfo(string name, Dictionary<string, List<EvolutionType>> pokemons)
        {
            if (pokemons.ContainsKey(name))
            {
                Console.WriteLine($"# {name}");
                foreach (var evoType in pokemons[name])
                {
                    Console.WriteLine($"{evoType.EvoName} <-> {evoType.Level}");
                }
            }
        }

        private static void AddPokemonInfoToDic(Dictionary<string, List<EvolutionType>> pokemons, string name, string evolutionType, string level)
        {
            EvolutionType newEvolutionType = new EvolutionType();
            newEvolutionType.EvoName = evolutionType;
            newEvolutionType.Level = long.Parse(level);
            if (!pokemons.ContainsKey(name))
            {
                List<EvolutionType> newEvoList = new List<EvolutionType>();
                newEvoList.Add(newEvolutionType);
                pokemons.Add(name, newEvoList);
            }
            else
            {
                pokemons[name].Add(newEvolutionType);
            }
        }

        class EvolutionType
        {
            public string EvoName { get; set; }
            public long Level { get; set; }
        }
    }
}
