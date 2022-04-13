using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            formulaRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.Any(x => x.FullName == fullName))
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilotRepository.Add(new Pilot(fullName));

            return string.Format
                (OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (formulaRepository.Models.Any(x => x.Model == model))
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar car = null;

            switch (type)
            {
                case nameof(Ferrari):
                    car = new Ferrari(model, horsepower, engineDisplacement);
                    break;

                case nameof(Williams):
                    car = new Williams(model, horsepower, engineDisplacement);
                    break;

                default:
                    throw new InvalidOperationException
                        (String.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            formulaRepository.Add(car);

            return string.Format
                (OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {

            if (raceRepository.Models.Any(x => x.RaceName == raceName))
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);

            raceRepository.Add(race);

            return string.Format
                (OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);

            if (pilot == null || pilot.CanRace)
            {
                throw new InvalidOperationException
                    (String.Format
                        (ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar car = formulaRepository.FindByName(carModel);

            if (car == null)
            {
                throw new NullReferenceException
                (String.Format
                    (ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            formulaRepository.Remove(car);

            return string.Format
                (OutputMessages.SuccessfullyPilotToCar,
                    pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException
                (String.Format
                    (ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            bool isPilotInTheRace = race.Pilots.Contains(pilot);


            if (pilot == null || (!pilot.CanRace) || isPilotInTheRace)
            {
                throw new InvalidOperationException
                (String.Format
                    (ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return string.Format
            (OutputMessages.SuccessfullyAddPilotToRace,
                pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException
                (String.Format
                    (ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException
                (String.Format
                    (ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException
                (String.Format
                    (ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            IPilot[] bestPilots =
                race.Pilots
                    .OrderByDescending(x => x.Car.RaceScoreCalculator
                        (race.NumberOfLaps)).Take(3).ToArray();

            bestPilots[0].WinRace();

            StringBuilder winners = new StringBuilder();

            winners.AppendLine($"Pilot { bestPilots[0].FullName } wins the { race.RaceName} race.");
            winners.AppendLine($"Pilot { bestPilots[1].FullName } is second in the { race.RaceName } race.");
            winners.Append($"Pilot { bestPilots[2].FullName } is third in the { race.RaceName } race.");

            race.TookPlace = true;

            return winners.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IRace race in raceRepository.Models
                .Where(x => x.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IPilot pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}