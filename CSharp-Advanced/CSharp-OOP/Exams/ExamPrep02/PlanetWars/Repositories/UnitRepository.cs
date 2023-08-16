namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> units;

        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => units;

        public void AddItem(IMilitaryUnit model)
            => units.Add(model);

        public IMilitaryUnit FindByName(string name)
            => units.FirstOrDefault(u => u.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IMilitaryUnit unitToBeRemoved = FindByName(name);

            return units.Remove(unitToBeRemoved);
        }
    }
}
