using System;

namespace BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int basketballAnnualFee = int.Parse(Console.ReadLine());
            double basketballShoesPrice = basketballAnnualFee - (basketballAnnualFee * 0.4);
            double basketballClothesPrice = basketballShoesPrice - (basketballShoesPrice * 0.2);
            double basketballBallPrice = basketballClothesPrice / 4.0;
            double basketballAccessoriesPrice = basketballBallPrice / 5.0;

            double totalPrice = basketballAnnualFee + basketballShoesPrice + basketballClothesPrice + basketballBallPrice + basketballAccessoriesPrice;
            Console.WriteLine(totalPrice);
        }
    }
}
