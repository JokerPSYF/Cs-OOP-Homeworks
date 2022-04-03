using System;
using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {
            sonarMode = false;
        }

        public bool SonarMode
        {
            get => sonarMode;
            private set => sonarMode = value;
        }

        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                mainWeaponCaliber -= 40;
                speed += 5;
                sonarMode = false;
            }
            else
            {
                mainWeaponCaliber += 40;
                speed -= 5;
                sonarMode = true;
            }
        }

        public override void RepairVessel()
        {
            ArmorThickness = 300;
        }

        public override string ToString()
        {
            string result = SonarMode ? "ON" : "OFF";

            return base.ToString()
                   + Environment.NewLine
                   + $" *Sonar mode: {result}";
        }
    }
}