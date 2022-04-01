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

        private int combatExperience;

        public Captain(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))  throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
            
            FullName = fullName;
            combatExperience = 0;
            Vessels = new List<IVessel>();
        }
        
        public string FullName { get; }
        public int CombatExperience { get => combatExperience; }
        public ICollection<IVessel> Vessels { get; }

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

            foreach (IVessel vessel in Vessels)
            {
                sb.AppendLine(vessel.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}