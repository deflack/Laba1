using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    abstract class Figure : IComparable<Figure>
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
