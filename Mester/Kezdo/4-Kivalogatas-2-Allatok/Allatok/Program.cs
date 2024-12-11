using System;

namespace Allatok
{
    internal class Program
    {
        static void Beolvas(out int n, string[] x, string[] y)
        {
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] sor = Console.ReadLine().Split(' ');
                x[i] = sor[0];
                y[i] = sor[1];
            }
        }

        static bool Eleme(string elem, string[] tomb)
        {
            int i = 0;
            while (i < tomb.Length && tomb[i] != elem)
            {
                i++;
            }
            return i < tomb.Length;
        }

        static void Kivalogatas(string[] evok, string[] evettek, int n, string[] allatok, out int db)
        {
            db = 0;
            for (int i = 0; i < n; i++)
            {
                // Ha jobb oldali benne van a bal oldaliban
                // Ha még nem válogattuk ki (bal oldali nincs benne a kiválogatottakban)
                if (Eleme(evettek[i], evok) && !Eleme(evok[i], allatok))
                {
                    allatok[db] = evok[i]; // kivesszük a balt
                    db++;
                }
            }
        }

        static void Kiir(string[] x, int db)
        {
            Console.WriteLine(db);
            for (int i = 0; i < db; i++)
            {
                Console.WriteLine(x[i]);
            }
        }

        static void Main(string[] args)
        {
            string[] evok = new string[30];
            string[] evettek = new string[30];
            Beolvas(out int n, evok, evettek);

            string[] allatok = new string[30];
            Kivalogatas(evok, evettek, n, allatok, out int db);

            Kiir(allatok, db);
        }
    }
}
