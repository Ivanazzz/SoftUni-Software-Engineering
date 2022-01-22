using System;

namespace FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
			double chickenMenusPrice = 10.35;
			double fishMenusPrice = 12.40;
			double vegetarianMenusPrice = 8.15;

			int chickenMenusCount = int.Parse(Console.ReadLine());
			int fishMenusCount = int.Parse(Console.ReadLine());
			int vegetarianMenusCount = int.Parse(Console.ReadLine());

			double totalMenusPrice = (chickenMenusCount * chickenMenusPrice) + (fishMenusCount * fishMenusPrice) + (vegetarianMenusCount * vegetarianMenusPrice);
			double dessertPrice = totalMenusPrice * 0.2;
			double deliveryPrice = 2.50;
			double totalPrice = totalMenusPrice + dessertPrice + deliveryPrice;

			Console.WriteLine(totalPrice);
		}
    }
}
