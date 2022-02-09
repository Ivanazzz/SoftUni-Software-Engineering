using System;

namespace PaintingEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eggsSize = Console.ReadLine();
            string eggsColor = Console.ReadLine();
            int eggsBatchCount = int.Parse(Console.ReadLine());

            int price = 0;

            switch (eggsSize)
            {
                case "Large":
                    switch (eggsColor)
                    {
                        case "Red":
                            price = 16;
                            break;
                        case "Green":
                            price = 12;
                            break;
                        case "Yellow":
                            price = 9;
                            break;
                    }
                    break;
                case "Medium":
                    switch (eggsColor)
                    {
                        case "Red":
                            price = 13;
                            break;
                        case "Green":
                            price = 9;
                            break;
                        case "Yellow":
                            price = 7;
                            break;
                    }
                    break;
                case "Small":
                    switch (eggsColor)
                    {
                        case "Red":
                            price = 9;
                            break;
                        case "Green":
                            price = 8;
                            break;
                        case "Yellow":
                            price = 5;
                            break;
                    }
                    break;
            }

            int currentPrice = eggsBatchCount * price;
            double totalPrice = currentPrice - (currentPrice * 0.35);

            Console.WriteLine($"{totalPrice:F2} leva.");
        }
    }
}
