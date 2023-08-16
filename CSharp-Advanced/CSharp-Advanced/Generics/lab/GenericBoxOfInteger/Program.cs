using System;

namespace GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < count; i++)
            {
                int item = int.Parse(Console.ReadLine());
                box.Items.Add(item);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
