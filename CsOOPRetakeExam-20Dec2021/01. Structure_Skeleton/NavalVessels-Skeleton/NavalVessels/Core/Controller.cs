using System;
using System.Collections.Generic;
using System.Linq;
using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);

            if (captains.All(x => x.FullName != fullName))
            {
                captains.Add(captain);

                return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);

            }
            //throw new InvalidOperationException
            return String.Format
                (OutputMessages.CaptainIsAlreadyHired, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel;

            if (vessels.FindByName(name) != null)
            {
                // throw new InvalidOperationException
                return (String.Format
                    (OutputMessages.VesselIsAlreadyManufactured, vesselType, name));
            }

            switch (vesselType)
            {
                case nameof(Submarine):
                    vessel = new Submarine(name, mainWeaponCaliber, speed);
                    vessels.Add(vessel);
                    break;

                case nameof(Battleship):
                    vessel = new Battleship(name, mainWeaponCaliber, speed);
                    vessels.Add(vessel);
                    break;

                default:
                    // throw new InvalidOperationException
                    return (OutputMessages.InvalidVesselType);
            }
            return String.Format(OutputMessages.
                    SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);

        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            IVessel vessel = vessels.FindByName(selectedVesselName);
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);

            if (captain == null)
            {
                //throw new InvalidOperationException
                return (String.Format
                    (OutputMessages.CaptainNotFound, selectedCaptainName));
            }

            if (vessel == null)
            {
                //throw new InvalidOperationException
                return (String.Format
                    (OutputMessages.VesselNotFound, selectedVesselName));
            }

            if (vessel.Captain != null)
            {
                //throw new InvalidOperationException
                return (String.Format
                    (OutputMessages.VesselOccupied, selectedVesselName));
            }


            captain.Vessels.Add(vessel);
            vessel.Captain = captain;

            return String.Format
                (OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == captainFullName);

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

            if (vessel == null)//throw new InvalidOperationException
                return (String.Format
                    (OutputMessages.VesselNotFound, vesselName));

            switch (vessel.GetType().Name)
            {
                case nameof(Submarine):
                    ISubmarine sub = (Submarine)vessel;
                    sub.ToggleSubmergeMode();
                    return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);

                case nameof(Battleship):
                    IBattleship battleship = (Battleship)vessel;
                    battleship.ToggleSonarMode();
                    return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                default:
                    //throw new InvalidOperationException("Theres no such ship type");
                    return "Theres no such ship type";
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = vessels.FindByName(attackingVesselName);
            IVessel deffender = vessels.FindByName(defendingVesselName);

            if (attacker == null)
                //throw new InvalidOperationException
                return String.Format
                    (OutputMessages.VesselNotFound, attackingVesselName);

            if (deffender == null)
                // throw new InvalidOperationException
                return
                    (String.Format(OutputMessages.VesselNotFound, defendingVesselName));

            if (attacker.ArmorThickness == 0)
                //throw new InvalidOperationException
                return (String.Format
                   (OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName));

            if (deffender.ArmorThickness == 0)
                // throw new InvalidOperationException
                return (String.Format
                    (OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName));

            attacker.Attack(deffender);
            attacker.Captain.IncreaseCombatExperience();
            deffender.Captain.IncreaseCombatExperience();

            return String.Format
                (OutputMessages.SuccessfullyAttackVessel,
                    defendingVesselName,
                    attackingVesselName,
                    deffender.ArmorThickness);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vassel = vessels.FindByName(vesselName);

            if (vassel == null)
            {
                //  throw new InvalidOperationException
                return (String.Format
                        (OutputMessages.VesselNotFound, vesselName));
            }

            vassel.RepairVessel();

            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }
    }
}