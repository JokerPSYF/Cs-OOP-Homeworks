using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public override string ExplainSelf()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(base.ExplainSelf());

            builder.AppendLine("DJAAF");

            return builder.ToString().TrimEnd();
        }

        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }
    }
}