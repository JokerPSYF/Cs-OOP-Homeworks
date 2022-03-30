using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Models
{
    public class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private  double defaultArmorThikness;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
            }
        }
        
        public ICaptain Captain
        {
            get
            {
                return captain;
            }
            set{
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
            } }

        public double ArmorThickness { get; set; }
        public double MainWeaponCaliber { get; }
        public double Speed { get; }
        public ICollection<string> Targets { get; }

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            ArmorThickness = armorThickness;
            defaultArmorThikness = armorThickness;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
        }

        public void Attack(IVessel target)
        {
            if (target == null) throw new NullReferenceException(ExceptionMessages.InvalidTarget);

            target.ArmorThickness -= MainWeaponCaliber;

            if (target.MainWeaponCaliber < 0)
            {
                target.ArmorThickness = 0;

                Targets.Add(target.Name);
            }
        }

        public void RepairVessel()
        {
            ArmorThickness = defaultArmorThikness;
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($"*Type: {GetType().Name}");
            sb.AppendLine($"*Armor thickness: {ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {Speed} knots");
            sb.AppendLine($"- {Name}");
            if (Targets.Count == 0) sb.AppendLine("*Targets: None");
            else sb.AppendLine($"*Targets: {string.Join(", ", Targets)}");
            
            return sb.ToString().TrimEnd();
        }
    }
}