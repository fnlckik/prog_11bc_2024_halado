using System.Collections.Generic;
using System.IO;

namespace Filmek
{
    class Televizio
    {
        private List<Film> filmek;
        private Dictionary<string, int> gyakorisagok;

        #region Konstruktor
        public Televizio(string fajl)
        {
            this.filmek = new List<Film>();
            StreamReader sr = new StreamReader(fajl);
            while (!sr.EndOfStream)
            {
                //this.filmek.Add(new Film(sr.ReadLine()));
                string sor = sr.ReadLine();
                Film film = new Film(sor);
                this.filmek.Add(film);
            }
            sr.Close();
            this.Megszamol();
        }
        #endregion

        public string Darabok
        {
            get
            {
                string s = "";
                foreach (string mufaj in gyakorisagok.Keys)
                {
                    s += $"{mufaj}: {gyakorisagok[mufaj]} db\n";
                }
                return s;
            }
        }

        #region Metódusok
        public Film Legregebbi()
        {
            Film legregebbi = this.filmek[0];
            foreach (Film film in this.filmek)
            {
                // "2022 AC" < "2022 AC"
                // film.Ev.CompareTo(legregebbi.Ev) < 0
                if (film.KorabbiE(legregebbi))
                {
                    legregebbi = film;
                }
            }
            return legregebbi;
        }

        public void Kiir(string fajl, int db)
        {
            this.Rendez();
            StreamWriter sw = new StreamWriter(fajl);
            for (int i = 0; i < db; i++)
            {
                sw.WriteLine(this.filmek[i]);
            }
            sw.Close();
        }

        //public List<Film> Filmek
        //{
        //    get => new List<Film>(this.filmek);
        //}

        private void Rendez()
        {
            for (int i = 0; i < filmek.Count; i++)
            {
                for (int j = 0; j < filmek.Count - i - 1; j++)
                {
                    if (filmek[j].Imdb < filmek[j+1].Imdb)
                    {
                        (filmek[j], filmek[j + 1]) = (filmek[j + 1], filmek[j]);
                    }
                }
            }
        }

        private void Megszamol()
        {
            this.gyakorisagok = new Dictionary<string, int>();
            foreach (Film film in this.filmek)
            {
                string mufaj = film.Mufaj;
                if (this.gyakorisagok.ContainsKey(mufaj))
                {
                    this.gyakorisagok[mufaj]++;
                }
                else
                {
                    //this.gyakorisagok[mufaj] = 1;
                    this.gyakorisagok.Add(mufaj, 1);
                }
            }
        }
        #endregion
    }
}
