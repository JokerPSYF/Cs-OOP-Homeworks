using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed, double armorThickness)
            : base(name, mainWeaponCaliber, speed, 200)
        {
            sonarMode = false;
        }

        public bool SonarMode { get => sonarMode; }

        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                sonarMode = false;
                mainWeaponCaliber -= 40;
                speed += 5;
            }
            else
            {
                sonarMode = true;
                mainWeaponCaliber += 40;
                speed -= 5;
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

            if (SonarMode) sb.AppendLine($"*Submerge mode: ON");
            else sb.AppendLine($"*Submerge mode: OFF");

            return sb.ToString().TrimEnd();
        }
    }
}