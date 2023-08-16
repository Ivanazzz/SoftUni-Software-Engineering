using System;
using System.Linq;

namespace SquareOfStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string s = string.Concat(Enumerable.Repeat("* ", n));
                Console.WriteLine(s);
            }
        }
    }
}
