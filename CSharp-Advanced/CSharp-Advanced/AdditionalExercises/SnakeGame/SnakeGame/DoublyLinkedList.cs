using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class DoublyLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; set; }
        private bool IsReversed = false;

        public void AddFirst(Node<T> node)
        {
            Count++;

            if (!CheckIfFirstElementInList(node))
            {
                Node<T> previousHead = this.Head;
                this.Head = node;
                this.Head.Next = previousHead;
                previousHead.Previous = this.Head;
            }
        }

        public void AddLast(Node<T> node)
        {
            Count++;

            if (!CheckIfFirstElementInList(node))
            {
                Node<T> previousTail = this.Tail;
                this.Tail = node;
                this.Tail.Previous = previousTail;
                previousTail.Next = this.Tail;
            }
        }

        public Node<T> RemoveFirst()
        {
            if (this.Head == null)
            {
                return null;
            }

            Count--;

            Node<T> previousHead = this.Head;
            Node<T> nextHead = this.Head.Next;

            if (nextHead != null)
            {
                nextHead.Previous = null;
            }
            else
            {
                this.Tail = null;
            }

            this.Head = nextHead;

            return previousHead;
        }

        public Node<T> RemoveLast()
        {
            if (this.Tail == null)
            {
                return null;
            }

            Count--;

            Node<T> previousTail = this.Tail;
            Node<T> nextTail = this.Tail.Previous;

            if (nextTail != null)
            {
                nextTail.Next = null;
            }
            else
            {
                this.Head = null;
            }

            this.Tail = nextTail;

            return previousTail;
        }

        public void ForEach(Action<Node<T>> action)
        {
            Node<T> node = this.Head;
            if (IsReversed)
            {
                node = Tail;
            }

            while (node != null)
            {
                action(node);
                if (IsReversed)
                {
                    node = node.Previous;
                }
                else
                {
                    node = node.Next;
                }
            }
        }

        public void Reverse()
        {
            IsReversed = !IsReversed;
        }

        public Node<T>[] ToArray()
        {
            Node<T>[] array = new Node<T>[this.Count];
            Node<T> node = this.Head;
            int index = 0;

            while (node != null)
            {
                array[index++] = node;
                node = node.Next;
            }

            return array;
        }

        private bool CheckIfFirstElementInList(Node<T> node)
        {
            if (Head == null)
            {
                this.Head = node;
                this.Tail = node;

                return true;
            }

            return false;
        }
    }
}
