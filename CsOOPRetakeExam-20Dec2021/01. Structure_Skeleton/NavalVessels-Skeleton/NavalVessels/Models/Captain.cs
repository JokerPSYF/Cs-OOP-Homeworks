using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private const int INCREASEDBY = 10;

        private string fullName;
        private int combatExperience;
        private readonly List<IVessel> vessels;

        public Captain(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);

            FullName = fullName;
            combatExperience = 0;
            vessels = new List<IVessel>();
        }

        public string FullName
        {
            get { return fullName; }
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCaptainName);
                }

                fullName = value;
            }

        }

        public int CombatExperience
        {
            get => combatExperience;
            private set
            {
                combatExperience = value;
            }
        }
        public ICollection<IVessel> Vessels { get => vessels; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null) throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);

            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            combatExperience += INCREASEDBY;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            if (Vessels.Count > 0)
            {
                foreach (IVessel vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}