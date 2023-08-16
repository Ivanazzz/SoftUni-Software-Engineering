using System;

namespace Diamond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var bristles = (n - 1) / 2;



            for (int i = 1; i <= (n - 1) / 2; i++)
            {
                Console.Write(new string('-', bristles));
                Console.Write("*");
                var mid = n - 2 * bristles - 2;
                if (mid >= 0)
                {
                    Console.Write(new string('-', mid));
                    Console.Write("*");
                }
                Console.WriteLine(new string('-', bristles));
                bristles--;
            }
            for (int i = n / 2; i < n; i++)
            {

                Console.Write(new string('-', bristles));
                Console.Write("*");
                var mid = n - 2 * bristles - 2;
                if (mid >= 0)
                {
                    Console.Write(new string('-', mid));
                    Console.Write("*");
                }
                Console.WriteLine(new string('-', bristles));
                bristles++;
            }
        }
    }
}
