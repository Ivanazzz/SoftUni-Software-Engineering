namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models.Contracts;
    using Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        public RaceRepository()
        {
            models = new List<IRace>();
        }

        private List<IRace> models;
        public IReadOnlyCollection<IRace> Models => this.models.AsReadOnly();

        public void Add(IRace race)
        {
            models.Add(race);
        }

        public IRace FindByName(string raceName)
        {
            return models.FirstOrDefault(c => c.RaceName == raceName);
        }

        public bool Remove(IRace race)
        {
            return models.Remove(race);
        }
    }
}
