using System;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;

        private string color;

        public string Model { get => model; set => model = value; }
        public string Color { get => color; set => color = value; }

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Start() => "Engine start";


        public string Stop() => "Breaaak!";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.color} Seat {this.model}");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}