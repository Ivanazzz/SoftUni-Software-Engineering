namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Text;
    using System.Linq;

    using Contracts;
    using Bags.Contracts;
    using Utilities.Messages;
    using SpaceStation.Models.Bags;

    public abstract class Astronaut : IAstronaut
    {
        private const int NEEDED_OXYGEN_FOR_BREATHING = 10;

        private string name;
        private double oxygen;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            bag = new Backpack();
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
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return oxygen;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                oxygen = value;
            }
        }

        public bool CanBreath => Oxygen > 0;

        public IBag Bag => bag;

        public virtual void Breath()
        {
            if (Oxygen >= NEEDED_OXYGEN_FOR_BREATHING)
            {
                Oxygen -= NEEDED_OXYGEN_FOR_BREATHING;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string bagItemsOutput = Bag.Items.Any()
                ? string.Join(", ", Bag.Items)
                : "none";

            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Oxygen: {Oxygen}");
            sb.AppendLine($"Bag items: {bagItemsOutput}");

            return sb.ToString().Trim();
        }
    }
}
