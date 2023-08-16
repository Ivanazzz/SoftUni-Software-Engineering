using System;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyForTrip = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int daysCounter = 0;
            int counter = 0;
            bool isValid = true;

            while (true)
            {
                string command = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                daysCounter++;

                if (command == "spend")
                {
                    counter++;
                    if (money > availableMoney)
                    {
                        availableMoney = 0;
                    }
                    else
                    {
                        availableMoney -= money;
                    }

                    if (counter == 5)
                    {
                        isValid = false;
                        break;
                    }
                }
                else if (command == "save")
                {
                    counter = 0;
                    availableMoney += money;
                    if (availableMoney >= moneyForTrip)
                    {
                        break;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCounter);
            }
        }
    }
}
