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
            // adel.hangulat ~ adel.GetHangulat()
            Console.WriteLine($"Adél hangulata: {adel.GetHangulat()}%"); // 0.83
            adel.Pihen(3);
            Console.WriteLine($"Adél hangulata: {adel.GetHangulat()}%"); // 0.83 + 0.15 => 0.98
            Console.WriteLine();

            // Mi a neved?
            Console.WriteLine(adel.GetNev());
            adel.SetNev("Léda");
            Console.WriteLine(adel.GetNev());
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
