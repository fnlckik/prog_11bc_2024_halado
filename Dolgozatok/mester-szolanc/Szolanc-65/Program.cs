using System;
using System.Collections.Generic;

namespace Szolanc_65
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> szavak = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string szo = Console.ReadLine();
                szavak.Add(szo);
            }

            string aktualis = KeresElso(szavak);
            Console.WriteLine(aktualis);

            int db = 1;
            while (db < n)
            {
                string kov = KeresKov(szavak, aktualis);
                db++;
                Console.WriteLine(kov);
                aktualis = kov;
            }
        }

        // Keresünk (kiválasztunk) egy szót, aminek az első betűje
        // az aktuális utolsó betűje.
        private static string KeresKov(List<string> szavak, string aktualis)
        {
            int i = 0;
            while (!(aktualis[aktualis.Length - 1] == szavak[i][0]))
            {
                i++;
            }
            return szavak[i];
        }

        // Keresünk (kiválasztunk) egy szót, aminek az első betűje
        // egyetlen másiknak sem az utolsó betűje.
        private static string KeresElso(List<string> szavak)
        {
            int i = 0;
            while (!ElsoSzoE(szavak, szavak[i])) // i < szavak.Count &&
            {
                i++;
            }
            return szavak[i];
        }

        // Optimista eldöntés:
        // Igaz-e minden szóra, hogy nem előzheti meg az aktuálisat?
        private static bool ElsoSzoE(List<string> szavak, string szo)
        {
            int i = 0;
            while (i < szavak.Count && !(szo[0] == szavak[i][szavak[i].Length - 1]))
            {
                i++;
            }
            return i >= szavak.Count;
        }
    }
}
