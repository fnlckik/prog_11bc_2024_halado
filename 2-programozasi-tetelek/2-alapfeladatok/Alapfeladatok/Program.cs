using System;

namespace Alapfeladatok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] x = { 5, 7, 2, 2, 9, -1, 4, -3, 9, 3, 2, 1 };
            int n = x.Length;

            // F4 - Eldöntés
            int i = 0;
            while (i < n && !(x[i] < 0))
            {
                i++;
            }
            if (i < n) // Benne vagyok még a tömbben.
            {
                Console.WriteLine("4. Van negatív elem!");
            }
            else
            {
                Console.WriteLine("4. Nincs negatív elem!");
            }

            // F5 - Kiválasztás
            /*
            i = 0;
            bool megvan = x[0] == 9;
            while (!megvan)
            {
                i++;
                megvan = x[i] == 9;
            }
            */
            i = 0;
            while (!(x[i] == 9))
            {
                i++;
            }
            Console.WriteLine($"5. Az első 9-es helye: {i+1}");

            // F6 - Keresés = Eldöntés + Kiválasztás
            // x[i] % 2 != 0
            // x[i] % 2 == 1
            i = 0;
            while (i < n && !(x[i] % 2 == 0))
            {
                i++;
            }
            if (i < n)
            {
                Console.WriteLine($"6. Van páros: {i+1}. elem, értéke: {x[i]}");
            }
            else
            {
                Console.WriteLine("6. Nincs páros!");
            }

            // F1 - Megszámolás
            int db = 0;
            for (i = 0; i < n; i++)
            {
                if (x[i] % 2 == 0)
                {
                    db++;
                }
            }
            Console.WriteLine($"1. {db} db páros van");

            // F2 - Összegzés
            // x[i] % 2 != 0 NEM UGYANAZ, MINT x[i] % 2 == 1
            int osszeg = 0;
            for (i = 0; i < n; i++)
            {
                if (x[i] % 2 != 0)
                {
                    osszeg += x[i];
                }
            }
            Console.WriteLine("2. Páratlanok összege: " + osszeg);

            // F3 - Maximum kiválasztás
            int maxi = 0; // maximális értékű elem indexe
            for (i = 0; i < n; i++)
            {
                if (x[i] > x[maxi])
                {
                    maxi = i;
                }
            }
            Console.WriteLine("3. a) Maximális értékű elem (első)");
            Console.WriteLine($"      helye: {maxi+1}");
            Console.WriteLine($"      értéke: {x[maxi]}");

            maxi = 0; // maximális értékű elem indexe
            for (i = 0; i < n; i++)
            {
                if (x[i] >= x[maxi])
                {
                    maxi = i;
                }
            }
            Console.WriteLine("3. b) Maximális értékű elem (utolsó)");
            Console.WriteLine($"      helye: {maxi + 1}");
            Console.WriteLine($"      értéke: {x[maxi]}");

            int mini = 0; // minimális értékű elem indexe
            for (i = 0; i < n; i++)
            {
                if (x[i] < x[mini])
                {
                    mini = i;
                }
            }
            Console.WriteLine("3. c) Minimális értékű elem (első)");
            Console.WriteLine($"      helye: {mini + 1}");
            Console.WriteLine($"      értéke: {x[mini]}");

            Console.ReadKey();
        }
    }
}
