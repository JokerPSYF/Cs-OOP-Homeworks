
namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        public string Name { get; set; }

        public int Age { get; private set; }

        public string Id { get; set; }

        public string BirthDate { get; private set; }

        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
            Food = 0;
        }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }

    }
}