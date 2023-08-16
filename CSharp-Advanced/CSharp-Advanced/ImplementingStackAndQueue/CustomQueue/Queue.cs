using System;
using System.Collections.Generic;
using System.Text;

namespace CustomQueue
{
    public class Queue
    {
        private const int InitialCount = 4;
        private int[] items;

        public Queue()
        {
            items = new int[InitialCount];
        }

        public int Count { get; private set; }

        public void Enqueue(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count++] = element;
        }

        public int Dequeue()
        {
            CheckIfQueueIsEmpty();

            int element = items[0];
            Count--;

            for (int i = 0; i < Count; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count] = 0;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return element;
        }

        public int Peek()
        {
            CheckIfQueueIsEmpty();

            return items[0];
        }

        public void Clear()
        {
            items = new int[InitialCount];
            Count = 0;
        }

        public void ForEach(Action<int> action)
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

        private void Resize()
        {
            int[] copyArray = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copyArray[i] = items[i];
            }

            items = copyArray;
        }

        private void Shrink()
        {
            int[] copyArray = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copyArray[i] = items[i];
            }

            items = copyArray;
        }

        private void CheckIfQueueIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
