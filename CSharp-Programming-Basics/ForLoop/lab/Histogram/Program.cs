using System;

namespace Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    count1 += 1;
                }
                else if (number >= 200 && number < 400)
                {
                    count2 += 1;
                }
                else if (number >= 400 && number < 600)
                {
                    count3 += 1;
                }
                else if (number >= 600 && number < 800)
                {
                    count4 += 1;
                }
                else
                {
                    count5 += 1;
                }
            }

            double p1 = count1 * 1.00/ n * 100;
            double p2 = count2 * 1.00 / n * 100;
            double p3 = count3 * 1.00 / n * 100;
            double p4 = count4 * 1.00/ n * 100;
            double p5 = count5 * 1.00 / n * 100;

            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
            Console.WriteLine($"{p4:F2}%");
            Console.WriteLine($"{p5:F2}%");
        }
    }
}
