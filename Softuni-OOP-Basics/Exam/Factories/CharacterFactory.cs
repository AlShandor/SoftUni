using DungeonsAndCodeWizards.Models;
using DungeonsAndCodeWizards.Models.Characters;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            var hasParsed = Enum.TryParse<Faction>(faction, out var parsedFaction);
            if (!hasParsed)
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            Character character;
            switch (type)
            {
                case "Warrior":
                    character = new Warrior(name, parsedFaction);
                    break;
                case "Cleric":
                    character = new Cleric(name, parsedFaction);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            return character;
        }
    }
}
