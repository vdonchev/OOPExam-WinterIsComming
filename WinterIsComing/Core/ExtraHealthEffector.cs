namespace WinterIsComing.Core
{
    using System.Collections.Generic;
    using Contracts;

    public class ExtraHealthEffector : IUnitEffector
    {
        private const int ExtraHealth = 50;

        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (var unit in units)
            {
                unit.HealthPoints += ExtraHealth;
            }
        }
    }
}