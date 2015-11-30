namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Core;
    using Core.Exceptions;
    using Spells;

    public class IceGiantCombatHandler : CombatHandlerBase
    {
        private const int HealthBreakPoint = 150;
        private const int AdditionalAttackPoints = 5;

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints <= HealthBreakPoint)
            {
                return candidateTargets
                    .Take(1);
            }

            return candidateTargets;
        }

        public override ISpell GenerateAttack()
        {
            ISpell currentSpell = new Stomp(this.Unit.AttackPoints);
            if (this.Unit.EnergyPoints < currentSpell.EnergyCost)
            {
                throw new NotEnoughEnergyException(
                    string.Format(
                        GlobalMessages.NotEnoughEnergy,
                        this.Unit.Name,
                        currentSpell.GetType().Name));
            }

            this.Unit.EnergyPoints -= currentSpell.EnergyCost;
            this.Unit.AttackPoints += AdditionalAttackPoints;

            return currentSpell;
        }
    }
}