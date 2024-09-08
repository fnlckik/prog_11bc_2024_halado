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
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Terület: {a*b}");

            Console.ReadKey();
        }
    }
}
