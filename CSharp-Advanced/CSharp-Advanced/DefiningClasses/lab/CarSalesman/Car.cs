using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    internal class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }

        public void PrintCarInfo(Car car)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine($"  {car.Engine.Model}:");
            Console.WriteLine($"    Power: {car.Engine.Power}");

            string displacement = car.Engine.Displacement.HasValue ?
                $"    Displacement: {car.Engine.Displacement}" :
                "    Displacement: n/a";
            Console.WriteLine(displacement);

            string efficieny = car.Engine.Efficiency != null ?
                $"    Efficiency: {car.Engine.Efficiency}" :
                "    Efficiency: n/a";
            Console.WriteLine(efficieny);

            string weight = car.Weight.HasValue ?
                $"  Weight: {car.Weight}" :
                "  Weight: n/a";
            Console.WriteLine(weight);

            string color = car.Color != null ?
                $"  Color: {car.Color}" :
                "  Color: n/a";
            Console.WriteLine(color);
        }
    }
}
