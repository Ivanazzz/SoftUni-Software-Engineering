using System;

namespace InchesToCentimeters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inch = double.Parse(Console.ReadLine());
            double centimeters = inch * 2.54;
            Console.WriteLine(centimeters);
        }
    }
}
