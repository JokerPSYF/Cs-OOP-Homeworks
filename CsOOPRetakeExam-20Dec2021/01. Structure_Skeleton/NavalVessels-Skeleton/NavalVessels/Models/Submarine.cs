using System;
using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 200)
        {
            submergeMode = false;
        }

        public bool SubmergeMode
        {
            get => submergeMode;
            private set
            {
                value = submergeMode;
            }
        }

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

        public override void RepairVessel()
        {
            ArmorThickness = 200;
        }

        public override string ToString()
        {
            string result = SubmergeMode ? "ON" : "OFF";

            return base.ToString()
                   + Environment.NewLine
                   + $" *Submerge mode: {result}";
        }

    }
}