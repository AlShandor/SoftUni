
using NUnit.Framework;

namespace Tests
{
    public class AxeTests
    {
        private const int initialAxeDurability = 1;
        private const int expectedAxeDurabilityAfterAttack = 0;
        private const int initialAxeAttack = 10;

        private const int initialDummyHealth = 10;
        private const int initialDummyExp = 10;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(initialAxeAttack, initialAxeDurability);
            this.dummy = new Dummy(initialDummyHealth, initialDummyExp);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {

            this.axe.Attack(this.dummy);

            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(expectedAxeDurabilityAfterAttack), "Axe durability doesn't change after attack.");
        }

        [Test]
        public void AttackWithBrokenWeapon()
        {
            this.axe.Attack(this.dummy);

            Assert.That(() => this.axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
