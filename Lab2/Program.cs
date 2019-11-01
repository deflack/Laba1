using System;

namespace Lab2
{
    abstract class Figure
    {
        public virtual double GetArea() 
        { 
            return 0;
        }
    }
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
    class Square : Rectangle, IPrint
    {
        public Square(double length) : base(length, length) {}
        public override string ToString()
        {
            return "Length = " + Width + ", area = " + GetArea();
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
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
    public static class Program
    {
        public static void Main()
        {
            
        }
    }
    interface IPrint
    {
        void Print();
    }
}