using System;

namespace BeolvasKiir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Helló Világ!");

            // 1. Olvasd be a felhasználó vezeték és
            // keresztnevét és köszöntsd!
            /*
            string vnev, knev;

            Console.Write("Vezetéknév: ");
            vnev = Console.ReadLine();

            Console.Write("Keresztnév: ");
            knev = Console.ReadLine();

            Console.WriteLine("Szia " + vnev + " " + knev + "!");
            Console.WriteLine("Szia {0} {1}!", vnev, knev);
            Console.WriteLine($"Szia {vnev} {knev}!");
            */

            // 2. Téglalap terület két oldalból
            //double a = Convert.ToDouble(Console.ReadLine());
            //double b = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine($"Terület: {a*b}");

            // 3. Hányados
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Hányados: {Convert.ToDouble(a) / b}");
            Console.WriteLine($"Hányados: {(double)a / b}");
            Console.WriteLine($"Hányados: {1.0 * a / b:0.000}");
            Console.WriteLine($"Hányados: {1d * a / b:0 000.000}");

            Console.ReadKey();
        }
    }
}
