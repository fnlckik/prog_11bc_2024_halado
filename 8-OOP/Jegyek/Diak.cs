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
        public string nev;
        public int kor;
        public double hangulat; // 0.00 - 1.00

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

        public string Koszon()
        {
            return $"{nev} vagyok, {kor} éves.";
        }

        public override string ToString()
        {
            return $"{nev} vagyok, {kor} éves.";
        }
    }
}
