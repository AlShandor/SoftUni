
using NUnit.Framework;

namespace Tests
{
    public class DummyTests
    {
        private Hero hero;
        private Dummy dummy;

        private string heroName = "Pesho";
        private int dummyStartingHealth = 10;
        private int dummyXP = 10;
        private int axeAttack = 10;

        [SetUp]
        public void TestInit()
        {
            this.hero = new Hero(this.heroName);
            this.dummy = new Dummy(dummyStartingHealth, dummyXP);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            this.hero.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(0));
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            this.hero.Attack(this.dummy);
            Assert.That(() => this.hero.Attack(this.dummy), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyGivesExperience()
        {
            this.hero.Attack(this.dummy);
            Assert.That(this.hero.Experience, Is.EqualTo(this.dummyXP));
        }
    }
}
