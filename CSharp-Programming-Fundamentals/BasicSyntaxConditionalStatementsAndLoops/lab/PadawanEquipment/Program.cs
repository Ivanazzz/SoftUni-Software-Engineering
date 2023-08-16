using System;

namespace PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double pricePerLightsaber = double.Parse(Console.ReadLine());
            double pricePerRobe = double.Parse(Console.ReadLine());
            double pricePerBelt = double.Parse(Console.ReadLine());

            double totalNumberOfLightsabers = Math.Ceiling(studentsCount * 1.10);
            double totalNumberOfBelts = studentsCount - Math.Floor(studentsCount / 6.0);

            double finalPriceOfLightsabers = totalNumberOfLightsabers * pricePerLightsaber;
            double finalPriceOfRobes = studentsCount * pricePerRobe;
            double finalPriceOfBelts = totalNumberOfBelts * pricePerBelt;

            double totalPrice = finalPriceOfLightsabers + finalPriceOfRobes + finalPriceOfBelts;
            
            if(money >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {(totalPrice - money):f2}lv more.");
            }
        }
    }
}
