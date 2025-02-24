using System;
using System.Collections.Generic;
using System.IO;

namespace Vasarlas
{
    internal class Program
    {
        struct Termek
        {
            public string nev;
            public int ar;
            public bool elelmiszerE;
        }

        static void Main(string[] args)
        {
            //Termek t = new Termek { nev = "Alma", ar = 350, elelmiszerE = true };
            List<Termek> termekek = new List<Termek>();
            Beolvas(termekek);
            //Kiir(termekek);
            Kiir2(termekek);

            Console.WriteLine();
            // Mennyit fizettünk a boltban? (összegzés)
            Console.WriteLine("Teljes ár: " + Osszeg2(termekek));

            // Mindegyiket "klasszikus módon" (for, while) és foreach ciklussal is!
            // Melyik a legdrágább termék? => nev
            Console.WriteLine("Legdrágább termék: " + Legdragabb2(termekek).nev);

            // Adj meg egy olyan terméket, aminek az ára 3000 Ft feletti!
            Console.WriteLine("3000 Ft feletti termék: " + DragaTermek2(termekek));

            // Válogasd ki egy listába az élelmiszereket!
            List<Termek> elelmiszerek = new List<Termek>();
            Kivalogat(termekek, elelmiszerek);
            Console.WriteLine();
            Kiir(elelmiszerek);

            // Rendezzük ár szerint növekvő sorrendbe a termékeket!
            //Rendez(termekek);
            termekek.Sort();

            Console.WriteLine();
            Kiir(termekek);
        }

        // 5 1 2 6 1 1 2
        static void Rendez(List<Termek> termekek)
        {
            for (int i = 0; i < termekek.Count; i++)
            {
                int mini = i;
                for (int j = i + 1; j < termekek.Count; j++)
                {
                    if (termekek[j].ar < termekek[mini].ar)
                    {
                        mini = j;
                    }
                }
                Csere(termekek, i, mini);
            }
        }

        static void Csere(List<Termek> termekek, int i, int k)
        {
            (termekek[i], termekek[k]) = (termekek[k], termekek[i]);
        }

        static void Kivalogat(List<Termek> termekek, List<Termek> elelmiszerek)
        {
            foreach (Termek termek in termekek)
            {
                if (termek.elelmiszerE)
                {
                    elelmiszerek.Add(termek);
                }
            }
        }

        static string DragaTermek2(List<Termek> termekek)
        {
            foreach (Termek termek in termekek)
            {
                if (termek.ar >= 3000)
                {
                    return termek.nev;
                }
            }
            return "Nincs ilyen!";
        }

        static string DragaTermek(List<Termek> termekek)
        {
            int i = 0;
            while (i < termekek.Count && !(termekek[i].ar >= 3000))
            {
                i++;
            }
            if (i < termekek.Count)
            {
                return termekek[i].nev;
            }
            else
            {
                return "Nincs ilyen!";
            }
        }

        static Termek Legdragabb2(List<Termek> termekek)
        {
            int maxi = 0; // Maximális árú termék indexe!
            for (int i = 0; i < termekek.Count; i++)
            {
                if (termekek[i].ar > termekek[maxi].ar)
                {
                    maxi = i;
                }
            }
            return termekek[maxi];
        }

        static Termek Legdragabb(List<Termek> termekek)
        {
            Termek maxTermek = termekek[0];
            foreach (Termek termek in termekek)
            {
                if (termek.ar > maxTermek.ar)
                {
                    maxTermek = termek;
                }
            }
            return maxTermek;
        }

        static int Osszeg2(List<Termek> termekek)
        {
            int s = 0;
            foreach (Termek termek in termekek)
            {
                s += termek.ar;
            }
            return s;
        }

        static int Osszeg(List<Termek> termekek)
        {
            int s = 0;
            for (int i = 0; i < termekek.Count; i++)
            {
                s += termekek[i].ar;
            }
            return s;
        }

        static void Kiir2(List<Termek> termekek)
        {
            Console.WriteLine("Termékek (foreach):");
            foreach (Termek termek in termekek)
            {
                Console.WriteLine($"{termek.nev} - {termek.ar} Ft - {termek.elelmiszerE}");
            }
        }

        static void Kiir(List<Termek> termekek)
        {
            Console.WriteLine("Termékek (for):");
            for (int i = 0; i < termekek.Count; i++)
            {
                Console.WriteLine($"{termekek[i].nev} - {termekek[i].ar} Ft - {termekek[i].elelmiszerE}");
            }
        }

        static void Beolvas(List<Termek> termekek)
        {
            StreamReader sr = new StreamReader("termekek.txt");
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                Termek t;
                t.nev = sor[0];
                t.ar = int.Parse(sor[1]);
                t.elelmiszerE = sor[2] == "1";
                termekek.Add(t);
            }
            sr.Close();
        }
    }
}
