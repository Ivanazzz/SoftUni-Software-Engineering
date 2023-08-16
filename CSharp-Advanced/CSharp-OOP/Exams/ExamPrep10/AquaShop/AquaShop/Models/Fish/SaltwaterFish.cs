namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int SALTWATER_FISH_INITIAL_SIZE = 5;
        private const int SALTWATER_FISH_SIZE_INCREASE_VALUE = 2;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            Size = SALTWATER_FISH_INITIAL_SIZE;
        }

        public override void Eat()
            => Size += SALTWATER_FISH_SIZE_INCREASE_VALUE;
    }
}
