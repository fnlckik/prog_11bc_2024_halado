using System;
using System.Collections.Generic;
using System.IO;

namespace konyvek
{
    public class Statisztika
    {
        public int mk, mp, kk, kp;

        public Statisztika(int mk, int mp, int kk, int kp)
        {
            this.mk = mk;
            this.mp = mp;
            this.kk = kk;
            this.kp = kp;
        }
    }

    // Mj.: 13. osztály backend MVC kódszervezés
    // Hogyan kommunikál egymással a másik két osztály? (controller)
    // Konténer osztály: egy másik osztály elemeiből tartalmaz egy kollekciót
    internal class Kiadas
    {
        private List<Konyv> konyvek;
        private Dictionary<int, Statisztika> statisztikak;

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
            Osszegzes();
        }

        public List<Konyv> Konyvek { get => new List<Konyv>(konyvek); }

        private void Osszegzes()
        {
            statisztikak = new Dictionary<int, Statisztika>();
            foreach (Konyv konyv in this.konyvek)
            {
                if (!statisztikak.ContainsKey(konyv.Ev))
                {
                    if (konyv.MagyarE)
                    {
                        statisztikak.Add(konyv.Ev, new Statisztika(1, konyv.Peldany, 0, 0));
                    }
                    else
                    {
                        statisztikak.Add(konyv.Ev, new Statisztika(0, 0, 1, konyv.Peldany));
                    }
                }
                else
                {
                    Statisztika stat = statisztikak[konyv.Ev];
                    if (konyv.MagyarE)
                    {
                        stat.mk++;
                        stat.mp += konyv.Peldany;
                    }
                    else
                    {
                        stat.kk++;
                        stat.kp += konyv.Peldany;
                    }
                }
            }
        }

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

        // küszöbérték
        public Konyv KulfoldiNepszeru(int k)
        {
            int i = 0;
            while (!konyvek[i].KulfoldiNepszeruE(k))
            {
                i++;
            }
            return konyvek[i];
        }

        private Dictionary<string, int> KiadasokSzamolasa()
        {
            // Először hány példányban adták ki a könyvet?
            Dictionary<string, int> elsoPeldanyok = new Dictionary<string, int>();
            Dictionary<string, int> darabok = new Dictionary<string, int>();

            foreach (Konyv konyv in konyvek)
            {
                if (elsoPeldanyok.ContainsKey(konyv.Leiras))
                {
                    if (konyv.Peldany > elsoPeldanyok[konyv.Leiras])
                    {
                        darabok[konyv.Leiras]++;
                    }
                }
                else
                {
                    elsoPeldanyok.Add(konyv.Leiras, konyv.Peldany);
                    darabok.Add(konyv.Leiras, 0);
                }
            }
            return darabok;
        }

        public HashSet<string> UjraKiadottak()
        {
            Dictionary<string, int> darabok = this.KiadasokSzamolasa();
            HashSet<string> leirasok = new HashSet<string>();
            foreach (string leiras in darabok.Keys)
            {
                if (darabok[leiras] >= 2)
                {
                    leirasok.Add(leiras);
                }
            }
            //foreach (KeyValuePair<string, int> elem in darabok) // Key, Value
            //{
            //    if (elem.Value >= 2)
            //    {
            //        leirasok.Add(elem.Key);
            //    }
            //}
            return leirasok;
        }
    }
}
