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
    class Diak2
    {
        #region 1. Adattagok
        private string nev;
        private int kor;
        private double hangulat; // 0.00 - 1.00
        #endregion

        #region 2. Konstruktor
        public Diak2(string nev, int kor, double hangulat)
        {
            this.Nev = nev;
            this.Kor = kor;
            this.Hangulat = hangulat;
        }
        #endregion

        #region 3. Getter, Setter (property)
        public string Nev 
        {
            get => this.nev;
            set
            {
                if (value.Length <= 20)
                {
                    this.nev = value;
                }
            }
        }
        public int Kor { get; private set; }
        public double Hangulat
        { 
            get => this.hangulat * 100;
            private set => this.hangulat = value;
        }
        #endregion

        #region 4. Metódusok

        public override string ToString()
        {
            return $"{this.nev} vagyok, {this.kor} éves.";
        }

        public void Pihen(int nap)
        {
            if (nap < 0) return;
            this.hangulat += nap * 0.05;
            if (this.hangulat > 1) this.hangulat = 1;
        }
        #endregion
    }
}
