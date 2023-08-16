using System;
using System.Linq;

namespace SquareFrame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i == 1 || i == n)
                {
                    string s = String.Concat(Enumerable.Repeat("- ", n - 2));
                    Console.WriteLine($"+ {s}+");
                }
                else
                {
                    string s = String.Concat(Enumerable.Repeat("- ", n - 2));
                    Console.WriteLine($"| {s}|");
                }
            }
        }
    }
}
