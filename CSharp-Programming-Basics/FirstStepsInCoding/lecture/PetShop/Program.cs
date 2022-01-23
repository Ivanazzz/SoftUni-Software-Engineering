using System;

namespace PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dogsFoodPackages = int.Parse(Console.ReadLine());
            int catsFoodPackages = int.Parse(Console.ReadLine());
            double dogsFoodPrice = dogsFoodPackages * 2.50;
            int catsFoodPrice = catsFoodPackages * 4;
            double totalPrice = dogsFoodPrice + catsFoodPrice;
            Console.WriteLine($"{totalPrice} lv.");
        }
    }
}
