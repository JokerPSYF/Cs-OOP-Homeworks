using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characterParty;
        private List<Item> itemPool;

        public WarController()
        {
            characterParty = new List<Character>();
            itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            Character hero = null;
            switch (args[0])
            {
                case nameof(Warrior):
                    hero = new Warrior(args[1]);
                    break;

                case nameof(Priest):
                    hero = new Priest(args[1]);
                    break;

                default:
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidCharacterType, args[0]));
            }

            characterParty.Add(hero);

            return String.Format(SuccessMessages.JoinParty, args[1]);
        }

        public string AddItemToPool(string[] args)
        {
            Item item = null;
            switch (args[0])
            {
                case nameof(FirePotion):
                    item = new FirePotion();
                    break;

                case nameof(HealthPotion):
                    item = new HealthPotion();
                    break;

                default:
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidItem, args[0]));
            }

            itemPool.Add(item);

            return String.Format(SuccessMessages.AddItemToPool, args[0]);
        }

        public string PickUpItem(string[] args)
        {
            Character hero = characterParty.FirstOrDefault(x => x.Name == args[0]);

            if (hero == null) throw new ArgumentException
                    (String.Format(ExceptionMessages.CharacterNotInParty, args[0]));

            if (!itemPool.Any()) throw new InvalidOperationException
                    (String.Format(ExceptionMessages.ItemPoolEmpty));

            Item item = itemPool.Last();

            hero.Bag.AddItem(item);

            return String.Format(SuccessMessages.PickUpItem, args[0], item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            Character hero = characterParty.FirstOrDefault(x => x.Name == args[0]);

            if (hero == null)
                throw new ArgumentException
                    (string.Format(ExceptionMessages.CharacterNotInParty, args[0]));

            Item item = hero.Bag.GetItem(args[1]);

            item.AffectCharacter(hero);

            return String.Format
                (SuccessMessages.UsedItem, args[0], item.GetType().Name);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Character hero in characterParty
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health))
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            Character attacker = characterParty
                .FirstOrDefault(x => x.Name == args[0]);
            
            Character receiver = characterParty
                .FirstOrDefault(x => x.Name == args[1]);

            if (attacker == null)
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

            if (receiver == null)
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.CharacterNotInParty, args[1]));
            }

            if (attacker.GetType().Name != nameof(Warrior))
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.AttackFail, args[0]));
            }

            Warrior warrior = (Warrior)attacker; 

            warrior.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format(SuccessMessages.AttackCharacter,
                args[0], 
                args[1],
                warrior.AbilityPoints,
                args[1], 
                receiver.Health,
                receiver.BaseHealth,
                receiver.Armor,
                receiver.BaseArmor
                ));

            if (!receiver.IsAlive)
            {
                sb.Append
                    (String.Format(SuccessMessages.AttackKillsCharacter, args[1]));
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            Character healer = characterParty
                .FirstOrDefault(x => x.Name == args[0]);

            Character receiver = characterParty
                .FirstOrDefault(x => x.Name == args[1]);

            if (healer == null)
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

            if (receiver == null)
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.CharacterNotInParty, args[1]));
            }

            if (healer.GetType().Name != nameof(Priest))
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.HealerCannotHeal, args[0]));
            }

            Priest priest = (Priest)healer;

            priest.Heal(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format(SuccessMessages.HealCharacter,
                args[0],
                args[1],
                priest.AbilityPoints,
                args[1],
                receiver.Health
            ));

            return sb.ToString().TrimEnd();
        }
    }
}
