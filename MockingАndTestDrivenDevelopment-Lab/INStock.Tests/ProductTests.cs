namespace INStock.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ShouldReturnTheExpensiveProduct()
        {
            Product cocaCola = new Product("CocaCola", 2.70m, 6);

            Product pepsi = new Product("Pepsi", 2.00m, 6);

            Assert.AreEqual(1, cocaCola.CompareTo(pepsi));
        }

    }
}