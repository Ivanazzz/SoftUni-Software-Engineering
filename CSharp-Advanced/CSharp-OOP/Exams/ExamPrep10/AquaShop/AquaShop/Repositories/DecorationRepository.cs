namespace AquaShop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;

        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => decorations;

        public void Add(IDecoration model)
            => decorations.Add(model);

        public IDecoration FindByType(string type)
            => decorations.FirstOrDefault(d => d.GetType().Name == type);

        public bool Remove(IDecoration model)
            => decorations.Remove(model);
    }
}
