namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int FRESHWATER_FISH_INITIAL_SIZE = 3;
        private const int FRESHWATER_FISH_SIZE_INCREASE_VALUE = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            Size = FRESHWATER_FISH_INITIAL_SIZE;
        }

        public override void Eat()
            => Size += FRESHWATER_FISH_SIZE_INCREASE_VALUE;
    }
}
