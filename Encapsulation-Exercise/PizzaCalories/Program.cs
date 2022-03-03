using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameInput = Console.ReadLine().Split();

            string[] doughInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                Dough dough = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));

                Pizza pizza = new Pizza(nameInput[1], dough);

                string[] toppingInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                while (toppingInput[0] != "END")
                {
                    Topping topping = new Topping(toppingInput[1], int.Parse(toppingInput[2]));

                    pizza.AddTopping(topping);

                    toppingInput = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }

                double calories = pizza.Calories;

                Console.WriteLine($"{pizza.Name} - {calories:f2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
