namespace AquaShop.Models.Fish.Contracts
{
    public interface IFish
    {
        string Name { get; }

        string Species { get; }

        int Size { get; }

        decimal Price { get; }

        void Eat();
    }
}
