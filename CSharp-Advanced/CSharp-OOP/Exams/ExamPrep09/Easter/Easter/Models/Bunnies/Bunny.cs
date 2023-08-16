namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Dyes.Contracts;
    using Utilities.Messages;

    public abstract class Bunny : IBunny
    {
        private const int ENERGY_DECREASE_VALUE = 10;

        private string name;
        private int energy;
        private List<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dyes = new List<IDye>();
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
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                name = value;
            }
        }

        public int Energy
        {
            get
            {
                return energy;
            }
            protected set
            {
                if (value < 0)
                {
                    energy = 0;
                }

                energy = value;
            }
        }

        public ICollection<IDye> Dyes => dyes;

        public void AddDye(IDye dye)
            => dyes.Add(dye);

        public virtual void Work()
            => Energy -= ENERGY_DECREASE_VALUE;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int unfinishedDyesCount = Dyes
                .Where(d => !d.IsFinished())
                .ToList()
                .Count;

            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Energy: {Energy}");
            sb.AppendLine($"Dyes: {unfinishedDyesCount} not finished");

            return sb.ToString().Trim();
        }
    }
}
