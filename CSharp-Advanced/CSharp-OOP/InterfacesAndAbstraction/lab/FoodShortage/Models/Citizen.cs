namespace FoodShortage.Models
{
    using Contracts;

    public class Citizen : IBuyer
    {
        private Citizen()
        {
            Food = 0;
        }

        public Citizen(string name, int age, string id, string birthdate)
            : this()
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public void BuyFood()
            => Food += 10;
    }
}
