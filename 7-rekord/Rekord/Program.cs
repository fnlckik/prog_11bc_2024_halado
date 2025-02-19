using System;

namespace Rekord
{
    internal class Program
    {
        // Egységbe zárjuk az adatokat!
        // Ember struktúra (rekord)
        // nev, kor, magassag: adattagok, tulajdonságok
        struct Ember
        {
            public string nev;
            public int kor;
            public double magassag; // méter
        }

        static void Main(string[] args)
        {
            Ember janos;
            janos.nev = "János";
            janos.kor = 73;
            janos.magassag = 1.23;
            // Console.WriteLine($"{janos.nev} vagyok, {janos.kor} éves!");
            Bemutatkozas(janos);

            Ember lajos = new Ember
            {
                nev = "Lajos",
                kor = 42,
                magassag = 1.38
            };
            Bemutatkozas(lajos);

            Ember bela = new Ember
            {
                nev = "Béla",
                kor = 4,
                magassag = 1.08
            };
            Bemutatkozas(bela);

            Console.WriteLine("Átlag életkor: " + Math.Round(Atlag(janos, lajos, bela), 2));
            Console.WriteLine();

            Szulinap(ref bela);
            Bemutatkozas(bela);
            Console.WriteLine();

            Ember legmagasabb = Legmagasabb(janos, lajos, bela);

        }

        // Megadja a legmagasabb embert!
        // Több megoldás esetén az elsőt!
        static Ember Legmagasabb(Ember e1, Ember e2, Ember e3)
        {
            throw new NotImplementedException("");
        }

        // A rekord egy érték (value) típus!
        // Az osztály (???) egy referencia típus!
        static void Szulinap(ref Ember ember)
        {
            ember.kor++;
        }

        static double Atlag(Ember e1, Ember e2, Ember e3)
        {
            return (double)(e1.kor + e2.kor + e3.kor) / 3;
        }

        static void Bemutatkozas(Ember ember)
        {
            Console.WriteLine($"{ember.nev} vagyok, {ember.kor} éves!");
        }
    }
}
