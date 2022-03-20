using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);

            Dummy dummy = new Dummy(10, 10);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe doesn't change after attack." );
        }

        [Test]
        public void CantAttackWithBrokenAxe()
        {
            Axe axe = new Axe(0, 0);

            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));

           // Assert.That(axe.DurabilityPoints, Is.Not.EqualTo(-1), "You can attack with broken Axe");
        }
    }
}