using System;

namespace Lab3
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
            return "Прямоугольник: ширина = " + Width + ", высота = " + Height + ", площадь = " + GetArea();
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
