namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double NUCLEAR_WEAPON_PRICE = 15;

        public NuclearWeapon(int destructionLevel)
            : base(NUCLEAR_WEAPON_PRICE, destructionLevel)
        {

        }
    }
}
