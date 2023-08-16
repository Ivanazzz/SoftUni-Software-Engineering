namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int SALTWATER_AQUARIUM_CAPACITY = 25;

        public SaltwaterAquarium(string name)
            : base(name, SALTWATER_AQUARIUM_CAPACITY)
        {

        }
    }
}
