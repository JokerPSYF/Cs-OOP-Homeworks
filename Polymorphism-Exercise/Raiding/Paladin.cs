namespace Raiding
{
    public class Paladin : BaseHero
    {
        public override int Power
        {
            get => 100;
        }

        public override string CastAbility() => $"{GetType().Name} - {Name} healed for {Power}";

        public Paladin(string name) : base(name)
        {
        }
    }
}