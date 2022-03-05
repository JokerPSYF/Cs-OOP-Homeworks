using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> repository = new List<IIdentifiable>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if (input.Length == 3)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    repository.Add(citizen);
                }
                else
                {
                    Robot robot = new Robot(input[0], input[1]);
                    repository.Add(robot);
                }

                input = Console.ReadLine().Split();
            }

            string fakeIds = Console.ReadLine();

            List<string> criminals = repository.Where(x => x.Id.EndsWith(fakeIds)).Select(x => x.Id).ToList();

            Console.WriteLine(string.Join("\n", criminals));
        }
    }
}
