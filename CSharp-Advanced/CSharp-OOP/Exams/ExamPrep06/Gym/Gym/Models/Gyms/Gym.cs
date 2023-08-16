namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Athletes.Contracts;
    using Contracts;
    using Equipment.Contracts;
    using Utilities.Messages;

    public abstract class Gym : IGym
    {
        private string name;
        private readonly ICollection<IAthlete> athletes;
        private readonly ICollection<IEquipment> equipments;

        private Gym()
        {
            athletes = new List<IAthlete>();
            equipments = new List<IEquipment>();
        }

        public Gym(string name, int capacity)
            : this()
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight
            => Equipment.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment => equipments;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
            => athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment)
            => equipments.Add(equipment);

        public void Exercise()
        {
            foreach (IAthlete athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            string athletesOutput = Athletes.Any()
                ? string.Join(", ", Athletes.Select(a => a.FullName))
                : "No athletes";

            sb.AppendLine($"{Name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {athletesOutput}");
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}
