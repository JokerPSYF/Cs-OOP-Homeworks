using System;
using System.Collections.Generic;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();

            int totalHeores = int.Parse(Console.ReadLine());

            while(raidGroup.Count < totalHeores)
            {
                BaseHero hero = default;
                string name = Console.ReadLine();

                string type = Console.ReadLine();

                switch (type)
                {
                    case "Druid":
                        hero = new Druid(name);
                        break;

                    case "Paladin":
                        hero = new Paladin(name);
                        break;

                    case "Rogue":
                        hero = new Rogue(name);
                        break;

                    case "Warrior":
                        hero = new Warrior(name);
                        break;

                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }

                if (hero != default)
                {
                    raidGroup.Add(hero);
                }
                else
                {
                    continue;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalHeroesPower = 0;

            foreach (BaseHero hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                totalHeroesPower += hero.Power;
            }

            if (totalHeroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

    }
}
