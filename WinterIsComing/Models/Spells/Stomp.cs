namespace WinterIsComing.Models.Spells
{
    public class Stomp : SpellBase
    {
        private const int StompEnergyCost = 10;

        public Stomp(int damage) 
            : base(damage, StompEnergyCost)
        {
        }
    }
}