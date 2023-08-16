namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => weapons;

        public void Add(IWeapon model)
            => weapons.Add(model);

        public IWeapon FindByName(string name)
            => weapons.FirstOrDefault(w => w.Name == name);

        public bool Remove(IWeapon model)
            => weapons.Remove(model);
    }
}
