using System;

namespace YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sqrtMeters = double.Parse(Console.ReadLine());
            double metersPrice = sqrtMeters * 7.61;
            double discount = metersPrice * 0.18;
            double totalPrice = metersPrice - discount;
            Console.WriteLine($"The final price is: {totalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
