using System;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double totalPrice = OrderTotalPrice(product, quantity);
            Console.WriteLine($"{totalPrice:f2}");
        }

        static double OrderTotalPrice(string product, int quantity)
        {
            double price = 0;

            switch (product)
            {
                case "coffee":
                    price = 1.50;
                    break;
                case "water":
                    price = 1.00;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2.00;
                    break;
            }

            double totalPrice = price * quantity;
            return totalPrice;
        }
    }
}
