using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class List
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public List()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int i]
        {   
            get
            {
                isInRange(i);

                return items[i];
            }
            set 
            {
                isInRange(i);

                items[i] = value; 
            }
        }

        public void Add(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count++] = element;
        }

        public int RemoveAt(int index)
        {
            isInRange(index);

            int element = Shift(index);

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return element;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= Count
                || secondIndex < 0 || secondIndex >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            int tempElement = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = tempElement;
        }

        public void Print()
        {
            Console.WriteLine(string.Join(' ', items));
        }

        private void Resize()
        {
            int[] tempArray = new int[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                tempArray[i] = items[i];
            }

            items = tempArray;
        }

        private void Shrink()
        {
            int[] tempArray = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                tempArray[i] = items[i];
            }

            items = tempArray;
        }

        private int Shift(int index)
        {
            int element = items[index];

            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }

            Count--;
            return element;
        }

        private void isInRange(int i)
        {
            if (i < 0 || i >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
