using System;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            int rowsCount = int.Parse(Console.ReadLine());
            int columnsCount = int.Parse(Console.ReadLine());

            double ticketPrice = 0;

            switch (projectionType)
            {
                case "Premiere":
                    ticketPrice = 12.00;
                    break;
                case "Normal":
                    ticketPrice = 7.50;
                    break;
                case "Discount":
                    ticketPrice = 5.00;
                    break;
            }

            double totalIncome = rowsCount * columnsCount * ticketPrice;
            Console.WriteLine($"{totalIncome:f2} leva");
        }
    }
}
