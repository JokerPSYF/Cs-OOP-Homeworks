namespace WildFarm
{
    public abstract class Animal 
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name{ get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get;  set; }

        public abstract string AskForFood();

        public abstract void Eat(Food food);

    }
}