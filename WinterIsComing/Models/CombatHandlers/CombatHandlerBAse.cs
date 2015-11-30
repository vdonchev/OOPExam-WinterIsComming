namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using Contracts;

    public abstract class CombatHandlerBase : ICombatHandler
    {
        public IUnit Unit { get; set; }

        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        public abstract ISpell GenerateAttack();
    }
}