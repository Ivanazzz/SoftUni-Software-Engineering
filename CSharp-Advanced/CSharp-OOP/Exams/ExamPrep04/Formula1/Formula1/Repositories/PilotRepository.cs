namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models.Contracts;
    using Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        private List<IPilot> models;
        public IReadOnlyCollection<IPilot> Models => this.models.AsReadOnly();

        public void Add(IPilot pilot)
        {
            models.Add(pilot);
        }

        public IPilot FindByName(string fullName)
        {
            return models.FirstOrDefault(c => c.FullName == fullName);
        }

        public bool Remove(IPilot pilot)
        {
            return models.Remove(pilot);
        }
    }
}
