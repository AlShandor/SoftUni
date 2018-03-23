
namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion()
        {
            this.Weight = 5;
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
