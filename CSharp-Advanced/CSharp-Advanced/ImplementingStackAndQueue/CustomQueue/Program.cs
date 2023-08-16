using System;

namespace CustomQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);

            queue.Print();

            Console.WriteLine(queue.Peek());

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            queue.Print();

            queue.Dequeue();

            queue.Print();

            queue.Clear();

            Console.WriteLine();

            queue.Enqueue(11);
            queue.Enqueue(12);
            queue.Enqueue(13);

            queue.ForEach(Console.WriteLine);
        }
    }
}
