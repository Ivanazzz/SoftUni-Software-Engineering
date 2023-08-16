namespace Shapes
{
    using System;
    using System.Text;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get { return radius; } private set { radius = value; } }

        public override double CalculateArea()
            => Math.PI * Math.Pow(Radius, 2);

        public override double CalculatePerimeter()
            => 2 * Math.PI * Radius;

        public override string Draw()
            => $"{base.Draw()} {this.GetType().Name}";
    }
}
