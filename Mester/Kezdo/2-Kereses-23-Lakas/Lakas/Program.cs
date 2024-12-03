using System;

namespace Lakas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Deklaráció
            int n, meretKorlat, arKorlat;
            int[] arak = new int[100];
            int[] meretek = new int[100];

            // Beolvasás
            string[] darabok = Console.ReadLine().Split(' '); // { "4", "30", "10" }
            n = Convert.ToInt32(darabok[0]); // 4
            meretKorlat = Convert.ToInt32(darabok[1]); // 30
            arKorlat = Convert.ToInt32(darabok[2]); // 10

            int i;
            for (i = 0; i < n; i++)
            {
                string[] adatok = Console.ReadLine().Split(' ');
                arak[i] = Convert.ToInt32(adatok[0]);
                meretek[i] = Convert.ToInt32(adatok[1]);
            }

            // Feldolgozás - Keresés
            i = 0;
            while (i < n && !(arak[i] > arKorlat && meretek[i] > meretKorlat))
            {
                i++;
            }

            // Kiírás
            if (i < n) // megtaláltuk a keresett elemet
            {
                Console.WriteLine(i+1);
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
