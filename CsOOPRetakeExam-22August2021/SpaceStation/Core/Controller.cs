using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanets;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            exploredPlanets = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            switch (type)
            {
                case nameof(Biologist):
                    astronaut = new Biologist(astronautName);
                    break;
                
                case nameof(Geodesist):
                    astronaut = new Geodesist(astronautName);
                    break;
               
                case nameof(Meteorologist):
                    astronaut = new Meteorologist(astronautName);
                    break;

                default:
                    throw new InvalidOperationException
                        (ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astronaut);

            return String.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            for (int i = 0; i < items.Length; i++)
            {
                planet.Items.Add(items[i]);
            }

            planets.Add(planet);

            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException
                (String.Format
                (ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);

            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            IMission mission = new Mission(); 

            var suitableAstronauts = new List<IAstronaut>();

            foreach (var astronaut in astronauts.Models)
            {
                if (astronaut.Oxygen > 60)
                {
                    suitableAstronauts.Add(astronaut);
                }
            }

            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidAstronautCount);
            }

            mission.Explore(planet, suitableAstronauts);

            int deathAstronauts =
                suitableAstronauts.Count(x => !x.CanBreath);

            exploredPlanets++;

            return String.Format
                (OutputMessages.PlanetExplored, planetName, deathAstronauts);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (IAstronaut astronaut in astronauts.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}