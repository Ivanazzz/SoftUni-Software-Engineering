namespace SpaceStation.Repositories
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

        public void Add(IPlanet model)
            => planets.Add(model);

        public IPlanet FindByName(string name)
            => planets.FirstOrDefault(a => a.Name == name);

        public bool Remove(IPlanet model)
            => planets.Remove(model);
    }
}
