using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> stack = new Stack<T>();

        public Box()
        {
            this.stack = new Stack<T>();
        }

        public int Count { get => stack.Count; }

        public void Add(T element)
        {
            this.stack.Push(element);
        }

        public T Remove()
        {
            T element = this.stack.Pop();

            return element;
        }
    }
}
