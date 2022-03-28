using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using INStock.Contracts;

namespace INStock.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProductStockTests
    {
        ProductStock kaufland;
        Product cola;
        private Product pepsi;

        [SetUp]
        public void SetUp()
        {
            kaufland = new ProductStock();
            cola = new Product("Cola", 2.70m, 6);
            pepsi = new Product("pepsi", 2.00m, 6);

        }

        [Test]
        public void ShouldGiveAddProductInStock()
        {
            kaufland.Add(cola);

            IProduct pr = kaufland.First();

            Assert.AreEqual(cola, pr);
        }

        [Test]
        public void ShouldFindProduct()
        {
            kaufland.Add(cola);

            Assert.True(kaufland.Contains(product: cola));
        }

        [Test]
        public void ShouldGiveTheCountOfProducts()
        {
            kaufland.Add(pepsi);
            kaufland.Add(cola);

            Assert.AreEqual(2, kaufland.Count);
        }

        [Test]
        public void FindShould_ThrwoExceptionWhenIndexIsOutOfRange_NegativeTest()
        {
            kaufland.Add(pepsi);
            kaufland.Add(cola);

            Assert.Throws<IndexOutOfRangeException>(() => kaufland.Find(2));
        }
        
        [Test]
        public void FindShould_GiveSecondProduct()
        {
            kaufland.Add(pepsi);
            kaufland.Add(cola);

            IProduct pr = kaufland.Find(1);

            Assert.AreEqual(cola, pr);
        }
    }
}
