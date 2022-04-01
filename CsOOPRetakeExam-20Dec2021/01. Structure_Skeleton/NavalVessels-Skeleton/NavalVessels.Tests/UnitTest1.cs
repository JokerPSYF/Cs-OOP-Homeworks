using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VesselsCtorTests()
        {
            Submarine vessel;
            
            Assert.ThrowsException<ArgumentNullException>(() => vessel = new Submarine(" ", 200, 200, 200));

            vessel = new Submarine("George", 200, 100, 50);

            Assert.AreEqual("George", vessel.Name, "Name not true");
            Assert.AreEqual(200, vessel.MainWeaponCaliber, "Caliber not true");
            Assert.AreEqual(100, vessel.Speed, "Speed not true");
            Assert.AreEqual(50, vessel.ArmorThickness, "Armor not true");
        }

        [TestMethod]
        public void VesselMethod_Attack()
        {
            Captain kapitan = new Captain("Jack Sparow");
            Submarine vessel = new Submarine("George", 90, 100, 50);
            kapitan.AddVessel(vessel);
            
            Captain kapitan2 = new Captain("Jacl Sparow");
            Submarine vessel2 = new Submarine("Gorge", 50, 100, 200);

            vessel2.ToggleSubmergeMode();

            kapitan2.AddVessel(vessel2);

            vessel.Attack(vessel2);

          //  Assert.AreEqual("110", vessel.ToString());

            Assert.AreEqual("110", vessel2.ToString());

            

        }
    }
}
