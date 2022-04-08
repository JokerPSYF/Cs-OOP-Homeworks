using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts)
            {
                bool isEmpty = false;
                while (astronaut.CanBreath)
                {
                    //!!!!! OR FIRSTORDEFAULT
                    string item = planet.Items.FirstOrDefault();

                    if (item == null)
                    {
                        isEmpty = true; 
                        break;
                    }

                    planet.Items.Remove(item);

                    astronaut.Bag.Items.Add(item);

                    astronaut.Breath();
                }

                if (isEmpty) break;
            }
        }
    }
}