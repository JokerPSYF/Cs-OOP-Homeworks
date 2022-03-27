namespace FakeAxeAndDummy.Test
{
    public class FakeTarget : ITarget
    {
        public int Health { get => 10; }

        public int Experience { get => 20; }

        public void TakeAttack(int attackPoints)
        {
        }

        public int GiveExperience() => 20;

        public bool IsDead() => true;
    }
}