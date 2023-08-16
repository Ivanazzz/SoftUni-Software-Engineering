namespace WildFarm.Models.Contracts
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
