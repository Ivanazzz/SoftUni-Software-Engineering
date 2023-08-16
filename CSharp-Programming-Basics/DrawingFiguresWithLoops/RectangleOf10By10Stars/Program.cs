using System;

namespace RectangleOf10By10Stars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                string s = new string('*', 10);
                Console.WriteLine(s);
            }
        }
    }
}
