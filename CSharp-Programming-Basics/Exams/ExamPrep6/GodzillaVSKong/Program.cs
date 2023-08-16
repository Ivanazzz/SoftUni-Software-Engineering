using System;

namespace GodzillaVSKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfExtras = int.Parse(Console.ReadLine());
            double clothesPricePerExtra = double.Parse(Console.ReadLine());

            double decor = budget * 0.1;
            double clothesTotalPrice = numberOfExtras * clothesPricePerExtra;

            if (numberOfExtras > 150)
            {
                clothesTotalPrice -= clothesTotalPrice * 0.1;
            }

            double totalPrice = decor + clothesTotalPrice;

            if (budget >= totalPrice)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(budget - totalPrice):F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(totalPrice - budget):F2} leva more.");
            }
        }
    }
}
