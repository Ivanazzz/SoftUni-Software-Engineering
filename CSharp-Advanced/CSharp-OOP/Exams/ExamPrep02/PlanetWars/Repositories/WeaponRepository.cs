namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => weapons;

        public void AddItem(IWeapon model)
            => weapons.Add(model);

        public IWeapon FindByName(string name)
            => weapons.FirstOrDefault(w => w.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IWeapon weaponToBeRemoved = FindByName(name);

            return weapons.Remove(weaponToBeRemoved);
        }
    }
}
