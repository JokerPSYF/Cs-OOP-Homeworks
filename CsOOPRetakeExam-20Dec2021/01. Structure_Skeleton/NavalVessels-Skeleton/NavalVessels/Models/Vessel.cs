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
        private double defaultArmorThikness;
        private double armorThickness;
        protected double mainWeaponCaliber;
        protected double speed;

        public string Name
        {
            get => name;
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
            get => captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
            }
        }

        public double MainWeaponCaliber => mainWeaponCaliber;
        public double Speed => speed;
        public ICollection<string> Targets { get; }
        public double  ArmorThickness { get => armorThickness; set => this.armorThickness = value; }

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            this.armorThickness = armorThickness;
            this.defaultArmorThikness = armorThickness;
            this.mainWeaponCaliber = mainWeaponCaliber;
            this.speed = speed;
        }

        public void Attack(IVessel target)
        {
            if (target == null) throw new NullReferenceException(ExceptionMessages.InvalidTarget);

            captain.IncreaseCombatExperience();
            
            target.Captain.IncreaseCombatExperience();

            target.ArmorThickness -= MainWeaponCaliber;

            if (target.MainWeaponCaliber < 0)
            {
                target.ArmorThickness = 0;

                Targets.Add(target.Name);
            }
        }

        public void RepairVessel()
        {
            if (this.GetType() is IBattleship && this.armorThickness < 300)
            {
                this.armorThickness = 300;
            }
            else if (this.GetType() is ISubmarine && this.armorThickness < 200)
            {
                this.armorThickness = 200;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($"*Type: {GetType().Name}");
            sb.AppendLine($"*Armor thickness: {armorThickness}");
            sb.AppendLine($"*Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {Speed} knots");
            if (Targets.Count == 0) sb.AppendLine("*Targets: None");
            else sb.AppendLine($"*Targets: {string.Join(", ", Targets)}");

            return sb.ToString().TrimEnd();
        }
    }
}