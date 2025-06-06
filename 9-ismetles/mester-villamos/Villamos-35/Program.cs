using System;
using System.Collections.Generic;

namespace Villamos_35
{
    public class Allomas
    {
        public int tavolsag;
        public int erkezes;
        public int indulas;

        public Allomas(int tavolsag, int erkezes, int indulas)
        {
            this.tavolsag = tavolsag;
            this.erkezes = erkezes;
            this.indulas = indulas;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Allomas> allomasok = new List<Allomas>();

            // Beolvasas
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] sor = Console.ReadLine().Split(' ');
                Allomas a = new Allomas(int.Parse(sor[0]), int.Parse(sor[1]), int.Parse(sor[2]));
                allomasok.Add(a);
            }

            // Feldolgozas
            List<int> indexek = new List<int> { 0 }; // indexek.Add(0)
            int elozo = allomasok[0].erkezes; // Mennyi idő alatt értük el az előző állomást?
            for (int i = 1; i < allomasok.Count; i++)
            {
                int akt = allomasok[i].erkezes - allomasok[i - 1].indulas;
                if (akt > elozo)
                {
                    indexek.Add(i);
                }
                elozo = akt;
            }

            // Kiiras
            Console.Write(indexek.Count + " ");
            foreach (int index in indexek)
            {
                Console.Write($"{index + 1} ");
            }
        }
    }
}
