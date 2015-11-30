namespace WinterIsComing.Models.Units
{
    using System;
    using System.Text;
    using Contracts;

    public abstract class UnitBase : IUnit
    {
        private ICombatHandler combatHandler;
        private string name;

        protected UnitBase(
            int x,
            int y,
            string name,
            int range,
            int attackPoints,
            int healthPoints,
            int defensePoints,
            int energyPoints,
            ICombatHandler combatHandler)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.Range = range;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.EnergyPoints = energyPoints;
            this.CombatHandler = combatHandler;
            this.combatHandler.Unit = this;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }

        public int Range { get; }

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public ICombatHandler CombatHandler
        {
            get
            {
                return this.combatHandler;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                }

                this.combatHandler = value;
            }
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            res.AppendLine($">{this.Name} - {this.GetType().Name} at ({this.X},{this.Y})");
            if (this.HealthPoints > 0)
            {
                res.AppendLine($"-Health points = {this.HealthPoints}");
                res.AppendLine($"-Attack points = {this.AttackPoints}");
                res.AppendLine($"-Defense points = {this.DefensePoints}");
                res.AppendLine($"-Energy points = {this.EnergyPoints}");
                res.AppendLine($"-Range = {this.Range}");
            }
            else
            {
                res.AppendLine("(Dead)");
            }

            return res.ToString().Trim();
        }
    }
}