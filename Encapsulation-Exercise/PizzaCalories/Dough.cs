using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private  readonly Dictionary<string, double> modifiers = new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain", 1.0},
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1.0}
        };

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private string flourType;

        private string bakingTecnique;

        private int weight;

        public int Weight
        {
            get { return weight; }

            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                else
                {
                    weight = value;
                }
            }
        }


        public string FlourType
        {
            get => flourType;
            private set
            {
                if (modifiers.ContainsKey(value.ToLower()))
                {
                    flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }

        }

        public string BakingTechnique
        {
            get => bakingTecnique;
            private set
            {
                if (modifiers.ContainsKey(value.ToLower()))
                {
                    bakingTecnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public double Calories => 2 * Weight * modifiers[FlourType.ToLower()] * modifiers[BakingTechnique.ToLower()];
    }
}