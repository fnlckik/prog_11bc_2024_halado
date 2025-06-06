using System;

namespace konyvek
{
    // Milyen adatokat tárolunk? (model)
    internal class Konyv
    {
        private int ev;
        private int negyedev;
        private bool magyarE;
        private string leiras;
        private int peldany;

        public Konyv(int ev, int negyedev, bool magyarE, string leiras, int peldany)
        {
            this.ev = ev;
            this.negyedev = negyedev;
            this.magyarE = magyarE;
            this.leiras = leiras;
            this.peldany = peldany;
        }

        public int Peldany { get => peldany; }
        public string Leiras { get => leiras; }

        // "alma fa korte fa".Substring(8, 5)
        //public bool SzerzoE(string nev)
        //{
        //    int i = 0;
        //    while (i < this.leiras.Length - nev.Length && !(this.leiras.Substring(i, nev.Length) == nev))
        //    {
        //        i++;
        //    }
        //    return i < this.leiras.Length - nev.Length;
        //}

        public bool SzerzoE(string nev)
        {
            return this.leiras.Contains(nev);
        }

        public bool KulfoldiNepszeruE(int k)
        {
            return !this.magyarE && this.peldany >= k;
        }

        public override string ToString()
        {
            return $"{this.ev}/{this.negyedev}. {this.leiras}";
        }
    }
}
