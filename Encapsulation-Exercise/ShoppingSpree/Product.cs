using System;

namespace ShoppingSpree
{
    public class Product
    {

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
        private string name;

        private int cost;

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

        public int Cost
        {
            get { return cost; }
        private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                else
                {
                    cost = value;
                }
            }
        }

    }
}