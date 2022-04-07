using System;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo, racerOne);
            }

            if (!racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne, racerTwo);
            }

            racerOne.Race(); // !!!
            racerTwo.Race(); // !!!

            double racerOneBehavior = racerOne.RacingBehavior == "strict" ? 1.2 :
                racerOne.RacingBehavior == "aggressive" ? 1.1 : 1;

            double racerTwoBehavior = racerTwo.RacingBehavior == "strict" ? 1.2 :
                racerTwo.RacingBehavior == "aggressive" ? 1.1 : 1;

            double firstRacerChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneBehavior;

            double secondRacerChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoBehavior;

            string result = String.Empty;

            if (firstRacerChance > secondRacerChance)
            {
                result = String.Format
                    (OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                result = String.Format
                    (OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }

            return result;
        }
    }
}