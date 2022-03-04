using System;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;

        private string color;

        private int battery;

        public Tesla(string model, string color, int batteries )
        {
            Model = model;
            Color = color;
            Battery = batteries;
        }

        public string Model { get => model; set => model = value; }
        public string Color { get => color; set => color = value; }

        public string Start() => "Engine start";

        public string Stop() => "Breaaak!";

        public int Battery { get => battery; set => battery = value; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{this.color} Tesla {this.model} with {battery} Batteries");

            builder.AppendLine(Start());

            builder.AppendLine(Stop());

            return builder.ToString().TrimEnd();
        }
    }
}