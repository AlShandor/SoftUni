
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Bags;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, faction)
        {
            this.BaseHealth = 50;
            this.Health = 50;
            this.BaseArmor = 25;
            this.Armor = 25;
            this.AbilityPoints = 40;
            this.Bag = new Backpack();
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            CheckIfAlive();
            CheckIfEnemyAlive(character);

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.ReceiveHealing(this.AbilityPoints);
        }
    }
}
