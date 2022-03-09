namespace Raiding
{
    public class Warrior : BaseHero
    {
        public override int Power { get => 100; }

        public override string CastAbility() => $"{GetType().Name} - {Name} hit for {Power} damage";

        public Warrior(string name) : base(name)
        {
        }
    }
}