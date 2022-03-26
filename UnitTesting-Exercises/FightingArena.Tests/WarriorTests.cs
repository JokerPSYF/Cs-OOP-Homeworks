using System;
using NUnit.Framework.Constraints;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        Warrior warior1 = new Warrior("Todor_Sthangista", 100, 100);
        Warrior warior2 = new Warrior("Gosho_Dulgata_Guma", 120, 120);

        //[SetUp]
        //public void SetUp()
        //{
        //    warior1 = new Warrior("Todor_Sthangista", 100, 100);

        //    warior2 = new Warrior("Gosho_Dulgata_Guma", 120, 120);
        //}

        [Test]
        public void Ctor_PositiveTest()
        {
            warior1 = new Warrior("Todor_Sthangista", 100, 100);

            Assert.AreEqual("Todor_Sthangista", warior1.Name);
            Assert.AreEqual(100, warior1.Damage);
            Assert.AreEqual(100, warior1.HP);
        }
        [TestCase(" ")]
        [TestCase("")]
        [TestCase(null)]
        public void Property_Name_NegativeTest(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 100, 100));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Property_Damage_NegativeTest(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Toshko_Karatista", damage, 100));
        }
        
        [TestCase(-1)]
        public void Property_HP_NegativeTest(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Toshko_Karatista", 100, hp), $"You shouldn't can put {hp} for health");
        }
        
        [Test]
        public void Method_Attack_NegativeTest()
        {
            warior1 = new Warrior("Toshko_Karatista", 100, 29);

            Assert.Throws<InvalidOperationException>(() => warior1.Attack(warior2), "You attack with low hp");

            warior1 = warior2;

            warior2 = new Warrior("Toshko_Karatista", 100, 29);

            Assert.Throws<InvalidOperationException>(() => warior1.Attack(warior2), "The second warrior have low hp");

            warior2 = new Warrior("Toshko_Karatista", 100, 50);

            Assert.Throws<InvalidOperationException>(() => warior2.Attack(warior1), "WHAT YOU DOING, YOU ARE 1 HIT");
        }
        
        [TestCase(100, 90, 100, 29, 71, 0)]
        [TestCase(100, 90, 69, 29, 71, 21)]
        public void Method_Attack_PositiveTest(int hp1, int hp2, int dmg1, int dmg2, int expHP1, int expHP2)
        {
            warior1 = new Warrior("Toshko_Karatista", dmg1, hp1);

            warior2 = new Warrior("Gosho_Dulgata_Guma", dmg2, hp2);

            warior1.Attack(warior2);

            Assert.AreEqual(expHP1, warior1.HP, $"warrior1 HP is {warior1}, not {expHP1}");
            Assert.AreEqual(expHP2, warior2.HP, $"warrior2 HP is {warior2}, not {expHP2}");
        }

        [Test]
        public void WhyYouCanAttackYourslelf()
        {
            warior1.Attack(warior1);

            Assert.AreEqual(0, warior1.HP);
        }

    }
}