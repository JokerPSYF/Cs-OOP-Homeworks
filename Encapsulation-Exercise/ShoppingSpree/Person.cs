using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ShoppingSpree
{
    public class Person
    {
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }

        private string name;

        private int money;

        private List<Product> bagOfProducts;

        public string Name

        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                else
                {
                    name = value;
                }
            }
        }

        public int Money
        {
            get { return money; }

            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                else
                {
                    money = value;
                }
            }
        }

        public List<Product> BagOfProducts { get => bagOfProducts; }

        public void BuyProduct(Product product)
        {
            if (money >= product.Cost)
            {
                bagOfProducts.Add(product);
                money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
    }
}