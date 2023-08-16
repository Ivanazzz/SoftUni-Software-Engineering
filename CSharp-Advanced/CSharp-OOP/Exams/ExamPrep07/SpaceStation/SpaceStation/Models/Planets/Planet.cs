namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;
        private readonly List<string> items;

        public Planet(string name)
        {
            Name = name;
            items = new List<string>();
        }

        public ICollection<string> Items => items;

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
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

    }
}
