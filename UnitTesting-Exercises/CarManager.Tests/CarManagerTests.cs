using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car1;

        //[SetUp]
        //public void SetUp()
        //{
        //    car1 = new Car("Citroen", "Saxo", 7.00, 40.00);
        //}
        [Test]
        public void CtorTest()
        {
            car1 = new Car("Citroen", "Saxo", 7.00, 40.00);

            Assert.AreEqual("Saxo", car1.Model);
            Assert.AreEqual("Citroen", car1.Make);
            Assert.AreEqual(7.00, car1.FuelConsumption);
            Assert.AreEqual(40.00, car1.FuelCapacity);
        }

        [Test]
        public void MakeMethodShould_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>
                (() => car1 = new Car("", "Saxo", 7.00, 40.00));

            Assert.Throws<ArgumentException>
                (() => car1 = new Car(string.Empty, "Saxo", 7.00, 40.00));
        }

        [Test]
        public void ModelShould_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>
                (() => car1 = new Car("Saxo", "", 7.00, 40.00));

            Assert.Throws<ArgumentException>
                (() => car1 = new Car("Saxo", string.Empty, 7.00, 40.00));
        }

        [Test]
        public void FuelConsumptionShould_ThrowArgumentException_WhenSetItNegativeNum()
        {
            Assert.Throws<ArgumentException>
                (() => car1 = new Car("Citroen", "Saxo", 0, 40.00));

            Assert.Throws<ArgumentException>
                (() => car1 = new Car("Citroen", "Saxo", -5, 40.00));
        }

        [Test]
        public void FuelCapacity_ThrowArgumentException_WhenSetItNegativeNum()
        {
            Assert.Throws<ArgumentException>
                (() => car1 = new Car("Citroen", "Saxo", 7.00, 0));

            Assert.Throws<ArgumentException>
                (() => car1 = new Car("Citroen", "Saxo", 7.00, -5));
        }

        [Test]
        public void RefuelMethod_ShouldThrowException_WhenRefuelNagativeNum()
        {
            car1 = new Car("Citroen", "Saxo", 7.00, 40.00);


            Assert.Throws<ArgumentException>
                (() => car1.Refuel(-50), "You shouldn't can refuel with negative number");

            Assert.Throws<ArgumentException>
                (() => car1.Refuel(0), "You shouldn't can refuel with negative number");
        }

        [Test]
        public void RefuelMethod_PositiveTest()
        {
            car1 = new Car("Citroen", "Saxo", 7.00, 40.00);

            car1.Refuel(50);

            Assert.AreEqual(40, car1.FuelAmount);

            car1 = new Car("Citroen", "Saxo", 7.00, 40.00);

            car1.Refuel(39);

            Assert.AreEqual(39, car1.FuelAmount);
        }

        [Test]
        public void DriveMethod_NegativeTest()
        {
            car1 = new Car("Citroen", "Saxo", 7.00, 40.00);

            Assert.Throws<InvalidOperationException>(() => car1.Drive(10));

        }

        [Test]
        public void DriveMethod_PositiveTest()
        {
            car1 = new Car("Citroen", "Saxo", 10, 100.00);

            car1.Refuel(100);

            car1.Drive(10);

            Assert.AreEqual(99, car1.FuelAmount);
        }
    }
}