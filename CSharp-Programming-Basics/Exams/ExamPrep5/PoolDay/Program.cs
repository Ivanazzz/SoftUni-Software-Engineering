using System;

namespace PoolDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double entryFee = double.Parse(Console.ReadLine());
            double pricePerLounger = double.Parse(Console.ReadLine());
            double pricePerUmbrella = double.Parse(Console.ReadLine());

            double totalEntryFee = people * entryFee;
            double umbrellaTotalPrice = Math.Ceiling(people * 0.50) * pricePerUmbrella;
            double loungerTotalPrice = Math.Ceiling(people * 0.75) * pricePerLounger;
            double totalPrice = totalEntryFee + umbrellaTotalPrice + loungerTotalPrice;

            Console.WriteLine($"{totalPrice:F2} lv.");
        }
    }
}
