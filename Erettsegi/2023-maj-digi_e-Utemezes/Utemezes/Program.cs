using System;
using System.Collections.Generic;
using System.IO;

namespace Utemezes
{
    internal class Program
    {
        struct Tabor
        {
            public DateTime kezdet;
            public DateTime veg;
            public string diakok;
            public string tema;
        }

        static void Main(string[] args)
        {
            List<Tabor> taborok = new List<Tabor>();
            Beolvas(taborok);
            F2(taborok);
            F3(taborok);
            F4(taborok);

            // TDD - Test Driven Development
            //Console.WriteLine(Sorszam(6, 16)); // 1
            //Console.WriteLine(Sorszam(6, 27)); // 27 - 16 + 1 = 12
            //Console.WriteLine(Sorszam(7, 3)); // 15 (jún) + 3 = 18
            //Console.WriteLine(Sorszam(8, 10)); // 15 (jún) + 31 (júl) + 10 = 56
            //Console.WriteLine(Sorszam(8, 31)); // 15 (jún) + 31 (júl) + 31 = 77

            //F6(taborok);
            //F6DateTime(taborok);
            F7(taborok);
        }

        static List<Tabor> KivalogatErdekesek(List<Tabor> taborok, string betu)
        {
            List<Tabor> erdekesek = new List<Tabor>();
            foreach (Tabor tabor in taborok)
            {
                if (tabor.diakok.Contains(betu))
                {
                    erdekesek.Add(tabor);
                }
            }
            return erdekesek;
        }

        static void KiirFajlba(List<Tabor> erdekesek)
        {
            StreamWriter sw = new StreamWriter("egytanulo.txt");
            foreach (Tabor t in erdekesek)
            {
                sw.WriteLine($"{t.kezdet:M.d} - {t.veg:M.d}. {t.tema}");
            }
            sw.Close();
        }

        static void F7(List<Tabor> taborok)
        {
            Console.WriteLine("\n7. feladat");
            Console.Write("Adja meg egy tanuló betűjelét: ");
            string betu = Console.ReadLine();

            List<Tabor> erdekesek = KivalogatErdekesek(taborok, betu);

            //DateTime ido;
            //bool siker = DateTime.TryParse("kecske", out ido);
            //Console.WriteLine(siker + " " + ido);

            Rendez(erdekesek);
            KiirFajlba(erdekesek);
            bool mehetE = MehetE(erdekesek);
            if (mehetE)
            {
                Console.WriteLine("Elmehet minden táborba.");
            }
            else
            {
                Console.WriteLine("Nem mehet el minden táborba.");
            }
        }

        static bool MehetE(List<Tabor> erdekesek)
        {
            // Nem mehet el, ha van olyan tábor,
            // amelyik később végződik, minthogy a következő kezdődne.
            int i = 0;
            while (i < erdekesek.Count - 1 && !(erdekesek[i].veg > erdekesek[i+1].kezdet))
            {
                i++;
            }
            return i >= erdekesek.Count - 1;
        }

        static void Rendez(List<Tabor> erdekesek)
        {
            for (int i = 0; i < erdekesek.Count; i++)
            {
                for (int j = 0; j < erdekesek.Count - i - 1; j++)
                {
                    if (erdekesek[j].kezdet > erdekesek[j+1].kezdet)
                    {
                        (erdekesek[j], erdekesek[j + 1]) = (erdekesek[j + 1], erdekesek[j]);
                    }
                }
            }
        }

        static void F6DateTime(List<Tabor> taborok)
        {
            Console.WriteLine("\n6. feladat");
            Console.Write("hó: ");
            int ho = int.Parse(Console.ReadLine());
            Console.Write("nap: ");
            int nap = int.Parse(Console.ReadLine());

            DateTime akt = new DateTime(DateTime.Now.Year, ho, nap);
            int db = 0;
            foreach (Tabor tabor in taborok)
            {
                if (tabor.kezdet <= akt && akt <= tabor.veg)
                {
                    db++;
                }
            }

            Console.WriteLine($"Ekkor éppen {db} tábor tart.");
        }

