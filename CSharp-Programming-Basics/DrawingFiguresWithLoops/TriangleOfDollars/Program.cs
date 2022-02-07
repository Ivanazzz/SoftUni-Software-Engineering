using System;
using System.Linq;

namespace TriangleOfDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string s = string.Concat(Enumerable.Repeat("$ ", i));
                Console.WriteLine(s);
            }
        }
    }
}
