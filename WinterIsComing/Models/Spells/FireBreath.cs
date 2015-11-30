namespace WinterIsComing.Models.Spells
{
    public class FireBreath : SpellBase
    {
        private const int FireBreathEnergyCost = 30;

        public FireBreath(int damage) 
            : base(damage, FireBreathEnergyCost)
        {
        }
    }
}