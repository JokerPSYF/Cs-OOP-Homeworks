using System;
using System.Collections.Generic;
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
        public void FindShould_ThrowExceptionWhenIndexIsOutOfRange_NegativeTest()
        {
            kaufland.Add(pepsi);
            kaufland.Add(cola);

            Assert.Throws<IndexOutOfRangeException>(() => kaufland.Find(2));
        }
        
        [Test]
        public void FindShould_GiveSecondProduct_PositiveTest()
        {
            kaufland.Add(pepsi);
            kaufland.Add(cola);

            IProduct pr = kaufland.Find(1);

            Assert.AreEqual(cola, pr);
        }

        [Test]
        public void FindLabelShould_ThrowEcxeption_WhenTheresNoSuchLabel_NegativeTest()
        {
            kaufland.Add(pepsi);
            kaufland.Add(cola);

            Assert.Throws<ArgumentException>(() => kaufland.FindByLabel("Fanta"));
        }

        [Test]
        public void FindLabelShould_GiveSecondProduct_PositiveTest()
        {
            kaufland.Add(pepsi);
            kaufland.Add(cola);

            IProduct pr = kaufland.FindByLabel("Cola");

            Assert.AreEqual(cola, pr);
        }

        [Test]
        public void FindAllInPriceRange_PositiveTest()
        {
            kaufland.Add(pepsi);
            kaufland.Add(cola);

            IEnumerable<IProduct> products = kaufland.FindAllInRange(2.00, 2.70);
            
            Assert.True(products.First() == cola);

            Assert.AreEqual(2, products.Count());

            products = kaufland.FindAllInRange(5.00, 6.00);

            Assert.AreEqual(0, products.Count());
        }


    }
}
