using System;

namespace BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int annualBasketballFee = int.Parse(Console.ReadLine());
            double sneakersPrice = annualBasketballFee - (annualBasketballFee * 0.4);
            double clothesPrice = sneakersPrice - (sneakersPrice * 0.2);
            double ballPrice = clothesPrice / 4;
            double accessoriesPrice = ballPrice / 5;
            double totalPrice = annualBasketballFee + sneakersPrice + clothesPrice + ballPrice + accessoriesPrice;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
