using System;
using System.Collections.Generic;
using System.IO;

namespace konyvek
{
    // Konténer osztály: egy másik osztály elemeiből tartalmaz egy kollekciót
    internal class Kiadas
    {
        private List<Konyv> konyvek;

        public Kiadas(string fajlnev)
        {
            konyvek = new List<Konyv>();
            StreamReader sr = new StreamReader(fajlnev);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                bool magyarE = sor[2] == "ma";
                Konyv konyv = new Konyv(int.Parse(sor[0]), int.Parse(sor[1]), magyarE, sor[3], int.Parse(sor[4]));
                konyvek.Add(konyv);
            }
            sr.Close();
        }

        public List<Konyv> Konyvek { get => new List<Konyv>(konyvek); }

        public int KiadasokSzama(string nev)
        {
            int db = 0;
            foreach (Konyv konyv in this.konyvek)
            {
                if (konyv.SzerzoE(nev))
                {
                    db++;
                }
            }
            return db;
        }

        // Egyszerre kéne 2 (több) értéket visszaadni: maxe, db
        // A tuple adattagjai readonly típusúak (nem módosíthatók)
        public Tuple<int, int> MaxPeldany()
        {
            int maxe = -1; // Mi a max?
            int db = 0; // Hányszor van max érték?
            foreach (Konyv konyv in this.konyvek)
            {
                if (konyv.Peldany > maxe)
                {
                    maxe = konyv.Peldany;
                    db = 1;
                }
                else if (konyv.Peldany == maxe)
                {
                    db++;
                }
            }
            return new Tuple<int, int>(maxe, db);
        }
    }
}
