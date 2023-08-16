namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Booths.Contracts;

    public class BoothRepository : IRepository<IBooth>
    {
        private readonly List<IBooth> models;

        public BoothRepository()
        {
            models = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => models;

        public void AddModel(IBooth model)
            => models.Add(model);
    }
}
