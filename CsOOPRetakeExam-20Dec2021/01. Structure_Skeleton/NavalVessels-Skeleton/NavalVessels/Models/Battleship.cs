using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed, double armorThickness) 
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {
            SonarMode = false;
            ArmorThickness = 300;
        }

        public bool SonarMode { get; }
        public void ToggleSonarMode()
        {
            throw new System.NotImplementedException();
        }
    }
}