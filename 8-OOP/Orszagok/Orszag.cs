
using System;
using System.Collections.Generic;

namespace Orszagok
{
    class Orszag
    {
        private string nev;
        private double nepesseg; // 9.730530 millió fő
        private int terulet;
        private bool eutagE;
        private HashSet<string> nyelvek;

        public Orszag(string nev, double nepesseg, int terulet, string nyelvek)
        {
            this.nev = nev;
            this.nepesseg = nepesseg / 1000000;
            this.terulet = terulet;
            this.eutagE = false;
            this.nyelvek = new HashSet<string>(nyelvek.Split());
        }

        //int.Parse((this.nepesseg* 1000000).ToString());
        private int Nepesseg { get => Convert.ToInt32(this.nepesseg * 1000000); }

        // this.eutagE = nyelvek.Contains("francia") && nyelvek.Contains("angol") && value;
        public bool EutagE
        {
            set
            {
                if (nyelvek.Contains("francia") && nyelvek.Contains("angol")) this.eutagE = value;
                else this.eutagE = false;
            }
        }

        //return $"{this.nev}: {this.nepesseg} fő " + (this.eutagE? "(EU)" : "");
        public override string ToString()
        {
            string eu = this.eutagE ? "(EU)" : "";
            return $"{this.nev}: {this.Nepesseg} fő {eu}";
        }
    }
}
