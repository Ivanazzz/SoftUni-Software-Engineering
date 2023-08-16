using System;

namespace ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzlesCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int teddyBearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());
            int toysCount = puzzlesCount + dollsCount + teddyBearsCount + minionsCount + trucksCount;

            double puzzlesPrice = puzzlesCount * 2.60;
            int dollsPrice = dollsCount * 3;
            double teddyBearPrice = teddyBearsCount * 4.10;
            double minionsPrice = minionsCount * 8.20;
            int trucksPrice = trucksCount * 2;
            double toysPriceSum = puzzlesPrice + dollsPrice + teddyBearPrice + minionsPrice + trucksPrice;

            if (toysCount >= 50)
            {
                toysPriceSum -= toysPriceSum * 0.25;
            }

            double rentCost = toysPriceSum * 0.1;
            double totalIncome = toysPriceSum - rentCost;

            if (totalIncome >= tripPrice)
            {
                Console.WriteLine($"Yes! {(totalIncome - tripPrice):F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(Math.Abs(tripPrice - totalIncome)):F2} lv needed.");
            }
        }
    }
}
