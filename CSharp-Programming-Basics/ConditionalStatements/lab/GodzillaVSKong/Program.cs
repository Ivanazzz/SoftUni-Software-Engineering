using System;

namespace GodzillaVSKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double filmsBudget = double.Parse(Console.ReadLine());
            int extrasCount = int.Parse(Console.ReadLine());
            double clothesPricePerExtra = double.Parse(Console.ReadLine());

            double decorPrice = filmsBudget * 0.1;
            double clothesTotalPrice = extrasCount * clothesPricePerExtra;

            if (extrasCount > 150)
            {
                clothesTotalPrice -= clothesTotalPrice * 0.1;
            }

            double totalCost = decorPrice + clothesTotalPrice;

            if (totalCost <= filmsBudget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(filmsBudget - totalCost):F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(totalCost - filmsBudget):F2} leva more.");
            }
        }
    }
}
