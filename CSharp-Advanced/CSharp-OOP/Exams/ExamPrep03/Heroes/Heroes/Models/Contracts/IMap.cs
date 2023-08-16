namespace Heroes.Models.Contracts
{
    using System.Collections.Generic;

    public interface IMap
    {
        string Fight(ICollection<IHero> players);
    }
}