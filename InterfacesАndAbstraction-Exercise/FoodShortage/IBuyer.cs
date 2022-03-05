namespace FoodShortage
{
    public interface IBuyer
    {
        public string Name { get; set; }
        int Food { get; set; }
        void BuyFood();
    }
}