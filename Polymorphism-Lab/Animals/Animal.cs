using System.Text;

namespace Animals
{
    public class Animal
    {
        public string Name { get; private set; }

        public string FavouriteFood { get; private set; }

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }
         
        public virtual string ExplainSelf()
        {
            StringBuilder builder = new StringBuilder($"I am {this.Name} and my fovourite food is {this.FavouriteFood}");
            return builder.ToString();
        }
    }
}