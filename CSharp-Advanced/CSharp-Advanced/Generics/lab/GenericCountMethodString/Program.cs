using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < count; i++)
            {
                string item = Console.ReadLine();
                box.Items.Add(item);
            }

            string itemToCompare = Console.ReadLine();

            Console.WriteLine(box.Count(itemToCompare));
        }
    }
}
