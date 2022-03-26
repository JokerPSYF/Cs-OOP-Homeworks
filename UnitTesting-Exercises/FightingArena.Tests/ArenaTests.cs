using System;
using System.Linq;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior1;
        private Warrior warrior2;


        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior1 = new Warrior("Todor_Sthangista", 100, 100);
            warrior2 = new Warrior("Gosho_Dulgata_Guma", 120, 120);
        }

        [Test]
        public void Ctor_PositiveTest()
        {
            Assert.NotNull(arena);
        }

        [Test]
        public void Enroll_Test()
        {
            arena.Enroll(warrior1);

            Warrior warrior2 = arena.Warriors.First();

            Assert.AreEqual(warrior2, warrior1);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior2));
        }

        [TestCase("Todor_Sthangista", "Gosho_Lampata")]
        [TestCase("Todor_Kukata", "Gosho_Dulgata_Guma")]
        [TestCase("Todor_Kukata", "Gosho_Lampata")]
        public void Fight_NegativeTest(string attacker, string deffender)
        {
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, deffender));
        }

        [Test]
        public void WhyYouCanAttackYourselft()
        {
            arena.Enroll(warrior1);

            arena.Fight("Todor_Sthangista", "Todor_Sthangista");

            Assert.AreEqual(0, warrior1.HP);

        }

    }
}
