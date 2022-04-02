using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        //   private double defaultArmorThikness;
        private double armorThickness;
        protected double mainWeaponCaliber;
        protected double speed;
        private List<string> targets;

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;

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
                else
                {
                    captain = value;
                }
            }
        }

        public double MainWeaponCaliber
        {
            get
            {
                return mainWeaponCaliber;
            }
            protected set
            {
                mainWeaponCaliber = value;
            }
        }

        public double Speed
        {
            get
            {
                return speed;
            }
            protected set
            {
                speed = value;
            }
        }

        public ICollection<string> Targets { get => targets; }

        public double ArmorThickness
        {
            get => armorThickness;
            set => armorThickness = value;

        }

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            this.ArmorThickness = armorThickness;
            //  this.defaultArmorThikness = armorThickness;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            targets = new List<string>();
        }

        public void Attack(IVessel target)
        {
            if (target == null) throw new NullReferenceException(ExceptionMessages.InvalidTarget);

            captain.IncreaseCombatExperience();

            target.Captain.IncreaseCombatExperience();

            target.ArmorThickness -= MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            Targets.Add(target.Name);
        }

        public virtual void RepairVessel()
        {
            ArmorThickness = default;
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