using System;
using System.Collections.Generic;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                Animal animal = null;
                switch (input[0])
                {
                    case "Hen":
                        animal = new Hen(input[1], double.Parse(input[2]), double.Parse(input[3]));
                        break;

                    case "Owl":
                        animal = new Owl(input[1], double.Parse(input[2]), double.Parse(input[3]));
                        break;

                    case "Mouse":
                        animal = new Mouse(input[1], double.Parse(input[2]), input[3]);
                        break;

                    case "Cat":
                        animal = new Cat(input[1], double.Parse(input[2]), input[3], input[4]);
                        break;

                    case "Dog":
                        animal = new Dog(input[1], double.Parse(input[2]), input[3]);
                        break;

                    case "Tiger":
                        animal = new Tiger(input[1], double.Parse(input[2]), input[3], input[4]);
                        break;
                }

                Console.WriteLine(animal.AskForFood());

                animals.Add(animal);

                string[] foodInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Food food = null;

                switch (foodInput[0])
                {
                    case "Vegetable":
                        food = new Vegetable(int.Parse(foodInput[1]));
                        break;

                    case "Fruit":
                        food = new Fruit(int.Parse(foodInput[1]));
                        break;

                    case "Meat":
                        food = new Meat(int.Parse(foodInput[1]));
                        break;

                    case "Seeds":
                        food = new Seeds(int.Parse(foodInput[1]));
                        break;
                }

                animal.Eat(food);

                input = Console.ReadLine().Split();
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
