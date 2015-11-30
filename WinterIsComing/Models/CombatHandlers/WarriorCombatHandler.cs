namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Core;
    using Core.Exceptions;
    using Spells;

    public class WarriorCombatHandler : CombatHandlerBase
    {
        private const int AdditionalDamageBreakPoint = 80;
        private const int AttackEnergyCostBreakPoint = 50;

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            return candidateTargets
                .OrderBy(t => t.HealthPoints)
                .ThenBy(t => t.Name)
                .Take(1);
        }

        private int SpellDamage
        {
            get
            {
                var damagePoints = this.Unit.AttackPoints;
                if (this.Unit.HealthPoints <= AdditionalDamageBreakPoint)
                {
                    damagePoints += this.Unit.HealthPoints * 2;
                }

                return damagePoints;
            }
        }

        public override ISpell GenerateAttack()
        {
            ISpell currentSpell = new Cleave(this.SpellDamage);
            if (this.Unit.HealthPoints > AttackEnergyCostBreakPoint)
            {
                if (this.Unit.EnergyPoints < currentSpell.EnergyCost)
                {
                    throw new NotEnoughEnergyException(
                        string.Format(
                            GlobalMessages.NotEnoughEnergy, 
                            this.Unit.Name, 
                            currentSpell.GetType().Name));
                }

                this.Unit.EnergyPoints -= currentSpell.EnergyCost;
            }

            return currentSpell;
        }
    }
}