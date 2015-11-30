namespace WinterIsComing.Models.Spells
{
    using Contracts;

    public abstract class SpellBase : ISpell
    {
        protected SpellBase(int damage, int energyCost)
        {
            this.Damage = damage;
            this.EnergyCost = energyCost;
        }

        public int Damage { get; }

        public int EnergyCost { get; }
    }
}