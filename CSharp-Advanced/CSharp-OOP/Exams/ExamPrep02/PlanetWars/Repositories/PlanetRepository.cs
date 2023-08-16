namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => planets;

        public void AddItem(IPlanet model)
            => planets.Add(model);

        public IPlanet FindByName(string name)
            => planets.FirstOrDefault(p => p.Name == name);

        public bool RemoveItem(string name)
        {
            IPlanet planetToBeRemoved = FindByName(name);

            return planets.Remove(planetToBeRemoved);
        }
    }
}
