using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }

        public int Count(T itemToCompare)
        {
            int count = 0;
            foreach (T item in Items)
            {
                if (item.CompareTo(itemToCompare) == 1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
