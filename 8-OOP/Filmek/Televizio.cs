using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Filmek
{
    class Televizio
    {
        private List<Film> filmek;

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
        }

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
    }
}
