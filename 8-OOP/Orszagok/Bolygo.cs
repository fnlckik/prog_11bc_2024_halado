using System;
using System.Collections.Generic;
using System.IO;

namespace Orszagok
{
    class Bolygo
    {
        private readonly string nev;
        // readonly: csak konstruktorban (vagy setterben) lehet értéket adni neki
        private readonly Random r; 
        private readonly List<Orszag> orszagok = new List<Orszag>();
        
        public Bolygo(string nev, string fajlnev, Random r)
        {
            this.nev = nev;
            this.r = r;
            StreamReader sr = new StreamReader(fajlnev);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split('#');
                string nyelvek = sr.ReadLine(); // "angol német magyar"
                sr.ReadLine();

                string orszagnev = sor[0];
                double nepesseg = double.Parse(sor[1]);
                int terulet = int.Parse(sor[2]);

                Orszag orszag = new Orszag(orszagnev, nepesseg, terulet, nyelvek);
                orszag.EutagE = this.r.NextDouble() < 0.8;
                orszagok.Add(orszag);
            }
            sr.Close();
        }

        // Cél: a metódusok legyenek mellékhatás mentesek
        // Ne írassanak ki öncélúan semmit!
        public override string ToString()
        {
            string s = "";
            foreach (Orszag orszag in orszagok)
            {
                s += orszag + "\n";
            }
            return s;
        }

        // Előállítja, hogy milyen nyelvek vannak a bolygón
        private HashSet<string> KivalogatNyelvek()
        {
            HashSet<string> nyelvek = new HashSet<string>();
            foreach (Orszag orszag in this.orszagok)
            {
                foreach (string nyelv in orszag.Nyelvek)
                {
                    nyelvek.Add(nyelv);
                }
            }
            return nyelvek;
        }

        public void KiirNyelvek(string fajl)
        {
            // Kiválogatja a nyelveket (halmazba)
            HashSet<string> nyelvek = this.KivalogatNyelvek();
            // Kiírja a halmaz elemeit
            StreamWriter sw = new StreamWriter(fajl);
            foreach (string nyelv in nyelvek)
            {
                sw.WriteLine(nyelv);
            }
            sw.Close();
        }
    }
}
