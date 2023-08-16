namespace BirthdayCelebrations.Models.Contracts
{
    public interface ICitizen : IIDable
    {
        string Name { get; }

        int Age { get; }
    }
}
