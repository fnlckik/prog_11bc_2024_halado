using System;

namespace Orszagok
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ország:
            // - nev
            // - nepesseg (millió főben) => 9.730530
            // - terulet (km^2)
            // - eutagE (logikai)
            // - nyelvek (halmaz)
            Orszag hu = new Orszag("Magyarország", 9730530, 93000, "magyar angol német francia");
            Orszag jp = new Orszag("Japán", 123294513, 4380000, "japán angol kínai koreai");

            hu.EutagE = true;
            jp.EutagE = true;

            Console.WriteLine(hu);
            Console.WriteLine(jp);

            Console.Clear();
            //// ------------------------

            Random r = new Random();
            Bolygo fold = new Bolygo("Föld", "orszagok.txt", r);
            Console.WriteLine(fold);
            fold.KiirNyelvek("nyelvek.txt");
        }
    }
}
