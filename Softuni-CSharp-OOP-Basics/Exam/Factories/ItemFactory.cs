using DungeonsAndCodeWizards.Models;
using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            Item item;
            switch (name)
            {
                case "HealthPotion":
                    item =  new HealthPotion();
                    break;
                case "ArmorRepairKit":
                    item =  new ArmorRepairKit();
                    break;
                case "PoisonPotion":
                    item =  new PoisonPotion();
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{name}\"!");
            }

            return item;
        }
    }
}
