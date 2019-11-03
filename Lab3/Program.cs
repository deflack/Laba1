using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
    public static class Program
    {
        public static void Main()
        {
            Rectangle r = new Rectangle(11, 13);
            Square s = new Square(11);
            Circle c = new Circle(11.13);
            ArrayList list = new ArrayList();
            list.Add(r);
            list.Add(s);
            list.Add(c);
            Console.WriteLine("Содержимое площади элементов коллекции ArrayList:");
            foreach(Figure f in list)
                Console.WriteLine(f.GetArea());
            List<Figure> listG = new List<Figure>();
            foreach(Figure f in list)
                listG.Add(f);
            listG.Sort();
            Console.WriteLine("Содержимое коллекции List<Figure>:");
            foreach (Figure f in listG)
                Console.WriteLine(f.ToString());
            Matrix<Figure> m = new Matrix<Figure>(1, 2, 3, new Square(0));
            m[0, 0, 0] = r;
            m[0, 1, 0] = new Rectangle(29, 11);
            m[0, 0, 1] = s;
            m[0, 1, 1] = new Square(29);
            m[0, 0, 2] = c;
            m[0, 1, 2] = new Circle(29.11);
            Console.WriteLine(m);
            SimpleStack<Figure> stack = new SimpleStack<Figure>();
            stack.Add(m[0, 0, 0]);
            stack.Pop();
            stack.Add(s);
            stack.Add(c);
        }
    }
}