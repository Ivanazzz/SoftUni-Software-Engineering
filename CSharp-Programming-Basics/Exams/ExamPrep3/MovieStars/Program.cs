using System;

namespace MovieStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            string name = Console.ReadLine();

            while (name != "ACTION")
            {
                if (name.Length - 1 >= 15)
                {
                    budget -= budget * 0.2;
                }
                else
                {
                    double salary = double.Parse(Console.ReadLine());
                    budget -= salary;
                }

                if (budget < 0)
                {
                    Console.WriteLine($"We need {Math.Abs(budget):F2} leva for our actors.");
                    return;
                }

                name = Console.ReadLine();
            }

            Console.WriteLine($"We are left with {budget:F2} leva.");
        }
    }
}
