namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class MyList<T> : IMyList<T>
    {
        private readonly List<T> data;

        public MyList()
        {
            data = new List<T>();
        }

        public int Used 
            => data.Count;

        public int Add(T item)
        {
            data.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T itemToRemove = data.FirstOrDefault();

            if (itemToRemove != null)
            {
                data.Remove(itemToRemove);
            }

            return itemToRemove;
        }
    }
}
