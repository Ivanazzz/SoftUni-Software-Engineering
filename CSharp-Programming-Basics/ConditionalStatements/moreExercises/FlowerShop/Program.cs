using System;

namespace FlowerShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int magnoliaQuantity = int.Parse(Console.ReadLine());
			int hyacinthQuantity = int.Parse(Console.ReadLine());
			int roseQuantity = int.Parse(Console.ReadLine());
			int cactusQuantity = int.Parse(Console.ReadLine());
			double presentsPrice = double.Parse(Console.ReadLine());

			double magnoliaTotalPrice = magnoliaQuantity * 3.25;
			double hyacinthTotalPrice = hyacinthQuantity * 4.00;
			double roseTotalPrice = roseQuantity * 3.50;
			double cactusTotalPrice = cactusQuantity * 8.00;
			double totalSum = magnoliaTotalPrice + hyacinthTotalPrice + roseTotalPrice + cactusTotalPrice;
			double totalIncome = totalSum - (totalSum * 0.05);
			double difference = totalIncome - presentsPrice;

			if (difference >= 0)
			{
				Console.WriteLine($"She is left with {Math.Floor(difference)} leva.");
			}
			else
			{
				Console.WriteLine($"She will have to borrow {Math.Ceiling(Math.Abs(difference))} leva.");
			}
		}
    }
}
