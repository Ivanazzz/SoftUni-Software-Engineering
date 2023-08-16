using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class Stack<T>
        : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;

        public Stack()
        {
            items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count++] = element;
        }

        public T Pop()
        {
            CheckIfStackIsEmpty();

            T element = items[Count - 1];
            Count--;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return element;
        }

        public T Peek()
        {
            CheckIfStackIsEmpty();

            return items[Count - 1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }

        public void Print()
        {
            Console.WriteLine(String.Join(' ', items));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            T[] copyArray = new T[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copyArray[i] = items[i];
            }

            items = copyArray;
        }

        private void Shrink()
        {
            T[] copyArray = new T[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copyArray[i] = items[i];
            }

            items = copyArray;
        }

        private void CheckIfStackIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
