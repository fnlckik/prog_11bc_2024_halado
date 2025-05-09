using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jegyek
{
    class Csoport
    {
        private Random r = new Random();
        private List<Diak> diakok = new List<Diak>();

        #region Konstruktor
        // "Johnny", 14-19, 0.5
        // Cél: nevek.txt-ből random generáljunk neveket
        public Csoport(int n)
        {
            //List<string> nevek = Beolvas("nevek.txt");
            List<string> nevek = new List<string>(File.ReadAllLines("nevek.txt"));
            for (int i = 0; i < n; i++)
            {
                string nev = nevek[this.r.Next(nevek.Count)];
                int kor = this.r.Next(14, 20);
                double hangulat = Math.Round(this.r.NextDouble(), 2);
                Diak d = new Diak(nev, kor, hangulat);
                diakok.Add(d);
            }
        }
        #endregion

        #region Metódusok
        private List<string> Beolvas(string path)
        {
            List<string> eredmeny = new List<string>();
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string nev = sr.ReadLine();
                eredmeny.Add(nev);
            }
            sr.Close();
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

        // 30% valószínűséggel elégtelen
        // <0.3 => 1, különben 2-5
        public void DolgozatIras()
        {
            foreach (Diak diak in this.diakok)
            {
                double hianyzas = r.NextDouble(); // 20% valószínűséggel hiányzik valaki
                if (hianyzas > 0.2)
                {
                    double szazalek = r.NextDouble();
                    int jegy = 1;
                    if (szazalek >= 0.3)
                    {
                        jegy = r.Next(2, 6);
                    }
                    diak.JegyetKap(jegy);
                }
            }
        }

        public void KiirNaplo()
        {
            foreach (Diak diak in this.diakok)
            {
                Console.Write(diak.Nev + ": ");
                foreach (int jegy in diak.Jegyek)
                {
                    Console.Write(jegy + " ");
                }
                int top = Console.CursorTop;
                Console.SetCursorPosition(25, top);
                Console.WriteLine(diak.Atlag());
            }
        }

        public void LezarJegyek()
        {
            Console.WriteLine();
            foreach (Diak diak in this.diakok)
            {
                Console.Write(diak.Nev + ": ");
                // Ha nincs 3 jegye vagy 1.8 alatti az átlag, akkor pótvizsga!
                if (diak.Jegyek.Count < 3 || double.Parse(diak.Atlag()) < 1.8)
                {
                    Console.WriteLine("Pótvizsga!");
                }
                else
                {
                    Console.WriteLine(Math.Round(double.Parse(diak.Atlag())));
                }
            }
        }

        #endregion
    }
}
