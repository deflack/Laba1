using System;

namespace Lab2
{
    class Circle : Figure, IPrint
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
        public override string ToString()
        {
            return "Radius = " + Radius + ", area = " + GetArea();
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
