namespace Raiding.Factories.Contracts
{
    using Models;
    public interface IHeroFactory
    {
        BaseHero CreateHero(string type, string name);
    }
}
