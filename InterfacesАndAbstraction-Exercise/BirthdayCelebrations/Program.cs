using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthdable> repository = new List<IBirthdable>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if (input[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    repository.Add(citizen);
                }
                else if (input[0] == "Pet")
                {
                    Pet pet = new Pet(input[1], input[2]);
                    repository.Add(pet);
                }

                input = Console.ReadLine().Split();
            }

            string birthYear = Console.ReadLine();

            List<string> bornInThisYear = repository
                .Where(x => x.BirthDate.EndsWith(birthYear))
                .Select(x => x.BirthDate).ToList();

            if (bornInThisYear.Any())
            {
                Console.WriteLine(string.Join("\n", bornInThisYear));
            }
        }
    }
}
