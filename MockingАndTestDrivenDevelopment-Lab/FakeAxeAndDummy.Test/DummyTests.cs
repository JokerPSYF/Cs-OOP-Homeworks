using System;
using NUnit.Framework;

namespace FakeAxeAndDummy.Test
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLooseHealthWhenBeenAttacked()
        {
            Dummy dumy = new Dummy(100, 100);

            dumy.TakeAttack(10);

            Assert.AreEqual(90, dumy.Health, "Dummy health doesn't change after attack");
        }

        [Test]
        public void DeadDummyThrowsExceptionWhenBeenAttacked()
        {
            Dummy dummy = new Dummy(0, 0);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10), "Dead dummy been attacked");
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 100);

            int xp = dummy.GiveExperience();

            Assert.AreEqual(100, xp, "Dead Dummy can't give xp");
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(100, 100);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Alive dummy can give xp");
        }
    }
}
