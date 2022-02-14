using System;

namespace MovieProfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string moviesName = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double pricePerTicket = double.Parse(Console.ReadLine());
            int cinemasPercentage = int.Parse(Console.ReadLine());

            double incomePerDay = tickets * pricePerTicket;
            double totalIncome = days * incomePerDay;
            double moneyForTheCinema = totalIncome * cinemasPercentage / 100;
            double profit = totalIncome - moneyForTheCinema;

            Console.WriteLine($"The profit from the movie {moviesName} is {profit:F2} lv.");
        }
    }
}
