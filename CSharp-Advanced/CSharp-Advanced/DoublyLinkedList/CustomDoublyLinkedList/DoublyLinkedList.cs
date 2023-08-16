using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }
        private bool IsReversed = false;

        public void AddFirst(Node node)
        {
            Count++;

            if (!CheckIfFirstElementInList(node))
            {
                Node previousHead = this.Head;
                this.Head = node;
                this.Head.Next = previousHead;
                previousHead.Previous = this.Head;
            }
        }

        public void AddLast(Node node)
        {
            Count++;

            if (!CheckIfFirstElementInList(node))
            {
                Node previousTail = this.Tail;
                this.Tail = node;
                this.Tail.Previous = previousTail;
                previousTail.Next = this.Tail;
            }
        }

        public Node RemoveFirst()
        {
            if (this.Head == null)
            {
                return null;
            }

            Count--;

            Node previousHead = this.Head;
            Node nextHead = this.Head.Next;

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

        public Node RemoveLast()
        {
            if (this.Tail == null)
            {
                return null;
            }

            Count--;

            Node previousTail = this.Tail;
            Node nextTail = this.Tail.Previous;

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

        public void ForEach(Action<Node> action)
        {
            Node node = this.Head;
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

        public Node[] ToArray()
        {
            Node[] array = new Node[this.Count];
            Node node = this.Head;
            int index = 0;

            while (node != null)
            {
                array[index++] = node;
                node = node.Next;
            }

            return array;
        }

        private bool CheckIfFirstElementInList(Node node)
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
