namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Core;
    using Core.Exceptions;
    using Spells;

    public class MageCombatHandler : CombatHandlerBase
    {
        private bool firstAttack = true;

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            return candidateTargets
                .OrderByDescending(t => t.HealthPoints)
                .ThenBy(t => t.Name)
                .Take(3);
        }

        public override ISpell GenerateAttack()
        {
            ISpell currentSpell;
            if (this.firstAttack)
            {
                currentSpell = new FireBreath(this.Unit.AttackPoints);
            }
            else
            {
                currentSpell = new Blizzard(this.Unit.AttackPoints * 2);
            }

            if (this.Unit.EnergyPoints < currentSpell.EnergyCost)
            {
                throw new NotEnoughEnergyException(
                    string.Format(
                        GlobalMessages.NotEnoughEnergy,
                        this.Unit.Name,
                        currentSpell.GetType().Name));
            }

            this.firstAttack = !this.firstAttack;
            this.Unit.EnergyPoints -= currentSpell.EnergyCost;

            return currentSpell;
        }
    }
}