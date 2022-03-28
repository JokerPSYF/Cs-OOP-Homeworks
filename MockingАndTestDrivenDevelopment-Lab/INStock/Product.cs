using INStock.Contracts;

namespace INStock
{
    public class Product : IProduct
    {
       

        public string Label { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public int CompareTo(IProduct other)
        {
            return Price.CompareTo(other.Price);
        }
    }
}