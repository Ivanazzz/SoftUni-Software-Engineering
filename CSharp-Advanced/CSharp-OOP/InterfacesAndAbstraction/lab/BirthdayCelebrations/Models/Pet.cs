namespace BirthdayCelebrations.Models
{
    using Contracts;

    public class Pet : IPet, IBirthdateable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
