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

            // Mennyit fizettünk a boltban? (összegzés)
            Console.WriteLine("Teljes ár: " + Osszeg2(termekek));
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
