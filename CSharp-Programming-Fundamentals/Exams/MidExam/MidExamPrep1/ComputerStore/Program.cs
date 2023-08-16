using System;

namespace ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalPriceWithoutTaxes = 0;
            double totalTaxes = 0;
            string customerType = "";

            while(true)
            {
                string command = Console.ReadLine();
                if(command == "special" || command == "regular")
                {
                    customerType = command;
                    break;
                }

                double priceWithoutTax = double.Parse(command);
                if(priceWithoutTax < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                double currentTax = priceWithoutTax * 0.2;
                totalPriceWithoutTaxes += priceWithoutTax;
                totalTaxes += currentTax;
            }

            double totalPrice = totalPriceWithoutTaxes + totalTaxes;
            if(customerType == "special")
            {
                totalPrice -= totalPrice * 0.1;
            }

            if(totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                Environment.Exit(0);
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {totalPriceWithoutTaxes:f2}$");
            Console.WriteLine($"Taxes: {totalTaxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalPrice:f2}$");
        }
    }
}
