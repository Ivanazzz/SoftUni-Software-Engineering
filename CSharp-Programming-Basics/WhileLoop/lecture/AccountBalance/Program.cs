using System;

namespace AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double totalMoney = 0;

            while (command != "NoMoreMoney")
            {
                double money = double.Parse(command);
                if (money < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    totalMoney += money;
                    Console.WriteLine($"Increase: {money:F2}");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Total: {totalMoney:F2}");
        }
    }
}
