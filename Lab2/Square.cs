using System;

namespace Lab2
{
    public class Square : Rectangle, IPrint
    {
        public Square(double length) : base(length, length) { }
        public override string ToString()
        {
            return "Квадрат: длина = " + Width + ", площадь = " + GetArea();
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
