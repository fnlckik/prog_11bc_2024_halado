using System;

namespace Viz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Beolvasas
            Console.Write("Hőmérséklet: ");
            double homerseklet = Convert.ToDouble(Console.ReadLine());

            // MO1
            //if (homerseklet <= 0)
            //{
            //    Console.WriteLine("Szilárd!");
            //}
            //else if (homerseklet <= 100)
            //{
            //    Console.WriteLine("Folyadék!");
            //}
            //else
            //{
            //    Console.WriteLine("Gáz!");
            //}

            // MO2
            //if (homerseklet <= 0) Console.WriteLine("Szilárd!");
            //else if (homerseklet <= 100) Console.WriteLine("Folyadék!");
            //else Console.WriteLine("Gáz!");

            // MO3 - 2. Feldolgozas
            string halmazallapot;
            if (homerseklet <= 0) halmazallapot = "Szilárd!";
            else if (homerseklet <= 100) halmazallapot = "Folyadék!";
            else halmazallapot = "Gáz!";

            // MO4 - ternary
            //string halmazallapot;
            //halmazallapot = (homerseklet <= 0) ? "Szilárd!" :
            //                (homerseklet <= 100) ? "Folyadék!" :
            //                "Gáz!";

            // Kiiras
            Console.WriteLine(halmazallapot);

            Console.ReadKey();
        }
    }
}
