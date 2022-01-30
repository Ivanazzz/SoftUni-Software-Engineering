using System;

namespace Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actorsName = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int jurysCount = int.Parse(Console.ReadLine());
            bool isValid = false;

            for (int jury = 1; jury <= jurysCount; jury++)
            {
                string jurysName = Console.ReadLine();
                double pointsFromJury = double.Parse(Console.ReadLine());
                int counter = 0;

                for (int i = 0; i < jurysName.Length; i++)
                {
                    counter++;
                }

                points += (counter * pointsFromJury) / 2;

                if (points >= 1250.5)
                {
                    isValid = true;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine($"Congratulations, {actorsName} got a nominee for leading role with {points:F1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {actorsName} you need {(1250.5 - points):F1} more!");
            }
        }
    }
}
