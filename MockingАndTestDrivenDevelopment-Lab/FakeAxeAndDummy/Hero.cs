using System;

namespace FakeAxeAndDummy
{
    public class Hero //: ITarget
    {
    //    private int health;
        private int experience;
        private string name;
        private IWeapon weapon;

        public Hero(string name, IWeapon weapon)
        {
            this.name = name;
            this.weapon = weapon;
            experience = 0;
           // health = 100;

        }

       // public int Health { get => health; }
        public int Experience { get => experience; private set => experience = value; }
        public string Name { get => name; }
        public IWeapon Weapon { get => weapon; }

        public void Attack(ITarget target)
        {
            Weapon.Attack(target);

            if (target.IsDead())
            {
                Experience += target.GiveExperience();
            }
        }

        //public void TakeAttack(int attackPoints)
        //{
        //    if (this.IsDead())
        //    {
        //        throw new InvalidOperationException("Dummy is dead.");
        //    }

        //    this.health -= attackPoints;
        //}

        //public int GiveExperience()
        //{
        //    if (!this.IsDead())
        //    {
        //        throw new InvalidOperationException("Target is not dead.");
        //    }

        //    return this.experience;
        //}

        //public bool IsDead()
        //{
        //    return this.health <= 0;
        //}
    }
}