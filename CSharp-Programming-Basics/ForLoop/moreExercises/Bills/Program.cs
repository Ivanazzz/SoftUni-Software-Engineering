using System;

namespace Bills
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int monthsCount = int.Parse(Console.ReadLine());

            double electricityBill = 0;
            int waterBill = 0;
            int internetBill = 0;
            double otherBill = 0;

            for (int month = 1; month <= monthsCount; month++)
            {
                double otherBillPerMonth = 0;

                double electricityBillPerMonth = double.Parse(Console.ReadLine());

                electricityBill += electricityBillPerMonth;
                waterBill += 20;
                internetBill += 15;
                otherBillPerMonth = (electricityBillPerMonth + 20 + 15) + ((electricityBillPerMonth + 20 + 15) * 0.2);
                otherBill += otherBillPerMonth;
            }

            double averageSum = (electricityBill + waterBill + internetBill + otherBill) / monthsCount;

            Console.WriteLine($"Electricity: {electricityBill:F2} lv");
            Console.WriteLine($"Water: {waterBill:F2} lv");
            Console.WriteLine($"Internet: {internetBill:F2} lv");
            Console.WriteLine($"Other: {otherBill:F2} lv");
            Console.WriteLine($"Average: {averageSum:F2} lv");
        }
    }
}
