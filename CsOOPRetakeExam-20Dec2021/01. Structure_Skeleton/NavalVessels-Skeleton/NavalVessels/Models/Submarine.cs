using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed, double armorThickness) 
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {
            submergeMode = false;
        }

        public bool SubmergeMode { get => submergeMode; }

        public void ToggleSubmergeMode()
        {
            if (submergeMode)
            {
                submergeMode = false;
                mainWeaponCaliber -= 40;
                speed += 4;
            }
            else
            {
                submergeMode = true;
                mainWeaponCaliber += 40;
                speed -= 4;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($"*Type: {GetType().Name}");
            sb.AppendLine($"*Armor thickness: {ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {Speed} knots");

            if (Targets.Count == 0) sb.AppendLine("*Targets: None");
            else sb.AppendLine($"*Targets: {string.Join(", ", Targets)}");

            if (submergeMode) sb.AppendLine($"*Submerge mode: ON");
            else sb.AppendLine($"*Submerge mode: OFF");

            return sb.ToString().TrimEnd();
        }

    }
}