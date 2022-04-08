using System;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Astronauts
{
    public class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            Bag = new Backpack();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException
                        (ExceptionMessages.InvalidAstronautName);
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidOxygen);
                }

                oxygen = value;
            }
        }

        public bool CanBreath => Oxygen > 0;

        public IBag Bag { get; }

        public virtual void Breath()
        {
            this.Oxygen -= 10;
            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string result = Bag.Items.Count > 0 ? string.Join(", ", Bag.Items) : "none";

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Oxygen: {this.Oxygen}");
            sb.AppendLine($"Bag items: {result}");

            return sb.ToString().TrimEnd();
        }
    }
}