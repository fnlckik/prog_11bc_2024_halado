using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

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
        }

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

            Console.WriteLine("4. feladat");
            Console.WriteLine("Legnépszerűbbek:");
            foreach (Tabor t in nepszeruek)
            {
                Console.WriteLine($"{t.kezdet.Month} {t.kezdet.Day} {t.tema}");
            }
        }

        static void F3(List<Tabor> taborok)
        {
            Console.WriteLine("3. feladat");
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
