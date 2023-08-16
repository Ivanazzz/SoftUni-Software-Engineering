namespace Gym.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Equipment.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models;

        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => models;

        public void Add(IEquipment model)
            => models.Add(model);

        public IEquipment FindByType(string type)
            => models.FirstOrDefault(e => e.GetType().Name == type);

        public bool Remove(IEquipment model)
            => models.Remove(model);
    }
}
