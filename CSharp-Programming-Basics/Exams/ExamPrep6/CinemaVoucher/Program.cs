using System;

namespace CinemaVoucher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int valueOfTheVoucher = int.Parse(Console.ReadLine());
            int price = 0;
            int ticketsCount = 0;
            int productsCount = 0;

            string product = Console.ReadLine();

            while (product != "End")
            {
                if (product.Length > 8)
                {
                    price = (int)product[0] + (int)product[1];
                    if (price > valueOfTheVoucher)
                    {
                        Console.WriteLine(ticketsCount);
                        Console.WriteLine(productsCount);
                        return;
                    }
                    else
                    {
                        valueOfTheVoucher -= price;
                        ticketsCount++;
                    }
                }
                else
                {
                    price = (int)product[0];
                    if (price > valueOfTheVoucher)
                    {
                        Console.WriteLine(ticketsCount);
                        Console.WriteLine(productsCount);
                        return;
                    }
                    else
                    {
                        valueOfTheVoucher -= price;
                        productsCount++;
                    }
                }

                product = Console.ReadLine();
            }

            Console.WriteLine(ticketsCount);
            Console.WriteLine(productsCount);
        }
    }
}
