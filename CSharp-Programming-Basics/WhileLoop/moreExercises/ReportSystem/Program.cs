using System;

namespace ReportSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int neededSum = int.Parse(Console.ReadLine());

            int counter = 0;
            int cashMoney = 0;
            int moneyByCard = 0;
            int totalMoney = 0;
            int cashMoneyCounter = 0;
            int moneyByCardCount = 0;
            bool isValid = false;

            string command = Console.ReadLine();

            while (command != "End")
            {
                counter++;
                int price = int.Parse(command);

                if (counter % 2 != 0)
                {
                    if (price > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        totalMoney += price;
                        cashMoney += price;
                        cashMoneyCounter++;
                    }
                }
                else
                {
                    if (price < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        totalMoney += price;
                        moneyByCard += price;
                        moneyByCardCount++;
                    }
                }

                if (totalMoney >= neededSum)
                {
                    isValid = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (isValid)
            {
                Console.WriteLine($"Average CS: {(cashMoney * 1.00 / cashMoneyCounter):F2}");
                Console.WriteLine($"Average CC: {(moneyByCard * 1.00 / moneyByCardCount):F2}");
            }
            else
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
        }
    }
}
