namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        private const double SPACE_MISSILES_PRICE = 8.75;

        public SpaceMissiles(int destructionLevel)
            : base(SPACE_MISSILES_PRICE, destructionLevel)
        {

        }
    }
}
