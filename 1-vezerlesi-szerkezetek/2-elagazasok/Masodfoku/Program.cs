using System;

namespace Masodfoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;

            Console.Write("a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("c: ");
            c = Convert.ToInt32(Console.ReadLine());

            int d = b * b - 4 * a * c;

            if (d > 0)
            {
                Console.WriteLine("2 db megoldás");
            }
            else if (d < 0)
            {
                Console.WriteLine("Nincs valós megoldás");
            }
            else
            {
                Console.WriteLine("1 db megoldás");
            }

            Console.ReadKey();
        }
    }
}
