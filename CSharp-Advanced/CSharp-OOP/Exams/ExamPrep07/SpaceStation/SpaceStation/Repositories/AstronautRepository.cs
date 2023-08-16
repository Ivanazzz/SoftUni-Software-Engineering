namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Astronauts.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => astronauts;

        public void Add(IAstronaut model)
            => astronauts.Add(model);

        public IAstronaut FindByName(string name)
            => astronauts.FirstOrDefault(a => a.Name == name);

        public bool Remove(IAstronaut model)
            => astronauts.Remove(model);
    }
}
