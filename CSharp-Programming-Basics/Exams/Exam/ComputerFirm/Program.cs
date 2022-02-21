using System;

namespace ComputerFirm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int computersCount = int.Parse(Console.ReadLine());
            double totalSales = 0;
            double averageRating = 0;

            for (int computer = 1; computer <= computersCount; computer++)
            {
                double sales = 0;
                int number = int.Parse(Console.ReadLine());
                int rating = number % 10;
                int possibleSales = number / 10;
                averageRating += rating;

                if (rating == 3)
                {
                    sales = possibleSales * 0.5;
                }
                else if (rating == 4)
                {
                    sales = possibleSales * 0.7;
                }
                else if (rating == 5)
                {
                    sales = possibleSales * 0.85;
                }
                else if (rating == 6)
                {
                    sales = possibleSales;
                }

                totalSales += sales;
            }

            Console.WriteLine($"{totalSales:F2}");
            Console.WriteLine($"{(averageRating / computersCount):F2}");
        }
    }
}
