namespace MilitaryElite.Models.Contracts
{
    using MilitaryElite.Models.Enums;

    public interface ISpecialisedSoldier :IPrivate
    {
        Corps Corps { get; }
    }
}
