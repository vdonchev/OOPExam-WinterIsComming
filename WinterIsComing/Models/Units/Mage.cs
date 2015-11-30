﻿namespace WinterIsComing.Models.Units
{
    using CombatHandlers;

    public class Mage : UnitBase
    {
        private const int MageAttack = 80;
        private const int MageHealth = 80;
        private const int MageDefense = 40;
        private const int MageEnergy = 120;
        private const int MageRange = 2;

        public Mage(int x, int y, string name) 
            : base(x, y, name,
                  MageRange, 
                  MageAttack, 
                  MageHealth, 
                  MageDefense, 
                  MageEnergy, 
                  new MageCombatHandler())
        {
        }
    }
}