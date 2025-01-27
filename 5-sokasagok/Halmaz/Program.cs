using System;
using System.Collections.Generic;

namespace Halmaz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Halmaz: elemei egyediek, sorrend nincs => nem indexelhető
            HashSet<int> halmaz = new HashSet<int> { 5, 2, 9, 2, 2, 5, 7 }; // 5 2 9 7
            Console.WriteLine("Halmaz elemszáma: " + halmaz.Count);

            // Ilyet nem lehet!
            //Console.WriteLine("1. elem: " + halmaz[0]);

            Console.WriteLine("Eleme-e a 2 szám? " + halmaz.Contains(2));

            halmaz.Add(13); // 5 2 9 7 13
            halmaz.Remove(7); // 5 2 9 13
            halmaz.Add(13);
            halmaz.Remove(7);
            Console.Write("Halmaz elemei: ");
            Kiir(halmaz);

            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine();

            HashSet<string> zrinyi = new HashSet<string> { "Bence", "Réka", "Máté", "Pisti", "Johanna", "Kata" };
            HashSet<string> oktv = new HashSet<string> { "Máté", "Zalán", "Csaba", "Kata", "Bence" };
        }

        static void Kiir(HashSet<int> halmaz)
        {
            foreach (int elem in halmaz)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }
    }
}
