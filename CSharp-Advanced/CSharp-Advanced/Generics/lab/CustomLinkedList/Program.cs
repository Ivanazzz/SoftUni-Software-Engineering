using System;

namespace CustomLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddLast(4);

            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveLast());

            int[] arr = list.ToArray();

            list.ForEach(i => Console.WriteLine(i));

            Console.WriteLine(list.Count);


            DoublyLinkedList<string> listString = new DoublyLinkedList<string>();

            listString.AddFirst("dog");
            listString.AddFirst("cat");
            listString.AddFirst("frog");
            listString.AddLast("snake");

            listString.ForEach(i => Console.WriteLine(i));
        }
    }
}
