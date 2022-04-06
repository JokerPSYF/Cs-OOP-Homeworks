using System;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
     public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.CharacterNameInvalid));
                }
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get => health;
           internal set // !!!
            {
                health = value;

                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }
                else if (health < 0)
                {
                    health = 0;
                    IsAlive = false;
                }
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get { return armor; }
            private set
            {
                armor = value;

                if (armor < 0)
                {
                    armor = 0; 
                }
            } 
        }

        public double AbilityPoints { get; private set; }

        public IBag Bag { get;  }


        public bool IsAlive { get; private set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (hitPoints > armor)
            {
                double remainingPoints = hitPoints - armor;
                armor = 0;
                health -= remainingPoints;
            }
            else
            {
                armor -= hitPoints;
            }

            if (health <= 0)
            {
                health = 0;
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string aliveOrDead = "";
            if (IsAlive == true)
            {
                aliveOrDead = "Alive";
            }
            else
            {
                aliveOrDead = "Dead";
            }
            sb.AppendLine($"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {aliveOrDead}");
            return sb.ToString().TrimEnd();
        }
    }
}