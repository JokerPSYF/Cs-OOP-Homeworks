namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        public string Name { get; set; }

        public string Age { get; private set; }

        public string Group { get; private set; }

        public Rebel(string name, string age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
