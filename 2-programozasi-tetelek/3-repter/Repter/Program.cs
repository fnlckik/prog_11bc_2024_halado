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
            if (db != 0)
            {
                double atlag = osszeg / db;
                Console.WriteLine($"3. {atlag:.00}");
            }
            else
            {
                Console.WriteLine("3. Nincs 20 alatti tömeg!");
            }

            // F4 - Eldöntés (optimista)
            // Cáfolatot keresünk (a keresendő tagadását)
            i = 0;
            while (i < n && !(tomegek[i] <= 5))
            {
                i++;
            }
            if (i < n)
            {
                Console.WriteLine("4. Nem igaz!");
            }
            else
            {
                Console.WriteLine("4. Igaz!");
            }

            // F5 - Megszámolás
            db = 0;
            for (i = 0; i < n; i++)
            {
                if (nevek[i].Length > 10)
                {
                    db++;
                }
            }
            Console.WriteLine($"5. {db}");

            // F6 - Megszámolás
            db = 0;
            for (i = 0; i < n-1; i++)
            {
                if (tomegek[i] > tomegek[i+1])
                {
                    db++;
                }
            }
            Console.WriteLine($"6. {db}");

            // F7 - Megszámolás + Keresés (kiválasztás)
            i = 0;
            while (!(nevek[i] == "Farkas Dóra"))
            {
                i++;
            }
            double csomag = tomegek[i];
            db = 0;
            for (i = 0; i < n; i++)
            {
                if (tomegek[i] < csomag)
                {
                    db++;
                }
            }
            Console.WriteLine($"7. {db}");

            // F8 - Feltételes maximum kiválasztás
            // Alex: ???
            /*
            int maxi = 0;
            for (i = 0; i < n; i++)
            {
                if (tomegek[maxi] >= 10 && tomegek[maxi] <= 20)
                {
                    if (tomegek[i] > tomegek[maxi])
                    {
                        maxi = i;
                    }
                }
            }
            Console.WriteLine($"8. {nevek[maxi]}");
            */

            Console.ReadKey();
        }
    }
}
