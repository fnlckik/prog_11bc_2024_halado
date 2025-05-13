
using System.Collections.Generic;

namespace Filmek
{
    internal class Film
    {
        private string cim;
        private int ev;
        private string mufaj;
        private double imdb;
        private int nezok;

        //private HashSet<string> mufajok = new HashSet<string> { "akcio", "fantasy", "kaland", "horror" };

        public Film(string cim, int ev, string mufaj, double imdb, int nezok)
        {
            this.cim = cim;
            this.ev = ev;
            this.mufaj = mufaj;
            this.imdb = imdb;
            this.nezok = nezok;
        }

        public Film(string s)
        {
            string[] sor = s.Split(';');
            new Film(sor[0], int.Parse(sor[1]), sor[2], double.Parse(sor[3]), int.Parse(sor[4]));
        }

        public string Cim { get => this.cim; }

        public string Ev
        { 
            get
            {
                if (this.ev < 2019) return $"{this.ev} BC";
                else return $"{this.ev} AC";
            }
        }

        public string Mufaj
        {
            set
            {
                HashSet<string> mufajok = new HashSet<string> { "akcio", "fantasy", "kaland", "horror" };
                if (!mufajok.Contains(value)) return; // garbage collector
                this.mufaj = value;
            }
        }

        public override string ToString()
        {
            return $"{this.cim} ({this.Ev}, {this.mufaj}) - {this.imdb}";
        }

        // Korábbi-e az aktuális film a paraméterként kapottnál?
        public bool KorabbiE(Film film)
        {
            return this.ev < film.ev;
        }
    }
}
