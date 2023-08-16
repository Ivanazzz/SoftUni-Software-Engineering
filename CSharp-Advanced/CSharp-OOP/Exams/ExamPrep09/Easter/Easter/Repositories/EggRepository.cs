namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Eggs.Contracts;

    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> eggs;

        public EggRepository()
        {
            eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => eggs;

        public void Add(IEgg model)
            => eggs.Add(model);

        public IEgg FindByName(string name)
            => eggs.FirstOrDefault(e => e.Name == name);

        public bool Remove(IEgg model)
            => eggs.Remove(model);
    }
}
