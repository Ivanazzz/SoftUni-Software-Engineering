using System;

namespace Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
			double nylonSqrtMeterPrice = 1.50;
			double paintPricePerLiter = 14.50;
			int paintThinnerPricePerLiter = 5;

			int nylonNeededSqrtMeters = int.Parse(Console.ReadLine());
			int paintNeededLiters = int.Parse(Console.ReadLine());
			int paintThinnerNeededLiters = int.Parse(Console.ReadLine());
			int hoursNeededForRepainting = int.Parse(Console.ReadLine());

			double paintAddedLiters = paintNeededLiters * 0.1;
			int nylonAddedSqrtMeters = 2;
			double bagsPrice = 0.40;

			double totalSuppliesCost = ((nylonNeededSqrtMeters + nylonAddedSqrtMeters) * nylonSqrtMeterPrice) + ((paintNeededLiters + paintAddedLiters) * paintPricePerLiter)
				+ (paintThinnerNeededLiters * paintThinnerPricePerLiter) + bagsPrice;

			double totalCraftsmanCost = hoursNeededForRepainting * (totalSuppliesCost * 0.3);

			double totalRepaintingCost = totalSuppliesCost + totalCraftsmanCost;
			Console.WriteLine(totalRepaintingCost);
		}
    }
}
