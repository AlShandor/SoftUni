
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Bags;
using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) 
            : base(name, faction)
        {
            this.BaseHealth = 100;
            this.Health = 100;
            this.BaseArmor = 50;
            this.Armor = 50;
            this.AbilityPoints = 40;
            this.Bag = new Satchel();
        }

        public void Attack(Character character)
        {
            CheckIfAlive();
            CheckIfEnemyAlive(character);

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
