using System;

namespace SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string grade = Console.ReadLine();
            double currentSum = 0;
            double totalSum = 0;

            switch (roomType)
            {
                case "room for one person":
                    currentSum = (days - 1) * 18.00;
                    break;
                case "apartment":
                    currentSum = (days - 1) * 25.00; 
                    if (days > 15)
                    {
                        currentSum = currentSum - (currentSum * 0.5);
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        currentSum = currentSum - (currentSum * 0.35);
                    }
                    else
                    {
                        currentSum = currentSum - (currentSum * 0.3);
                    }
                    break;
                case "president apartment":
                    currentSum = (days - 1) * 35.00;
                    if (days > 15)
                    {
                        currentSum = currentSum - (currentSum * 0.2);
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        currentSum = currentSum - (currentSum * 0.15);
                    }
                    else
                    {
                        currentSum = currentSum - (currentSum * 0.1);
                    }
                    break;
            }

            switch (grade)
            {
                case "positive":
                    totalSum = currentSum + (currentSum * 0.25);
                    break;
                case "negative":
                    totalSum = currentSum - (currentSum * 0.1);
                    break;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
