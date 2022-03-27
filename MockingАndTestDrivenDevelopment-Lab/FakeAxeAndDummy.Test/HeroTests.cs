using System;
using Moq;
using NUnit.Framework;

namespace FakeAxeAndDummy.Test
{
    [TestFixture]
    public class HeroTests
    {
        private Mock<ITarget> fakeTarget;
        private Mock<IWeapon> fakeWeapon;
        private Hero hero;

        [SetUp]
        public void SetUp()
        {
            fakeTarget = new Mock<ITarget>();
            fakeWeapon = new Mock<IWeapon>();
            hero = new Hero("Gosho_Dulgata_Guma)", fakeWeapon.Object);
        }
        
        [Test]
        public void HeroTakeXPWhenKillTarget()
        {
            fakeTarget.Setup(t => t.Health).Returns(0);
            fakeTarget.Setup(t => t.IsDead()).Returns(true);
            fakeTarget.Setup(t => t.GiveExperience()).Returns(20);

            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(20, hero.Experience);
        }

   
    }
}