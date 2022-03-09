namespace Raiding
{
    public class Rogue : BaseHero
    {
        public override int Power { get => 80; }

        public override string CastAbility() => $"{GetType().Name} - {Name} hit for {Power} damage";

        public Rogue(string name) : base(name)
        {
        }
    }
}