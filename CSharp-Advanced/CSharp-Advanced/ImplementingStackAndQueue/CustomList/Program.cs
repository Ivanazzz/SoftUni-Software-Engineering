using System;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            Console.WriteLine(list.Contains(30));
            Console.WriteLine(list.Contains(2));

            list.Add(40);
            list.Add(50);

            list.Print();

            list.RemoveAt(1);
            list.Print();

            list.RemoveAt(2);
            list.Print();

            list.RemoveAt(0);
            list.Print();

            list.Swap(0, 1);
            list.Print();

            list[0] = 10;
            list.Print();

            Console.WriteLine(list[7]);
        }
    }
}
