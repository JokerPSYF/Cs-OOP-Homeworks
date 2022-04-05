using System;
using NUnit.Framework;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void CtorAthlete()
        {
            Athlete ath = new Athlete("Todor");

            Assert.AreEqual("Todor", ath.FullName);
            Assert.AreEqual(false, ath.IsInjured);
        }

        [Test]
        public void CtorGym()
        {
            Gym gym = new Gym("Gim", 15);

            Assert.AreEqual("Gim", gym.Name);
            Assert.AreEqual(0, gym.Count);
            Assert.AreEqual(15, gym.Capacity);
        }

        [Test]
        public void CountTest()
        {
            Gym gym = new Gym("Gim", 15);

            for (int i = 0; i < 12; i++)
            {
                gym.AddAthlete(new Athlete("Pesho"));
            }

            Assert.AreEqual(12, gym.Count);
        }

        [Test]
        public void CapacityThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Gim", -5));
        }

        [Test]
        public void NameThrowException_WhenNameIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym("", 5));
        }

        [Test]
        public void NameThrowException_WhenNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 5));
        }

        [Test]
        public void AddAthleteThrowException()
        {
            Gym gym = new Gym("Gim", 1);

            Athlete ath1 = new Athlete("Stoiko");
            Athlete ath2 = new Athlete("Zlatko");

            gym.AddAthlete(ath1);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(ath2));
        }

        [Test]
        public void AddAthleteSucces()
        {
            Gym gym = new Gym("Gim", 2);

            Athlete ath1 = new Athlete("Stoiko");
            Athlete ath2 = new Athlete("Zlatko");

            gym.AddAthlete(ath1);
            gym.AddAthlete(ath2);

            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void RemoveAthleteThrowException()
        {
            Gym gym = new Gym("Gim", 2);

            Athlete ath1 = new Athlete("Stoiko");
            Athlete ath2 = new Athlete("Zlatko");

            gym.AddAthlete(ath1);
            gym.AddAthlete(ath2);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Toshko"));
        }

        [Test]
        public void RemoveAthleteSucces()
        {
            Gym gym = new Gym("Gim", 2);

            Athlete ath1 = new Athlete("Stoiko");
            Athlete ath2 = new Athlete("Zlatko");

            gym.AddAthlete(ath1);
            gym.AddAthlete(ath2);
            gym.RemoveAthlete(ath1.FullName);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void InjuredAthleteThrowException()
        {
            Gym gym = new Gym("Gim", 2);

            Athlete ath1 = new Athlete("Stoiko");
            Athlete ath2 = new Athlete("Zlatko");

            gym.AddAthlete(ath1);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(ath2.FullName));
        }

        [Test]
        public void InjuredAthleteSucces()
        {
            Gym gym = new Gym("Gim", 2);

            Athlete ath1 = new Athlete("Stoiko");
            Athlete ath2 = new Athlete("Zlatko");

            gym.AddAthlete(ath1);
            gym.AddAthlete(ath2);
            var returnAthlete1 = gym.InjureAthlete(ath1.FullName);
            Assert.AreEqual(true, ath1.IsInjured);
            Assert.AreEqual(false, ath2.IsInjured);
            Assert.AreSame(ath1, returnAthlete1);
        }

        [Test]
        public void ReportTestSuccess()
        {
            Gym gym = new Gym("Gim", 2);

            Athlete ath1 = new Athlete("Stoiko");
            Athlete ath2 = new Athlete("Zlatko");

            gym.AddAthlete(ath1);
            gym.AddAthlete(ath2);

            Assert.AreEqual("Active athletes at Gim: Stoiko, Zlatko", gym.Report());
        }
        
        [Test]
        public void ReportWithEmptyTestSuccess()
        {
            Gym gym = new Gym("Gim", 2);

            Assert.AreEqual("Active athletes at Gim: ", gym.Report());
        }
    }
}
