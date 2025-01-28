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
            Kiir("Halmaz elemei: ", halmaz);

            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine();

            HashSet<string> zrinyi = new HashSet<string> { "Bence", "Réka", "Máté", "Pisti", "Johanna", "Kata" };
            HashSet<string> oktv = new HashSet<string> { "Máté", "Zalán", "Csaba", "Kata", "Bence" };
            Kiir("Zrínyi résztvevők: ", zrinyi);
            Kiir("OKTV résztvevők: ", oktv);
            Kiir("Zrínyi ÉS OKTV résztvevők: ", Metszet(zrinyi, oktv));
            Kiir("Zrínyi VAGY OKTV résztvevők: ", Unio(zrinyi, oktv));
            Kiir("Zrínyin indult, OKTV-n nem: ", Kulonbseg(zrinyi, oktv));

            HashSet<string> bitfarago = new HashSet<string> { "Máté", "Csaba", "Zalán" };
            Console.WriteLine("Részhalmaza(bitfarago, zrinyi)? " + ReszhalmazaE(bitfarago, zrinyi)); // false
            Console.WriteLine("Részhalmaza(bitfarago, oktv)? " + ReszhalmazaE(bitfarago, oktv)); // true
        }

        // Részhalmaza-e h1 halmaz h2-nek?
        // Igaz-e, hogy h1 minden eleme h2-nek is eleme?
        static bool ReszhalmazaE(HashSet<string> h1, HashSet<string> h2)
        {
            foreach (string elem in h1)
            {
                if (!h2.Contains(elem))
                {
                    return false;
                }
            }
            return true;
        }

        static HashSet<string> Kulonbseg2(HashSet<string> h1, HashSet<string> h2)
        {
            HashSet<string> kulonbseg = new HashSet<string>(h1);
            foreach (string elem in h1)
            {
                if (h2.Contains(elem))
                {
                    kulonbseg.Remove(elem);
                }
            }
            return kulonbseg;
        }

        // Elemei h1-nek, de nem elemei h2-nek.
        static HashSet<string> Kulonbseg(HashSet<string> h1, HashSet<string> h2)
        {
            HashSet<string> kulonbseg = new HashSet<string>();
            foreach (string elem in h1)
            {
                if (!h2.Contains(elem))
                {
                    kulonbseg.Add(elem);
                }
            }
            return kulonbseg;
        }

        static HashSet<string> Unio(HashSet<string> h1, HashSet<string> h2)
        {
            HashSet<string> unio = new HashSet<string>(h1);
            foreach (string elem in h2)
            {
                unio.Add(elem);
            }
            return unio;
        }

        // Metszet tétel
        static HashSet<string> Metszet(HashSet<string> h1, HashSet<string> h2)
        {
            HashSet<string> metszet = new HashSet<string>();
            foreach (string elem in h1)
            {
                if (h2.Contains(elem))
                {
                    metszet.Add(elem);
                }
            }
            return metszet;
        }

        static void Kiir<T>(string szoveg, HashSet<T> halmaz)
        {
            Console.Write(szoveg);
            Console.Write("{ ");
            int db = 0;
            foreach (T elem in halmaz)
            {
                db++;
                string sep = db == halmaz.Count ? "" : ", ";
                Console.Write(elem + sep);
            }
            Console.WriteLine(" }");
        }
    }
}
