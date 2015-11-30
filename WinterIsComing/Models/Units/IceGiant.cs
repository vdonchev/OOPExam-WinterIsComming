﻿namespace WinterIsComing.Models.Units
{
    using CombatHandlers;

    public class IceGiant : UnitBase
    {
        private const int IceGiantAttack = 150;
        private const int IceGiantHealth = 300;
        private const int IceGiantDefense = 60;
        private const int IceGiantEnergy = 50;
        private const int IceGiantRange = 1;

        public IceGiant(int x, int y, string name) 
            : base(x, y, name,
                  IceGiantRange,
                  IceGiantAttack,
                  IceGiantHealth,
                  IceGiantDefense,
                  IceGiantEnergy, 
                  new IceGiantCombatHandler())
        {
        }
    }
}