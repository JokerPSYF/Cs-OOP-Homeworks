using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public override string ExplainSelf()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(base.ExplainSelf());

            builder.AppendLine("MEEOW");

            return builder.ToString().TrimEnd();
        }

        public Cat(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }
    }
}