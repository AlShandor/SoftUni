
using DungeonsAndCodeWizards.Models.Bags;
using System;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;


        protected Character(string name, Faction faction)
        {
            this.Name = name;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
        }

        public string Name
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth
        {
            get { return this.baseHealth; }
            protected set
            {
                this.baseHealth = value;
            }
        }

        public double Health
        {
            get { return this.health; }
            set
            {
                this.health = Math.Max(value, 0);
            }
        }

        public double BaseArmor
        {
            get { return this.baseArmor; }
            protected set
            {
                this.baseArmor = value;
            }
        }

        public double Armor
        {
            get { return armor; }
            set
            {
                armor = value;
            }
        }

        public double AbilityPoints
        {
            get { return this.abilityPoints; }
            protected set { this.abilityPoints = value; }
        }

        public Bag Bag
        {
            get { return this.bag; }
            protected set
            {
                this.bag = value;
            }
        }

        public Faction Faction
        {
            get { return faction; }
            protected set
            {
                this.faction = value;
            }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; } // TODO may need to be protected
        }

        public virtual double RestHealMultiplier { get; protected set; } // TODO test without virtual

        public void TakeDamage(double hitPoints)
        {
            CheckIfAlive();
            var hitpointsLeftAfterArmorDamage = Math.Max(0, hitPoints - this.Armor);
            this.Armor = Math.Max(0, this.Armor - hitPoints);
            this.Health = Math.Max(0, this.Health - hitpointsLeftAfterArmorDamage);

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void Rest()
        {
            CheckIfAlive();

            // TODO check if health goes above BaseHealth
            if (this.Health + this.BaseHealth * this.RestHealMultiplier > this.BaseHealth)
            {
                this.Health = this.BaseHealth;
            }
            else
            {
                this.Health += this.BaseHealth * this.RestHealMultiplier;
            }

        }

        public void UseItem(Item item)
        {
            CheckIfAlive();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            CheckIfAlive();
            CheckIfEnemyAlive(character);

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            CheckIfAlive();
            CheckIfEnemyAlive(character);

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            CheckIfAlive();

            this.Bag.AddItem(item);
        }

        public void ReceiveHealing(double hitpoints)
        {
            if (this.Health + hitpoints > this.BaseHealth)
            {
                this.Health = this.BaseHealth;
            }
            else
            {
                this.Health += hitpoints;
            }
        }

        public virtual void CheckIfAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public virtual void CheckIfEnemyAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            string status = this.IsAlive ? "Alive" : "Dead";
            return
                $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}
