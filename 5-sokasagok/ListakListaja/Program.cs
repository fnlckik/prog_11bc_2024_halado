using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ListakListaja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> gyumolcsok = new List<string> { "szilva", "gránátalma", "cigánymeggy" };
            List<string> zoldsegek = new List<string> {  "padlizsan", "tök", "cukkini", "krumpli" };
            List<List<string>> etelek = new List<List<string>> { gyumolcsok, zoldsegek };

            // Írjuk ki a "cukkini" elemet!
            // etelek[i][j]: i. sor j. oszlopa
            Console.WriteLine("2. sor 3. eleme: " + etelek[1][2]);

            // Írjuk ki a gyümölcsöket!
            Console.Write("Lista elemei: ");
            Kiir(etelek[0]); // ez a gyümölcsök lista
            Console.WriteLine();

            // Írjuk ki az ételeket!
            Console.WriteLine("Ételek kiírása:");
            Kiir(etelek);
            Console.WriteLine();

            Console.WriteLine("Ételek kiírása:");
            Print(etelek);
            Console.WriteLine();

            // --------------------------------------------
            Console.Clear();

            List<List<int>> jegyek = new List<List<int>>();
            Beolvas(jegyek);

            Console.WriteLine("Jegyek: ");
            Print(jegyek);

            // 4,4 4,75 2 ...
            Atlagok(jegyek);
        }

        static void Atlagok(List<List<int>> naplo)
        {
            foreach (List<int> tanulo in naplo)
            {
                int s = 0;
                foreach (int jegy in tanulo)
                {
                    s += jegy;
                }
                double atlag = (double)s / tanulo.Count;
                //Console.Write($"{atlag:0.00} ");
                Console.Write(Math.Round(atlag, 2) + " ");
            }
            Console.WriteLine();
        }

        static void Beolvas(List<List<int>> jegyek)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] sor = Console.ReadLine().Split(' ');
                List<int> tanulo = new List<int>();
                foreach (string elem in sor)
                {
                    tanulo.Add(int.Parse(elem));
                }
                jegyek.Add(tanulo);
            }
        }

        static void Print<T>(List<List<T>> etelek)
        {
            for (int i = 0; i < etelek.Count; i++)
            {
                for (int j = 0; j < etelek[i].Count; j++)
                {
                    Console.Write(etelek[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Kiir(List<List<string>> etelek)
        {
            foreach (List<string> lista in etelek)
            {
                Kiir(lista);
                Console.WriteLine();
            }
        }

        static void Kiir(List<string> lista)
        {
            foreach (string elem in lista)
            {
                Console.Write(elem + " ");
            }
        }
    }
}
