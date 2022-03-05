using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int humans = int.Parse(Console.ReadLine());
            
            List<IBuyer> repository = new List<IBuyer>();

            for (int i = 0; i < humans; i++)
            {
                string[] guy = Console.ReadLine().Split();

                if (guy.Length == 4)
                {
                    Citizen citizen = new Citizen(guy[0], int.Parse(guy[1]), guy[2], guy[3]);
                    repository.Add(citizen);
                }
                else if (guy.Length == 3)
                {
                    Rebel pet = new Rebel(guy[0], guy[1], guy[2]);
                    repository.Add(pet);
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                IBuyer person = repository.FirstOrDefault(x => x.Name == input);
                if (person != default)
                {
                    person.BuyFood();
                }
                input = Console.ReadLine();
            }

            int sum = repository.Sum(x => x.Food);

            Console.WriteLine(sum);

        }
    }
}
