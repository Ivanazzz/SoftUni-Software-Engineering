namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Bunnies.Contracts;


    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> bunnies;

        public BunnyRepository()
        {
            bunnies = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => bunnies;

        public void Add(IBunny model)
            => bunnies.Add(model);

        public IBunny FindByName(string name)
            => bunnies.FirstOrDefault(b => b.Name == name);

        public bool Remove(IBunny model)
            => bunnies.Remove(model);
    }
}
