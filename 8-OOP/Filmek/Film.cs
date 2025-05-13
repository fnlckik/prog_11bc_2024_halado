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

        // Konstruktor láncolás
        //public Film(string s) :
        //    this(
        //        s.Split(';')[0],
        //        int.Parse(s.Split(';')[1]),
        //        s.Split(';')[2],
        //        double.Parse(s.Split(';')[3]),
        //        int.Parse(s.Split(';')[4])
        //        )
        //{ }

        public Film(string s)
        {
            string[] sor = s.Split(';');
            this.cim = sor[0];
            this.ev = int.Parse(sor[1]);
            this.mufaj = sor[2];
            this.imdb = double.Parse(sor[3]);
            this.nezok = int.Parse(sor[4]);
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
