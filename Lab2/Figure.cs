using System;

namespace Lab2
{
    public abstract class Figure : IComparable<Figure>
    {
        public virtual double GetArea()
        {
            return 0;
        }
        public int CompareTo(Figure f)
        {
            return this.GetArea().CompareTo(f.GetArea());
        }
    }
}
