using System;

namespace Lab2
{
    class Square : Rectangle, IPrint
    {
        public Square(double length) : base(length, length) { }
        public override string ToString()
        {
            return "Length = " + Width + ", area = " + GetArea();
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
