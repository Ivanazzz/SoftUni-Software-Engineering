using System;
using System.Linq;

namespace RhombusOfStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int y = n;

            for (int i = 1; i <= n; i++)
            {
                string s = string.Concat(Enumerable.Repeat(" ", n - i));
                string star = string.Concat(Enumerable.Repeat("* ", i));
                Console.WriteLine($"{s}{star}");
            }

            for (int i = 1; i <= n; i++)
            {
                y--;
                string s = string.Concat(Enumerable.Repeat(" ", n - (n - i)));
                string star = string.Concat(Enumerable.Repeat("* ", y));
                Console.WriteLine($"{s}{star}");
            }
        }
    }
}
