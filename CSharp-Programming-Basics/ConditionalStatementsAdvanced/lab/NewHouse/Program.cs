using System;

namespace NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerQuantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;

            switch (flowerType)
            {
                case "Roses":
                    price = flowerQuantity * 5.00;
                    if (flowerQuantity > 80)
                    {
                        price = price - (price * 0.1);
                    }
                    break;
                case "Dahlias":
                    price = flowerQuantity * 3.80;
                    if (flowerQuantity > 90)
                    {
                        price = price - (price * 0.15);
                    }
                    break;
                case "Tulips":
                    price = flowerQuantity * 2.80;
                    if (flowerQuantity > 80)
                    {
                        price = price - (price * 0.15);
                    }
                    break;
                case "Narcissus":
                    price = flowerQuantity * 3.00;
                    if (flowerQuantity < 120)
                    {
                        price = price + (price * 0.15);
                    }
                    break;
                case "Gladiolus":
                    price = flowerQuantity * 2.50;
                    if (flowerQuantity < 80)
                    {
                        price = price + (price * 0.2);
                    }
                    break;
            }

            double totalPrice = budget - price;
            if (totalPrice >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerQuantity} {flowerType} and {totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(totalPrice):f2} leva more.");
            }

        }
    }
}
