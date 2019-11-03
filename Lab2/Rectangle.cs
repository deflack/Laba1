using System;

namespace Lab2
{
    class Rectangle : Figure, IPrint
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public override double GetArea()
        {
            return Width * Height;
        }
        public override string ToString()
        {
            return "Width = " + Width + ", height = " + Height + ", area = " + GetArea();
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
