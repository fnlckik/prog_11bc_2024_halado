using System;
using System.Collections.Generic;

namespace Jegyek
{
    // Cél: a világ modellezése
    // Osztály: "sablon, ahogyan valami működik"
    // Objektum: az osztály egy konkrét példánya

    // Osztály: egységbe zárja a
    // 1. Adattagokat (field) => mező
    // 2. Műveletek (method) => metódus
    class Diak
    {
        #region 1. Adattagok
        private string nev;
        private int kor;
        private double hangulat; // 0.00 - 1.00
        private List<int> jegyek = new List<int>();
        #endregion

        #region 2. Konstruktorok
        // function overloading (túlterhelés)
        public Diak() { }

        // this: osztály aktuális példánya
        public Diak(string nev, int kor, double hangulat)
        {
            this.nev = nev;
            this.kor = kor;
            this.hangulat = hangulat;
            //Console.WriteLine("Létrejött a diák!");
        }
        #endregion

        #region 3. Getter, Setter
        //public double GetHangulat()
        //{
        //    return hangulat * 100;
        //}

        //public string GetNev()
        //{
        //    return nev;
        //}

        //public void SetNev(string nev)
        //{
        //    if (nev.Length <= 20)
        //    {
        //        this.nev = nev;
        //    }
        //}

        //public int GetKor()
        //{
        //    return kor;
        //}
        #endregion

        #region 3. Getter, Setter (2015 .NET 6.0) - property
        //public double Hangulat
        //{
        //    get
        //    {
        //        return hangulat * 100;
        //    }
        //}

        public double Hangulat { get => hangulat * 100; }

        public string Nev
        {
            get => nev;
            set
            {
                if (value.Length <= 20)
                {
                    nev = value;
                }
            }
        }

        public int Kor { get => kor; }

        // Vigyázat! Listák getter függvénye mindig másolatot adjon!
        // (Elv: referencia típusú adatoknál másolatot adunk!)
        public List<int> Jegyek { get => new List<int>(this.jegyek); }
        #endregion

        #region 4. Metódusok
        public string Koszon()
        {
            return $"{nev} vagyok, {kor} éves.";
        }

        public override string ToString()
        {
            return $"{nev} vagyok, {kor} éves.";
        }

        public void Pihen(int nap)
        {
            if (nap < 0) return;
            hangulat += nap * 0.05;
            if (hangulat > 1) hangulat = 1;
        }

        // Ötlet: adjunk vissza stringet
        public string Atlag()
        {
            if (this.jegyek.Count == 0) return "Nincs még jegye.";
            double s = 0;
            foreach (int jegy in this.jegyek)
            {
                s += jegy;
            }
            //double atlag = Math.Round(s / this.jegyek.Count, 2);
            //return atlag.ToString();
            return $"{s / this.jegyek.Count:0.00}";
        }

        // False értéket ad ha nem sikerült, True ha igen
        public bool JegyetKap(int jegy)
        {
            if (jegy < 1 || jegy > 5) return false;
            this.jegyek.Add(jegy);
            return true;
        }
        #endregion
    }
}
