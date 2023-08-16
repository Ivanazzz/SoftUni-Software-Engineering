using System;
using System.Linq;

namespace Sunglasses
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
                    string topStars = new string('*', (((5 * n) - n) / 2));
                    string topSpaces = new string(' ', n);
                    Console.WriteLine($"{topStars}{topSpaces}{topStars}");
                }
                else
                {
                    if (n % 2 != 0)
                    {
                        if (i == Math.Ceiling(n * 1.00 / 2))
                        {
                            string forNose = new string('|', n);
                            string glass = string.Concat(Enumerable.Repeat("/", (((5 * n) - n - 4) / 2)));
                            Console.WriteLine($"*{glass}*{forNose}*{glass}*");
                        }
                        else
                        {
                            string forNose = new string(' ', n);
                            string glass = string.Concat(Enumerable.Repeat("/", (((5 * n) - n - 4) / 2)));
                            Console.WriteLine($"*{glass}*{forNose}*{glass}*");
                        }
                    }
                    else
                    {
                        if (i == (n / 2))
                        {
                            string forNose = new string('|', n);
                            string glass = string.Concat(Enumerable.Repeat("/", (((5 * n) - n - 4) / 2)));
                            Console.WriteLine($"*{glass}*{forNose}*{glass}*");
                        }
                        else
                        {
                            string forNose = new string(' ', n);
                            string glass = string.Concat(Enumerable.Repeat("/", (((5 * n) - n - 4) / 2)));
                            Console.WriteLine($"*{glass}*{forNose}*{glass}*");
                        }
                    }
                }
            }
        }
    }
}
