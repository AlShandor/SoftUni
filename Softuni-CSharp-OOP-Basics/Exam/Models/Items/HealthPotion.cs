using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion()
        {
            this.Weight = 5;
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.ReceiveHealing(20);
        }
    }
}
