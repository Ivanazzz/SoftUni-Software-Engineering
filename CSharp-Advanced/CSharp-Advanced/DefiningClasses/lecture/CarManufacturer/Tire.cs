using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        int year;
        double pressure;

        public int Year { get { return this.year; } set { this.year = value; } }
        public double Pressure { get { return this.pressure; } set { this.pressure = value; } }
    }
}
