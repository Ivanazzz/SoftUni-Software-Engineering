namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => heroes;

        public void Add(IHero model)
            => heroes.Add(model);

        public IHero FindByName(string name)
            => heroes.FirstOrDefault(h => h.Name == name);

        public bool Remove(IHero model)
            => heroes.Remove(model);
    }
}