        static void F6(List<Tabor> taborok)
        {
            Console.WriteLine("\n6. feladat");
            Console.Write("hó: ");
            int ho = int.Parse(Console.ReadLine());
            Console.Write("nap: ");
            int nap = int.Parse(Console.ReadLine());

            int akt = Sorszam(ho, nap);

            int db = 0;
            foreach (Tabor tabor in taborok)
            {
                int k = Sorszam(tabor.kezdet.Month, tabor.kezdet.Day);
                int v = Sorszam(tabor.veg.Month, tabor.kezdet.Day);
                if (k <= akt && akt <= v)
                {
                    db++;
                }
            }
            Console.WriteLine($"Ekkor éppen {db} tábor tart.");
        }

        static int Sorszam(int honap, int nap)
        {
            int ev = DateTime.Now.Year;
            DateTime start = new DateTime(ev, 06, 16);
            DateTime aktualis = new DateTime(ev, honap, nap);
            int kulonbseg = (aktualis - start).Days;
            return kulonbseg+1;
        }

        //static int Sorszam(int honap, int nap)
        //{
        //    // 1. nap: 06. 16.
        //    if (honap == 6) return nap - 16 + 1;
        //    else if (honap == 7) return 15 + nap;
        //    else return 15 + 31 + nap;
        //}

        static void F4(List<Tabor> taborok)
        {
            List<Tabor> nepszeruek = new List<Tabor>();
            int maxletszam = taborok[0].diakok.Length;
            foreach (Tabor tabor in taborok)
            {
                if (tabor.diakok.Length > maxletszam)
                {
                    maxletszam = tabor.diakok.Length;
                    nepszeruek.Clear();
                    nepszeruek.Add(tabor);
                }
                else if (tabor.diakok.Length == maxletszam)
                {
                    nepszeruek.Add(tabor);
                }
            }

            Console.WriteLine("\n4. feladat");
            Console.WriteLine("Legnépszerűbbek:");
            foreach (Tabor t in nepszeruek)
            {
                Console.WriteLine($"{t.kezdet.Month} {t.kezdet.Day} {t.tema}");
            }
        }

        static void F3(List<Tabor> taborok)
        {
            Console.WriteLine("\n3. feladat");
            bool voltZenei = false;
            foreach (Tabor tabor in taborok)
            {
                if (tabor.tema == "zenei")
                {
                    int ho = tabor.kezdet.Month;
                    int nap = tabor.kezdet.Day;
                    Console.WriteLine($"Zenei tábor kezdődik {ho}. hó {nap}. napján.");
                    voltZenei = true;
                }
            }

            if (!voltZenei)
            {
                Console.WriteLine("Nem volt zenei tábor.");
            }
        }

        static void F2(List<Tabor> taborok)
        {
            Console.WriteLine("2. feladat");
            Console.WriteLine($"Az adatsorok száma: {taborok.Count}");
            Console.WriteLine($"Az először rögzített tábor témája: {taborok[0].tema}");
            Console.WriteLine($"Az utoljára rögzített tábor témája: {taborok[taborok.Count-1].tema}");
        }

        static void Beolvas(List<Tabor> taborok)
        {
            StreamReader sr = new StreamReader("taborok.txt");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                //Console.WriteLine(sor);
                //sor = sor.Replace("??", "\t");
                string[] adat = sor.Split('\t');
                Tabor t;
                t.kezdet = new DateTime(2025, int.Parse(adat[0]), int.Parse(adat[1]));
                t.veg = new DateTime(2025, int.Parse(adat[2]), int.Parse(adat[3]));
                t.diakok = adat[4];
                t.tema = adat[5];
                taborok.Add(t);
            }
            sr.Close();
        }
    }
}
