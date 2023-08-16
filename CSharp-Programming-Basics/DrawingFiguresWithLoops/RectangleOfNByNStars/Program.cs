using System;

namespace RectangleOfNByNStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string s = new string('*', n);
                Console.WriteLine(s);
            }
        }
    }
}
