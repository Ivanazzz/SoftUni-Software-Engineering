using System;

namespace Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string destination = Console.ReadLine();

                if (destination == "End")
                {
                    break;
                }

                double neededSum = double.Parse(Console.ReadLine());

                while (true)
                {
                    double money = double.Parse(Console.ReadLine());
                    neededSum -= money;

                    if (neededSum <= 0)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                }
            }
        }
    }
}
