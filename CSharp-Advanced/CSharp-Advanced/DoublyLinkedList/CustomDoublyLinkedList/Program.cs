using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList linkedList = new DoublyLinkedList();

            linkedList.AddFirst(new Node(1));
            linkedList.AddFirst(new Node(2));
            linkedList.AddFirst(new Node(3));

            linkedList.AddLast(new Node(1));
            linkedList.AddLast(new Node(2));
            linkedList.AddLast(new Node(3));
            Console.WriteLine($"Nodes count in doubly linked list: {linkedList.Count}");

            linkedList.RemoveFirst();
            linkedList.RemoveFirst();

            linkedList.RemoveLast();
            Console.WriteLine($"Nodes count in doubly linked list: {linkedList.Count}");

            linkedList.ForEach(node =>
            {
                Console.WriteLine(node.Value);
            });

            linkedList.Reverse();
            Console.WriteLine("Reversed doubly linked list");

            linkedList.ForEach(node =>
            {
                Console.WriteLine(node.Value);
            });

            linkedList.Reverse();
            Console.WriteLine("Reversed doubly linked list");

            linkedList.ForEach(node =>
            {
                Console.WriteLine(node.Value);
            });

        }
    }
}
