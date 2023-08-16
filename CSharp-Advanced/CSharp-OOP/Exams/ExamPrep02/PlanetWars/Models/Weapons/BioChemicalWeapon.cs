namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        private const double BIO_CHEMICAL_WEAPON_PRICE = 3.2;

        public BioChemicalWeapon(int destructionLevel) 
            : base(BIO_CHEMICAL_WEAPON_PRICE, destructionLevel)
        {

        }
    }
}
