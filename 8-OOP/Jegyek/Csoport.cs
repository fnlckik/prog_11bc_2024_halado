using System;
using System.Collections.Generic;
using System.IO;

namespace Jegyek
{
    class Csoport
    {
        private List<Diak> diakok = new List<Diak>();

        // "Johnny", 14-19, 0.5
        // Cél: nevek.txt-ből random generáljunk neveket
        public Csoport(int n)
        {
            Random r = new Random();
            //List<string> nevek = Beolvas("nevek.txt");
            List<string> nevek = new List<string>(File.ReadAllLines("nevek.txt"));
            for (int i = 0; i < n; i++)
            {
                int kor = r.Next(14, 20);
                double hangulat = Math.Round(r.NextDouble(), 2);
                Diak d = new Diak("Johnny", kor, hangulat);
                diakok.Add(d);
            }
        }

        private List<string> Beolvas(string path)
        {
            List<string> eredmeny = new List<string>();
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string nev = sr.ReadLine();
                eredmeny.Add(nev);
            }
            return eredmeny;
        }

        // Johhny vagyok, 17 éves. Hangulatom: 53%.
        // Johnny vagyok, 17 éves. Hangulatom: 53%.
        // Johnny vagyok, 17 éves. Hangulatom: 53%.
        public override string ToString()
        {
            string s = "";
            foreach (Diak diak in this.diakok)
            {
                s += diak + $" Hangulatom: {diak.Hangulat}%.\n";
            }
            return s;
        }
    }
}
