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
            Console.WriteLine("Létrejött a diák!");
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
        #endregion
    }
}
