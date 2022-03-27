using INStock.Contracts;

namespace INStock
{
    public class CocaCola : IProduct
    {
        public int CompareTo(IProduct other)
        {
            return Price.CompareTo(other.Price);
        }

        public string Label { get => "Soda"; }
        public decimal Price { get => 2.7m; }
        public int Quantity { get => 2; }
    }
}