using System;
using System.Collections.Generic;
using System.Linq;
using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels = new VesselRepository();
        private ICollection<ICaptain> captains = new List<ICaptain>();

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);

            if (captains.Contains(captain))
            {
                throw new InvalidOperationException
                    (String.Format(OutputMessages.CaptainIsAlreadyHired, fullName));
            }

            captains.Add(captain);

            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName); ;
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            bool isValid = false;

            switch (vesselType)
            {
                case nameof(Submarine):
                    if (vessels.FindByName(name) == null)
                    {
                        vessels.Add(new Submarine(name, mainWeaponCaliber, speed));
                        isValid = true;
                    }
                    break;

                case nameof(Battleship):
                    if (vessels.FindByName(name) == null)
                    {
                        vessels.Add(new Battleship(name, mainWeaponCaliber, speed));
                        isValid = true;
                    }
                    break;

                default:
                    throw new InvalidOperationException(OutputMessages.InvalidVesselType);
            }

            if (isValid)
            {
                return String.Format(OutputMessages.
                    SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            }
            else
            {
                throw new InvalidOperationException
                            (String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name));
            }
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            IVessel vessel = vessels.FindByName(selectedVesselName);
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);

            if (captain == null)
            {
                throw new InvalidOperationException
                    (String.Format(OutputMessages.CaptainNotFound, selectedCaptainName));
            }

            if (vessel == null)
            {
                throw new InvalidOperationException
                    (String.Format(OutputMessages.VesselNotFound, selectedVesselName));
            }

            if (vessel.Captain != null)
            {
                throw new InvalidOperationException
                    (String.Format(OutputMessages.VesselOccupied, selectedVesselName));
            }


            captain.Vessels.Add(vessel);
            vessel.Captain = captain;

            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.First(x => x.FullName == captainFullName);

            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)throw new InvalidOperationException
                    (String.Format(OutputMessages.VesselNotFound, vesselName));

            switch (vessel.GetType().Name)
            {
                case nameof(Submarine):
                    Submarine sub = (Submarine)vessel;
                    sub.ToggleSubmergeMode();
                    return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);

                case nameof(Battleship):
                    Battleship battleship = (Battleship) vessel;
                    battleship.ToggleSonarMode();
                    return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                default:
                    throw new InvalidOperationException("Theres no such ship type");
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = vessels.FindByName(attackingVesselName);
            IVessel deffender = vessels.FindByName(defendingVesselName);

            if (attacker == null)
                throw new InvalidOperationException
                    (String.Format(OutputMessages.VesselNotFound, attackingVesselName));

            if (deffender == null) 
                throw new InvalidOperationException
                (String.Format(OutputMessages.VesselNotFound, defendingVesselName));

            if (attacker.ArmorThickness == 0)
                throw new InvalidOperationException
                (String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName));
            
            if (deffender.ArmorThickness == 0)
                throw new InvalidOperationException
                (String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName));
            
            attacker.Attack(deffender);

            return String.Format
                (OutputMessages.SuccessfullyAttackVessel,
                    defendingVesselName,
                    attackingVesselName,
                    deffender.ArmorThickness);
        }

        public string ServiceVessel(string vesselName)
        {
            var vassel = vessels.FindByName(vesselName);

            if (vassel == null)
            {
                throw new InvalidOperationException
                    (String.Format(OutputMessages.VesselNotFound, vesselName));
            }

            vassel.RepairVessel();

            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }
    }
}