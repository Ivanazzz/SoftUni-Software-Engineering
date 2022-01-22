using System;

namespace SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
			double pensPackagePrice = 5.80;
			double markersPackagePrice = 7.20;
			double whiteboardCleanerPricePerLiter = 1.20;

			int pensPackagesAmount = int.Parse(Console.ReadLine());
			int markersPackagesAmount = int.Parse(Console.ReadLine());
			int whiteboardCleanerLiters = int.Parse(Console.ReadLine());
			int discountPercentage = int.Parse(Console.ReadLine());

			double totalPensPackagesPrice = pensPackagePrice * pensPackagesAmount;
			double totalMarkersPackagesPrice = markersPackagePrice * markersPackagesAmount;
			double totalWhiteboardCleanerPrice = whiteboardCleanerPricePerLiter * whiteboardCleanerLiters;
			double totalPrice = totalPensPackagesPrice + totalMarkersPackagesPrice + totalWhiteboardCleanerPrice;
			double totalPricePlusDiscount = totalPrice - (totalPrice * discountPercentage / 100);

			Console.WriteLine(totalPricePlusDiscount);
		}
    }
}
