namespace SpaceStation.Models.Bags
{
    using System.Collections.Generic;

    using Contracts;

    public class Backpack : IBag
    {
        private readonly List<string> items;

        public Backpack()
        {
            items = new List<string>();
        }

        public ICollection<string> Items => items;
    }
}
