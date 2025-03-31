using System;
using System.Collections.Generic;
using System.IO;

namespace Sorozatok
{
    internal class Program
    {
        struct Sorozat
        {
            public string datum;
            public DateTime? date;
            public string cim;
            public string epizod;
            public int hossz;
            public bool lattaE;
        }

        static void Main(string[] args)
        {
            List<Sorozat> sorozatok = new List<Sorozat>();

            // Dátumok kezelése
            //DateTime d = new DateTime();
            //DateTime d = DateTime.Now;
            DateTime d = new DateTime(2024, 2, 29);
            //DateTime d = new DateTime(2025, 3, 15, 18, 12, 37);
            //Console.WriteLine($"{d.Year}-{d.Month:00}-{d.Day:00}");
            //DateTime karacsony = new DateTime(2025, 12, 25);
            DateTime nyariszunet = new DateTime(2025, 6, 13);
            //Console.WriteLine(d < karacsony);
            //Console.WriteLine($"Hány nap van Karácsonyig: {nyariszunet - d}");
            //Console.WriteLine(d.ToShortDateString());

            Beolvas(sorozatok);
            //Kiir(sorozatok);
            F2(sorozatok);
            F3(sorozatok);
            F4(sorozatok);
            //F5(sorozatok);
            //Console.WriteLine(Hetnapja(2025, 3, 27));
            //DateTime ma = DateTime.Now;
            //Console.WriteLine(ma.DayOfWeek);
            //F7(sorozatok);
            //F8(sorozatok);
            F8Dic(sorozatok);
        }

        static void F8Dic(List<Sorozat> sorozatok)
        {
            Dictionary<string, int> idok = new Dictionary<string, int>();
            Dictionary<string, int> darabok = new Dictionary<string, int>();
            foreach (Sorozat sorozat in sorozatok)
            {
                string cim = sorozat.cim;
                if (idok.ContainsKey(cim))
                {
                    idok[cim] += sorozat.hossz;
                    darabok[cim]++;
                }
                else
                {
                    idok.Add(cim, sorozat.hossz);
                    darabok.Add(cim, 1);
                }
            }

            StreamWriter sw = new StreamWriter("summaDic.txt");
            foreach (string cim in idok.Keys)
            {
                sw.WriteLine($"{cim} {idok[cim]} {darabok[cim]}");
            }
            sw.Close();
        }

        static void F8(List<Sorozat> sorozatok)
        {
            StreamWriter sw = new StreamWriter("summa.txt");
            int osszeg = 0;
            int db = 0;
            string cim = sorozatok[0].cim; // aktuális sorozat címe
            foreach (Sorozat sorozat in sorozatok)
            {
                if (sorozat.cim != cim)
                {
                    // Új sorozat következik
                    sw.WriteLine($"{cim} {osszeg} {db}");
                    osszeg = 0;
                    db = 0;
                    cim = sorozat.cim;
                    //sw.Flush();
                }
                osszeg += sorozat.hossz;
                db++;
            }
            sw.WriteLine($"{cim} {osszeg} {db}");
            sw.Close();
        }

        static void F7(List<Sorozat> sorozatok)
        {
            Console.WriteLine("\n7. feladat");
            Console.Write("Adja meg a hét egy napját (például cs)! Nap= ");
            string nap = Console.ReadLine();

            HashSet<string> cimek = new HashSet<string>();
            foreach (Sorozat sorozat in sorozatok)
            {
                if (sorozat.date != null)
                {
                    DateTime d = Convert.ToDateTime(sorozat.date);
                    if (Hetnapja(d.Year, d.Month, d.Day) == nap)
                    {
                        cimek.Add(sorozat.cim);
                    }
                }
            }

            if (cimek.Count == 0)
            {
                Console.WriteLine("Az adott napon nem kerül adásba sorozat.");
            }
            else
            {
                foreach (string cim in cimek)
                {
                    Console.WriteLine(cim);
                }
            }
        }

