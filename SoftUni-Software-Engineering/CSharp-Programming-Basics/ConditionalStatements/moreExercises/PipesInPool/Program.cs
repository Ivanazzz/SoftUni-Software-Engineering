using System;

namespace PipesInPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int poolsVolumeInLiters = int.Parse(Console.ReadLine());
            int firstPipesDebitPerHour = int.Parse(Console.ReadLine());
            int secondPipesDebitPerHour = int.Parse(Console.ReadLine());
            double manMissingHours = double.Parse(Console.ReadLine());

            double firstPipesDebitTotal = firstPipesDebitPerHour * manMissingHours;
            double secondPipesDebitTotal = secondPipesDebitPerHour * manMissingHours;
            double totalLiters = firstPipesDebitTotal + secondPipesDebitTotal;
            double totalLitersPercentage = totalLiters / poolsVolumeInLiters * 100;

            if (totalLiters <= poolsVolumeInLiters)
            {
                double firstPipesDebitTotalPercentage = firstPipesDebitTotal / totalLiters * 100;
                double secondPipesDebitTotalPercentage = secondPipesDebitTotal / totalLiters * 100;
                Console.WriteLine($"The pool is {totalLitersPercentage:F2}% full. Pipe 1: {firstPipesDebitTotalPercentage:F2}%. Pipe 2: {secondPipesDebitTotalPercentage:F2}%.");
            }
            else
            {
                double litersDifference = totalLiters - poolsVolumeInLiters;
                Console.WriteLine($"For {manMissingHours} hours the pool overflows with {litersDifference:F2} liters.");
            }
        }
    }
}
