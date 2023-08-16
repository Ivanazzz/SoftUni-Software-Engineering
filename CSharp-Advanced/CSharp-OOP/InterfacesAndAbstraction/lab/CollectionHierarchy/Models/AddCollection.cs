namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class AddCollection<T> : IAddCollection<T>
    {
        private readonly ICollection<T> data;

        public AddCollection()
        {
            data = new List<T>();
        }

        public int Add(T item)
        {
            data.Add(item);

            return data.Count - 1;
        }
    }
}
