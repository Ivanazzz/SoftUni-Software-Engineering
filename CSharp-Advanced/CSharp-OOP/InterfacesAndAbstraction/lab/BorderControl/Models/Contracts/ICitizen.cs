namespace BorderControl.Models.Contracts
{
    public interface ICitizen : IIDable
    {
        string Name { get; }

        int Age { get; }
    }
}
