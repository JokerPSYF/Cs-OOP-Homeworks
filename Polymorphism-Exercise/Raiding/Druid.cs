using System;

namespace Raiding
{
    public class Druid : BaseHero
    {
        public override int Power
        {
            get => 80;
        }

        public override string CastAbility() => $"{GetType().Name} - {Name} healed for {Power}";

        public Druid(string name) : base(name)
        {
        }
    }
}