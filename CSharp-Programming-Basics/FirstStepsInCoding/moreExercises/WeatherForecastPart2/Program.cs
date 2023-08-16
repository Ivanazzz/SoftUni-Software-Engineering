using System;

namespace WeatherForecastPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());
            string weather = "unknown";

            if (degrees >= 5 && degrees < 12)
            {
                weather = "Cold";
            }
            else if (degrees >= 12 && degrees < 15)
            {
                weather = "Cool";
            }
            else if (degrees >= 15 && degrees <= 20)
            {
                weather = "Mild";
            }
            else if (degrees > 20 && degrees < 26)
            {
                weather = "Warm";
            }
            else if (degrees >= 26 && degrees < 35)
            {
                weather = "Hot";
            }

            Console.WriteLine(weather);
        }
    }
}
