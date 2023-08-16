namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int FRESHWATER_AQUARIUM_CAPACITY = 50;

        public FreshwaterAquarium(string name)
            : base (name, FRESHWATER_AQUARIUM_CAPACITY)
        {

        }
    }
}
