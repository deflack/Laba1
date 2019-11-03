using System;

namespace Lab3
{
    class Square : Rectangle, IPrint
    {
        public Square(double length) : base(length, length) { }
        public override string ToString()
        {
            if (Width != 0)
                return "Квадрат: длина = " + Width + ", площадь = " + GetArea();
            else
                return "0";
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
