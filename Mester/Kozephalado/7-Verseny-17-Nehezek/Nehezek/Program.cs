using System;
using System.Collections.Generic;

namespace Nehezek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> minek = new List<int>();
            List<List<int>> versenyek = new List<List<int>>();
            // versenyek[i][j]: i. versenyen indult j. tanuló pontszáma
            Beolvas(minek, versenyek);
            List<int> nehezek = Nehezek(minek, versenyek);
            Kiir(nehezek);
        }

        static void Kiir(List<int> nehezek)
        {
            Console.Write(nehezek.Count + " ");
            foreach (int sorszam in nehezek)
            {
                Console.Write(sorszam + " ");
            }
            Console.WriteLine();
        }

        static List<int> Nehezek(List<int> minek, List<List<int>> versenyek)
        {
            List<int> nehezek = new List<int>();
            for (int i = 0; i < versenyek.Count; i++)
            {
                int db = 0;
                foreach (int pont in versenyek[i])
                {
                    if (pont < minek[i])
                    {
                        db++;
                    }
                }
                if (db >= (double)versenyek[i].Count / 2)
                {
                    nehezek.Add(i + 1);
                }
            }
            return nehezek;
        }

        static void Beolvas(List<int> minek, List<List<int>> versenyek)
        {
            string[] sor = Console.ReadLine().Split(' ');
            int n = int.Parse(sor[1]); // versenyek száma

            // Minimum ponthatárok beolvasása
            sor = Console.ReadLine().Split(' ');
            foreach (string pont in sor)
            {
                minek.Add(int.Parse(pont));
            }

            // Pontok beolvasása
            for (int i = 0; i < n; i++)
            {
                sor = Console.ReadLine().Split(' ');
                List<int> pontok = new List<int>();
                for (int j = 2; j < sor.Length; j += 2)
                {
                    pontok.Add(int.Parse(sor[j]));
                }
                versenyek.Add(pontok);
            }
        }
    }
}
