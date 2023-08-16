using System;

namespace CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentAge = int.Parse(Console.ReadLine());
            double washingMacinePrice = double.Parse(Console.ReadLine());
            int pricePerToy = int.Parse(Console.ReadLine());

            int birthdaysMoney = 0;
            int toysCount = 0;
            int birthdaysMoneyCounter = 0;

            for (int age = 1; age <= currentAge; age++)
            {
                if (age % 2 == 0)
                {
                    birthdaysMoneyCounter++;
                    birthdaysMoney += (birthdaysMoneyCounter * 10) - 1;
                }
                else
                {
                    toysCount++;
                }
            }

            int toysTotalPrice = toysCount * pricePerToy;
            double totalMoney = toysTotalPrice + birthdaysMoney;
            double diff = totalMoney - washingMacinePrice;

            if (diff >= 0)
            {
                Console.WriteLine($"Yes! {diff:F2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(diff):F2}");
            }
            
        }
    }
}
