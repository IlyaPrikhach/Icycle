using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Icycle
{
    class Program
    {
        static double f(double x)
        {
            return Math.Acos(x) - Math.Pow(1 - Math.Pow(x, 2) * 0.3, 1 / 2);           
        }
        static double fПроизводная(double x)
        {
            return 0.3 * x / Math.Sqrt(1 - 0.3 * Math.Pow(x,2)) - 1 / Math.Sqrt(1 - Math.Pow(x, 2));
        }
        static double fВтораяПроизводная(double x)
        {
            return 0.09 * Math.Pow(x,2) / Math.Pow(1-0.3 * Math.Pow(x,2), 3 / 2)-x / Math.Pow(1 - Math.Pow(x,2), 3/2) + 0.3 / Math.Sqrt(1 - 0.3 * Math.Pow(x,2));
        }
        static double начальноеПриближение(double a, double b)
        {
            return f(a) * fВтораяПроизводная(a) > 0 ? a : b;
        }
        static void вводДанных(out double a, out double b, out double точность)
        {
            try
            {
                Console.WriteLine("Введите область [a,b] и точность");
                string[] аргументы = Console.ReadLine().Replace('.', ',').Split(' ');
                a = double.Parse(аргументы[0]);
                b = double.Parse(аргументы[1]);
                точность = double.Parse(аргументы[2]);
            }
            catch
            {
                Console.WriteLine("неверные данные");
                вводДанных(out a, out b, out точность);
            }
        }
        static void решениеЗадачи(double a, double b, double точность)
        {
            double приближение = начальноеПриближение(a, b);
            while (Math.Abs(f(приближение)) > точность)
            {
                приближение = приближение - f(приближение) / fПроизводная(приближение);
            }
            Console.Write(приближение);
        }

        static void Main(string[] args)
        {
            double a, b, точность;
            вводДанных(out a, out b, out точность);
            решениеЗадачи(a, b, точность);
        }
    }
}
