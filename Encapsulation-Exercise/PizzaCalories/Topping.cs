using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9}

        };

        public Topping(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        private string type;

        private int weight;

        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
                else
                {
                    weight = value;
                }

            }
        }


        public string Type
        {
            get { return type; }
            private set
            {
                if (modifiers.ContainsKey(value.ToLower()))
                {
                    type = value;

                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }

        public double Calories => 2 * Weight * modifiers[type.ToLower()];

    }

}