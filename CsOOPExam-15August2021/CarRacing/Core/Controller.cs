using System;
using System.Linq;
using System.Text;
using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;

            switch (type)
            {
                case nameof(SuperCar):
                    car = new SuperCar(make, model, VIN, horsePower);
                    break;
                
                case nameof(TunedCar):
                    car = new SuperCar(make, model, VIN, horsePower);
                    break;

                default:
                    throw new ArgumentException
                        (ExceptionMessages.InvalidCarType);
            }

            cars.Add(car);

            return String.Format
                (OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer;

            ICar car = cars.FindBy(carVIN);

            if (car == null)
                throw new ArgumentException
                    (ExceptionMessages.CarCannotBeFound);

            switch (type)
            {
                case nameof(ProfessionalRacer):
                    racer = new ProfessionalRacer(username, car);
                    break;

                case nameof(StreetRacer):
                    racer = new StreetRacer(username, car);
                    break;

                default:
                    throw new ArgumentException
                        (ExceptionMessages.InvalidRacerType);
            }

            racers.Add(racer);

            return String.Format
                (OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null) throw new ArgumentException
                    (String.Format
                        (ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            
            if (racerTwo == null) throw new ArgumentException
                    (String.Format
                        (ExceptionMessages.RacerCannotBeFound, racerTwoUsername));

            return  map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IRacer racer in racers.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}