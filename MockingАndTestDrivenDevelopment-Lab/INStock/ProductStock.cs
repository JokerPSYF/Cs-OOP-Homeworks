using System.Collections;
using System.Collections.Generic;
using INStock.Contracts;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products = new List<IProduct>();

        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => products.Count;

        public IProduct this[int index]
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public bool Contains(IProduct product)
        {
            throw new System.NotImplementedException();
        }

        public void Add(IProduct product)
        {
            products.Add(product);
        }

        public bool Remove(IProduct product)
        {
            throw new System.NotImplementedException();
        }

        public IProduct Find(int index)
        {
            throw new System.NotImplementedException();
        }

        public IProduct FindByLabel(string label)
        {
            throw new System.NotImplementedException();
        }

        public IProduct FindMostExpensiveProduct()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}