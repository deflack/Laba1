using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Гасанов Азар. ИУ5-32Б";
            double a, b, c;
            if (args.Length != 3)
            {
                Console.WriteLine("Коэффициенты не были заданы через параметры командой строки, либо введено не три параметра.");
                Console.WriteLine("Введите коэффициент A: ");
                ToDouble(Console.ReadLine(), out a, 'A');
                Console.WriteLine("Введите коэффициент B: ");
                ToDouble(Console.ReadLine(), out b, 'B');
                Console.WriteLine("Введите коэффициент C: ");
                ToDouble(Console.ReadLine(), out c, 'C');
            }
            else
            {
                ToDouble(args[0], out a, 'A');
                ToDouble(args[1], out b, 'B');
                ToDouble(args[2], out c, 'C');
            }
            Console.ForegroundColor = ConsoleColor.Green;
            double d, x1, x2, x3, x4;
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                        Console.WriteLine("Решений бесконечно");
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Нет решений");
                    }
                }
                else
                {
                    d = -4 * b * c;
                    if (d < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("D = " + d + ", нет решений");
                    }
                    else if (d == 0)
                        Console.WriteLine("D = 0, x = 0");
                    else
                    {
                        x1 = Math.Sqrt(d) / (2 * b);
                        x2 = -Math.Sqrt(d) / (2 * b);
                        Console.WriteLine("D = " + d + ", x1 = " + x1 + ", x2 = " + x2);
                    }
                }
            }
            else
            {
                d = b * b - 4 * a * c;
                if (d < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("D = " + d + ", нет решений.");
                }
                else if (d == 0)
                {
                    if (-b / (2 * a) < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("D = 0, нет решений.");
                    }
                    else if (-b / (2 * a) == 0)
                        Console.WriteLine("D = 0, x = 0");
                    else
                    {
                        x1 = Math.Sqrt(-b / (2 * a));
                        x2 = -Math.Sqrt(-b / (2 * a));
                        Console.WriteLine("D = 0, x1 = " + x1 + ", x2 = " + x2);
                    }
                }
                else
                {
                    double square1 = (-b + Math.Sqrt(d)) / (2 * a), square2 = (-b - Math.Sqrt(d)) / (2 * a);
                    if (square1 == 0)
                    {
                        Console.Write("D = " + d + ", x1 = 0");
                    }
                    else if (square1 > 0)
                    {
                        x1 = Math.Sqrt(square1);
                        x2 = -Math.Sqrt(square1);
                        Console.Write("D = " + d + ", x1 = " + x1 + ", x2 = " + x2);
                    }
                    if (square2 == 0)
                    {
                        if (square1 < 0)
                            Console.WriteLine("D = " + d + ", x1 = 0");
                        else if (square1 == 0)
                            Console.WriteLine(", x2 = 0");
                        else
                            Console.WriteLine(", x3 = 0");
                    }
                    else if (square2 > 0)
                    {
                        x3 = Math.Sqrt(square2);
                        x4 = -Math.Sqrt(square2);
                        if (square1 < 0)
                            Console.WriteLine("D = " + d + ", x1 = " + x3 + ", x2 = " + x4);
                        else if (square1 == 0)
                            Console.WriteLine(", x2 = " + x3 + ", x3 = " + x4);
                        else
                            Console.WriteLine(", x3 = " + x3 + ", x4 = " + x4);
                    }
                    else
                    {
                        if (square1 < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("D = " + d + ", нет решений");
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void ToDouble(string aS, out double a, char ch)
        {
            while (!Double.TryParse(aS, out a))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод коэффициента " + ch + ". Введите ещё раз:");
                Console.ForegroundColor = ConsoleColor.Gray;
                aS = Console.ReadLine();
            }
        }
    }
}