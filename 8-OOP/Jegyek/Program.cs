using System;
using System.Collections.Generic;

namespace Jegyek
{
    // Mj.: A struct és a class nagyon hasonlóak!
    struct Tanulo
    {
        public string nev;
        public int kor;
        public double hangulat; // 0.00 - 1.00
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Korabban();

            // Példányosítás: adott osztályba tartozó objektum létrehozása
            // Konstruktor: az a függvény, ami példányosítás során lefut
            //Diak adel = new Diak();
            //adel.nev = "Adél";
            //adel.kor = 17;
            //adel.hangulat = 0.83;

            Diak adel = new Diak("Adél", 17, 0.83);
            Diak bela = new Diak("Béla", 15, 0.42);
            Diak csaba = new Diak("Csaba", 17, 0.13);
            Console.WriteLine();

            // Bemutatkozás
            // Procedurális - Koszon(adel)
            // Koszon metódus - adel.Koszon()
            Console.WriteLine(adel);
            Console.WriteLine(bela);
            Console.WriteLine(csaba);
            Console.WriteLine();

            // Pihenés
            // public - bárhonnan elérhető
            // private - csak az osztályon belül elérhető
            // adel.hangulat ~ adel.GetHangulat() ~ adel.Hangulat
            Console.WriteLine($"Adél hangulata: {adel.Hangulat}%"); // 0.83
            adel.Pihen(3);
            Console.WriteLine($"Adél hangulata: {adel.Hangulat}%"); // 0.83 + 0.15 => 0.98
            Console.WriteLine();

            // Mi a neved?
            Console.WriteLine("Régi név: " + adel.Nev);
            adel.Nev = "Léda";
            adel.Nev = "Vonatkerékpumpáló József";
            Console.WriteLine("Új név: " + adel.Nev);
            Console.WriteLine();

            Console.WriteLine($"{adel.Nev} kora: {adel.Kor}");
            Console.Clear();

            // Jegyek
            Console.WriteLine(adel.JegyetKap(4));
            Console.WriteLine(adel.JegyetKap(1));
            Console.WriteLine(adel.JegyetKap(3));
            Console.WriteLine(adel.JegyetKap(100));
            Console.WriteLine(adel.JegyetKap(-5));

            // Gond: 0-val osztás eredménye NaN (Not a Number)
            // NaN => "Nincs még jegye."
            // !NaN => az átlagot adja 2 tizedesre kerekítve
            Console.WriteLine($"{adel.Nev} átlaga: {adel.Atlag()}");
            Console.WriteLine($"{bela.Nev} átlaga: {bela.Atlag()}");
            Console.WriteLine($"{csaba.Nev} átlaga: {csaba.Atlag()}");
            Console.WriteLine();

            // Jegyek száma
            adel.Jegyek[0] = 404;
            Console.WriteLine($"{adel.Nev} jegyeinek száma: {adel.Jegyek.Count}");
            if (adel.Jegyek.Count > 0)
            {
                Console.WriteLine($"{adel.Nev} első jegye: {adel.Jegyek[0]}");
            }
            Console.Clear();

            // Csoport
            Csoport cs1 = new Csoport(16);
            Console.WriteLine(cs1);
            for (int i = 0; i < 6; i++)
            {
                cs1.DolgozatIras();
            }
            cs1.KiirNaplo();
        }

        //static string Koszon(Diak d)
        //{
        //    return $"{d.nev} vagyok, {d.kor} éves.";
        //}

        static void Korabban()
        {
            Tanulo adel;
            adel.nev = "Adél";
            adel.kor = 17;
            adel.hangulat = 0.83;

            Tanulo bela;
            bela.nev = "Béla";
            bela.kor = 15;
            bela.hangulat = 0.42;

            Tanulo csaba;
            csaba.nev = "Csaba";
            csaba.kor = 17;
            csaba.hangulat = 0.13;

            Console.WriteLine($"{adel.nev} {bela.nev} {csaba.nev}");
        }
    }
}
