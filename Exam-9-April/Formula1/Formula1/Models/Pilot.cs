using System;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            FullName = fullName;
            CanRace = false;
            NumberOfWins = 0;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidPilot, value));
                }

                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException
                        (String.Format(ExceptionMessages.InvalidCarForPilot));
                }

                car = value;
            }
        }

        public int NumberOfWins { get; private set; }
        public bool CanRace { get; private set; }


        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            CanRace = true;
        }

        public void WinRace() => this.NumberOfWins++;

        public override string ToString()
            => $"Pilot {fullName} has {NumberOfWins} wins.";
        
    }
}