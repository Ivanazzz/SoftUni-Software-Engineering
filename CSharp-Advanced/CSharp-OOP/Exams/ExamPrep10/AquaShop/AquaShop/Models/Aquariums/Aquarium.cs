namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Decorations.Contracts;
    using Fish.Contracts;
    using Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fishes;

        private Aquarium()
        {
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
        }

        protected Aquarium(string name, int capacity)
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
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort
            => Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fishes;

        public void AddFish(IFish fish)
        {
            if (Fish.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            fishes.Add(fish);
        }

        public bool RemoveFish(IFish fish)
            => fishes.Remove(fish);

        public void AddDecoration(IDecoration decoration)
            => decorations.Add(decoration);

        public void Feed()
        {
            foreach (IFish fish in fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string fishesOutput = fishes.Any()
                ? String.Join(", ", Fish.Select(f => f.Name))
                : "none";


            sb.AppendLine($"{Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fishesOutput}");
            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().Trim();
        }
    }
}
