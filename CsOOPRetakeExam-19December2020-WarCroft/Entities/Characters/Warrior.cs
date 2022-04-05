using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Contracts
{
    public class Warrior : Character, IAttacker
    {
        public Warrior(string name)
            : base(name, 100, 50, 40, new Satchel())
        {
        }
        
        public void Attack(Character character)
        {
            if (!this.IsAlive || !character.IsAlive) return;

            if (this == character)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.CharacterAttacksSelf));
            }

            if (this.AbilityPoints > character.Armor)
            {
                double remainingPoints = AbilityPoints - character.Armor;
                character.Armor = 0;
            }
        }
    }
}