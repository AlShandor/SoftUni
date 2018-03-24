using System;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Item
    {
        private int weight;

        protected Item()
        {
        }

        public int Weight
        {
            get { return this.weight; }
            protected set
            {
                this.weight = value;
            }
        }

        public virtual void AffectCharacter(Character character)
        {
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

    }
}
