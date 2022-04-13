using System;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void SmartPhoneCtorTest()
        {
            Smartphone phone = new Smartphone("Asus", 100);

            Assert.AreEqual("Asus", phone.ModelName);
            Assert.AreEqual(100, phone.CurrentBateryCharge);
            Assert.AreEqual(100, phone.MaximumBatteryCharge);
        }
        
        [Test]
        public void ShopCtorTest()
        {
            Shop shop = new Shop(15);

            Assert.AreEqual(15, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }
        
        [Test]
        public void InvlidCapacity()
        {
            Shop shop;

            Assert.Throws<ArgumentException>(() => shop = new Shop(-14));
        }
        
        [Test]
        public void AddAlreadyExist()
        {
            Shop shop = new Shop(15);

            Smartphone phone = new Smartphone("Asus", 100);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone));
        }
        
        [Test]
        public void AddWithFullCapacity()
        {
            Shop shop = new Shop(1);

            Smartphone phone = new Smartphone("Asus", 100);

            Smartphone phone1 = new Smartphone("Esus", 100);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone1));
        }
        
        [Test]
        public void AddPositiveTest()
        {
            Shop shop = new Shop(10);

            Smartphone phone = new Smartphone("Asus", 100);

            Smartphone phone1 = new Smartphone("Esus", 100);
            Smartphone phone2 = new Smartphone("Isus", 100);
            Smartphone phone3 = new Smartphone("Usus", 100);
            Smartphone phone4 = new Smartphone("Ysus", 100);

            shop.Add(phone);
            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);
            shop.Add(phone4);
            Assert.AreEqual(5, shop.Count);
        }

        [Test]
        public void RemoveDoesntExistPhone()
        {
            Shop shop = new Shop(1);

            Smartphone phone = new Smartphone("Asus", 100);

            Smartphone phone1 = new Smartphone("Esus", 100);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Esus"));
        }

        [Test]
        public void RemovePositiveTest()
        {
            Shop shop = new Shop(10);

            Smartphone phone = new Smartphone("Asus", 100);

            Smartphone phone1 = new Smartphone("Esus", 100);
            Smartphone phone2 = new Smartphone("Isus", 100);
            Smartphone phone3 = new Smartphone("Usus", 100);
            Smartphone phone4 = new Smartphone("Ysus", 100);

            shop.Add(phone);
            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);
            shop.Add(phone4);

            shop.Remove("Asus");
            shop.Remove("Esus");
            Assert.AreEqual(3, shop.Count);
        }

        [Test]
        public void TestPhone_With_DoesntExistPhone()
        {
            Shop shop = new Shop(1);

            Smartphone phone = new Smartphone("Asus", 100);

            Smartphone phone1 = new Smartphone("Esus", 100);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Esus", 10));
        }
        
        [Test]
        public void TestPhone_With_LowBattery()
        {
            Shop shop = new Shop(1);

            Smartphone phone = new Smartphone("Asus", 100);

            Smartphone phone1 = new Smartphone("Esus", 100);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Asus", 101));
        }

        [Test]
        public void TestPhone_PositiveTest()
        {
            Shop shop = new Shop(10);

            Smartphone phone = new Smartphone("Asus", 100);

            Smartphone phone1 = new Smartphone("Esus", 100);
            Smartphone phone2 = new Smartphone("Isus", 100);
            Smartphone phone3 = new Smartphone("Usus", 100);
            Smartphone phone4 = new Smartphone("Ysus", 100);

            shop.Add(phone);
            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);
            shop.Add(phone4);

            shop.TestPhone("Asus", 50);
            shop.TestPhone("Esus", 75);
            shop.TestPhone("Isus", 25);

            Assert.AreEqual(50, phone.CurrentBateryCharge);
            Assert.AreEqual(25, phone1.CurrentBateryCharge);
            Assert.AreEqual(75, phone2.CurrentBateryCharge);
        }

        [Test]
        public void Charge_With_Null()
        {
            Shop shop = new Shop(1);

            Smartphone phone = new Smartphone("Asus", 100);

            Smartphone phone1 = new Smartphone("Esus", 100);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Esus"));
        }

        [Test]
        public void ChargePhonePositiveTest()
        {
            Shop shop = new Shop(10);

            Smartphone phone = new Smartphone("Asus", 100);

            Smartphone phone1 = new Smartphone("Esus", 100);
            Smartphone phone2 = new Smartphone("Isus", 100);
            Smartphone phone3 = new Smartphone("Usus", 100);
            Smartphone phone4 = new Smartphone("Ysus", 100);

            shop.Add(phone);
            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);
            shop.Add(phone4);

            shop.TestPhone("Asus", 50);

            Assert.AreEqual(50, phone.CurrentBateryCharge);


            shop.ChargePhone("Asus");

            Assert.AreEqual(100, phone.CurrentBateryCharge);

        }
    }
}