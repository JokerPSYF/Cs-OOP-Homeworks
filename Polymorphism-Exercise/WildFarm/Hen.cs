namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }


        public override string AskForFood() => "Cluck";
        public override void Eat(Food food)
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * 0.35;
        }
    }
}