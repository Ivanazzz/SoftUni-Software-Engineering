using System;

namespace MobileOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string contractTerm = Console.ReadLine();
            string contractType = Console.ReadLine();
            string mobileNet = Console.ReadLine();
            int paymentMonths = int.Parse(Console.ReadLine());

            double price = 0;

            switch (contractTerm)
            {
                case "one":
                    switch (contractType)
                    {
                        case "Small":
                            price = 9.98;
                            break;
                        case "Middle":
                            price = 18.99;
                            break;
                        case "Large":
                            price = 25.98;
                            break;
                        case "ExtraLarge":
                            price = 35.99;
                            break;
                    }
                    break;
                case "two":
                    switch (contractType)
                    {
                        case "Small":
                            price = 8.58;
                            break;
                        case "Middle":
                            price = 17.09;
                            break;
                        case "Large":
                            price = 23.59;
                            break;
                        case "ExtraLarge":
                            price = 31.79;
                            break;
                    }
                    break;
            }
            if (mobileNet == "yes")
            {
                if (price <= 10)
                {
                    price += 5.50;
                }
                else if (price <= 30)
                {
                    price += 4.35;
                }
                else
                {
                    price += 3.85;
                }
            }

            double totalPrice = paymentMonths * price;

            if (contractTerm == "two")
            {
                totalPrice -= totalPrice * 0.0375;
            }

            Console.WriteLine($"{totalPrice:F2} lv.");
        }
    }
}
