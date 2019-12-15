using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Lab6
{
    class Program
    {
        delegate int Del(int x, int y, int z);
        static void Main(string[] args)
        {
            Console.WriteLine(PlusX(1, 2, 3, Multiple));
            Console.WriteLine(PlusX(1, 2, 3, (x, y, z) => x + y - z));
            Console.WriteLine(MinusXFunc(1, 2, 3, Multiple));
            Console.WriteLine(MinusXFunc(1, 2, 3, (x, y, z) => x + y - z));

            Console.WriteLine("\nКонструкторы:");
            foreach (var x in typeof(Book).GetConstructors())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nСвойства:");
            foreach (var x in typeof(Book).GetProperties())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nМетоды:");
            foreach (var x in typeof(Book).GetMethods())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nСвойства, которым назначен атрибут:");
            foreach (var prop in typeof(Book).GetProperties())
            {
                if (prop.GetCustomAttributes().Count() != 0)
                    Console.WriteLine(prop);
            }
            typeof(Book).InvokeMember("Info", BindingFlags.InvokeMethod, null, new Book("Война и мир", 1274), null);
        }

        static int Multiple(int x, int y, int z)
        {
            return x * y * z;
        }
        static int PlusX(int x, int y, int z, Del del)
        {
            return x + del(x, y, z);
        }
        static int MinusXFunc(int x, int y, int z, Func<int,int,int,int> del)
        {
            return x - del(x, y, z);
        }

        
    }
}
