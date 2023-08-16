namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly IList<T> data;

        public AddRemoveCollection()
        {
            data = new List<T>();
        }

        public int Add(T item)
        {
            data.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T itemToRemove = data.LastOrDefault();

            if (itemToRemove != null)
            {
                data.Remove(itemToRemove);
            }

            return itemToRemove;
        }
    }
}
