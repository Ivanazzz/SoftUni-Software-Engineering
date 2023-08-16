namespace Shapes
{
    using System;
    using System.Linq;
    using System.Text;

    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get { return height; } private set { height = value; } }
        public double Width { get { return width; } private set { width = value; } }

        public override double CalculateArea()
            => Height * Width;

        public override double CalculatePerimeter()
            => (2 * Height) + (2 * Width);

        public override string Draw()
            => $"{base.Draw()} {this.GetType().Name}";
    }
}
