namespace Easter.Models.Eggs
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public class Egg : IEgg
    {
        private const int ENERGY_DECREASE_VALUE = 10;

        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }

                name = value;
            }
        }

        public int EnergyRequired
        {
            get
            {
                return energyRequired;
            }
            private set
            {
                if (value < 0)
                {
                    energyRequired = 0;
                }

                energyRequired = value;
            }
        }

        public void GetColored()
            => EnergyRequired -= ENERGY_DECREASE_VALUE;

        public bool IsDone()
            => EnergyRequired == 0;
    }
}
