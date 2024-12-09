using System;

namespace Szamelmelet
{
    internal class Program
    {
        static bool PrimE(int p)
        {
            if (p < 2) return false;
            if (p == 2) return true;
            int i = 2;
            while (i < Math.Sqrt(p) && p % i != 0)
            {
                i++;
            }
            return p % i != 0; // Prím: kiléptünk, mert nincs osztó
        }

        static int[] Primszamok(int[] x, ref int db)
        {
            int[] primek = new int[100];
            for (int i = 0; i < x.Length; i++)
            {
                if (PrimE(x[i]))
                {
                    primek[db] = x[i];
                    db++;
                }
            }
            return primek;
        }

        static void Kiir(int[] primek, int db)
        {
            Console.Write("Prímszámok: ");
            for (int i = 0; i < db; i++)
            {
                Console.Write(primek[i] + " ");
            }
        }

        static int OsztokSzama(int n)
        {
            int db = 1; // önmaga osztója biztosan
            for (int i = 1; i <= n/2; i++)
            {
                if (n % i == 0)
                {
                    db++;
                }
            }
            return db;
        }

        static int SokOsztos(int[] a)
        {
            int i = 0;
            while (i < a.Length && !(OsztokSzama(a[i]) >= 20))
            {
                i++;
            }
            if (i < a.Length)
            {
                return a[i];
            }
            else
            {
                return -1;
            }
        }

        static void Main(string[] args)
        {
            // Prímszámok kiválogatása - Kiválogatás + Eldöntés
            int[] szamok = { 7, 23, 6, 42, 73, 2, 3, 9, 1, 5 };
            int[] primek = new int[100];
            int db = 0;
            primek = Primszamok(szamok, ref db);
            Kiir(primek, db);
            Console.WriteLine();

            // Sok osztós szám - Keresés + Megszámolás
            int[] szamok2 = { 6, 1001, 48, 360, 75 };
            //Console.WriteLine(OsztokSzama(360));
            Console.WriteLine("Sok osztós: " + SokOsztos(szamok2));
        }
    }
}
