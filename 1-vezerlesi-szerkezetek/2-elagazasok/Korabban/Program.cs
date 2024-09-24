using System;

namespace Korabban
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ora1, ora2, perc1, perc2;
            Console.Write("1. óra: ");
            ora1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("1. perc: ");
            perc1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("2. óra: ");
            ora2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("2. perc: ");
            perc2 = Convert.ToInt32(Console.ReadLine());

            int ido1 = ora1 * 60 + perc1;
            int ido2 = ora2 * 60 + perc2;

            Console.Write("A korábbi időpont: ");
            if (ido1 < ido2)
            {
                Console.WriteLine($"{ora1:00}:{perc1:00}");
            }
            else
            {
                Console.WriteLine($"{ora2:00}:{perc2:00}");
            }

            Console.ReadKey();
        }
    }
}
