using System;

namespace Repter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nevek = { "Kovács Anna", "Nagy Péter", "Szabó Éva", "Tóth Márk",
                               "Kiss Júlia", "Molnár Tamás", "Farkas Dóra", "Horváth István",
                               "Varga Krisztina", "Simon Balázs", "Lukács Zoltán", "Takács Emese" };
            double[] tomegek = { 22.3, 12, 7.5, 18.44, 35, 28, 14.12, 8, 16.9, 5.8, 30, 24 };

            int n = tomegek.Length;
            int i;

            // F1 - Minimum kiválasztás
            int mini = 0;
            for (i = 1; i < n; i++)
            {
                if (tomegek[i] < tomegek[mini])
                {
                    mini = i;
                }
            }
            Console.WriteLine($"1. {nevek[mini]}");

            // F2 - Keresés
            i = 0;
            while (i < n && !(tomegek[i] > 30))
            {
                i++;
            }
            if (i < n)
            {
                Console.WriteLine($"2. {nevek[i]}");
            }
            else
            {
                Console.WriteLine("2. Nincs ilyen!");
            }

            // F3 - Feltételes átlag
            // Összegzés + megszámolás
            double osszeg = 0;
            int db = 0;
            for (i = 0; i < n; i++)
            {
                if (tomegek[i] < 20)
                {
                    osszeg += tomegek[i];
                    db++;
                }
            }
            double atlag = osszeg / db;
            Console.WriteLine($"3. {atlag:.00}");


            Console.ReadKey();
        }
    }
}