        static string Hetnapja(int ev, int ho, int nap)
        {
            string[] napok = { "v", "h", "k", "sze", "cs", "p", "szo" };
            int[] honapok = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
            if (ho < 3) ev--;
            int evkod = ev + ev / 4 - ev / 100 + ev / 400;
            string hetnap = napok[(evkod + honapok[ho-1] + nap) % 7];
            return hetnap;
        }

        static void F5(List<Sorozat> sorozatok)
        {
            Console.WriteLine("\n5. feladat");
            Console.Write("Adjon meg egy dátumot! Dátum= ");
            string sor = Console.ReadLine();
            //string[] d = sor.Split('.');
            //DateTime date = new DateTime(int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]));
            foreach (Sorozat sorozat in sorozatok)
            {
                //if (sorozat.date <= date && !sorozat.lattaE)
                //{
                //    Console.WriteLine($"{sorozat.epizod}\t{sorozat.cim}");
                //}
                // sor < sorozat.datum (-1)
                if (sor.CompareTo(sorozat.datum) != -1 && !sorozat.lattaE)
                {
                    Console.WriteLine($"{sorozat.epizod}\t{sorozat.cim}");
                }
            }
        }

        static void F4(List<Sorozat> sorozatok)
        {
            int s = 0; // percben az összes idő
            foreach (Sorozat sorozat in sorozatok)
            {
                if (sorozat.lattaE)
                {
                    s += sorozat.hossz;
                }
            }
            Console.WriteLine("\n4. feladat");
            int nap = s / (60 * 24);
            int maradek = s % (60 * 24);
            int ora = maradek / 60;
            int perc = maradek % 60;
            Console.WriteLine($"Sorozatnézéssel {nap} napot {ora} órát és {perc} percet töltött.");
        }

        static void F3(List<Sorozat> sorozatok)
        {
            int db = 0;
            foreach (Sorozat sorozat in sorozatok)
            {
                if (sorozat.lattaE)
                {
                    db++;
                }
            }
            double sz = (double)db / sorozatok.Count * 100;
            Console.WriteLine("\n3. feladat");
            Console.WriteLine($"A listában lévő epizódok {sz:0.00}%-át látta.");
        }

        static void F2(List<Sorozat> sorozatok)
        {
            Console.WriteLine("\n2. feladat");
            int db = 0;
            foreach (Sorozat sorozat in sorozatok)
            {
                //if (sorozat.datum != "NI")
                if (sorozat.date != null)
                {
                    db++;
                }
            }
            Console.WriteLine($"A listában {db} db vetítési dátummal rendelkező epizód van.");
        }

        static void Kiir(List<Sorozat> sorozatok)
        {
            foreach (Sorozat sorozat in sorozatok)
            {
                if (sorozat.date != null)
                {
                    DateTime d = Convert.ToDateTime(sorozat.date);
                    Console.WriteLine(d.ToShortDateString());
                }
                else
                {
                    Console.WriteLine(sorozat.date);
                }
            }
        }

        static void Beolvas(List<Sorozat> sorozatok)
        {
            StreamReader sr = new StreamReader("lista.txt");
            while (!sr.EndOfStream)
            {
                Sorozat s;
                s.datum = sr.ReadLine();
                if (s.datum == "NI")
                {
                    s.date = null;
                }
                else
                {
                    string[] darabolt = s.datum.Split('.'); // { "2017", "07", "16" }
                    int ev = int.Parse(darabolt[0]);
                    int honap = int.Parse(darabolt[1]);
                    int nap = int.Parse(darabolt[2]);
                    DateTime? d = new DateTime(ev, honap, nap);
                    s.date = d;
                }
                s.cim = sr.ReadLine();
                s.epizod = sr.ReadLine();
                s.hossz = int.Parse(sr.ReadLine());
                s.lattaE = sr.ReadLine() == "1";
                sorozatok.Add(s);
            }
            sr.Close();
        }
    }
}
