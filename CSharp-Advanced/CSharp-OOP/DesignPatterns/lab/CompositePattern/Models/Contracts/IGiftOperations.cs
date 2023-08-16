namespace CompositePattern.Models.Contracts
{
    public interface IGiftOperations
    {
        void Add(GiftBase giftBase);

        void Remove(GiftBase giftBase);
    }
}