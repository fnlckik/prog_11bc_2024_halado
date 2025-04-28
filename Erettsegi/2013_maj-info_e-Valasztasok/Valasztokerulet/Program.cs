using System;
using System.Collections.Generic;
using System.IO;

namespace Valasztokerulet
{
    internal class Program
    {
        struct Jelolt
        {
            public int kerulet; // 0-255
            public int szavazatok;
            public string nev;
            public string part;
        }

        static void Main(string[] args)
        {
            List<Jelolt> jeloltek = new List<Jelolt>();
            Beolvas(jeloltek);
            F2(jeloltek);
            F5(jeloltek);
        }

        static void F5(List<Jelolt> jeloltek)
        {
            Console.WriteLine("5. feladat");

            Dictionary<string, int> szavazatok = new Dictionary<string, int>();

            int s = 0;
            foreach (Jelolt jelolt in jeloltek)
            {
                if (!szavazatok.ContainsKey(jelolt.part))
                {
                    szavazatok.Add(jelolt.part, jelolt.szavazatok);
                }
                else
                {
                    szavazatok[jelolt.part] += jelolt.szavazatok;
                }
                s += jelolt.szavazatok;
            }

            Dictionary<string, string> nevek = new Dictionary<string, string>
            {
                { "GYEP", "Gyümölcsevők Pártja" },
                { "HEP", "Húsevők Pártja" },
                { "TISZ", "Tejivók Szövetsége" },
                { "ZEP", "Zöldségevők Pártja" },
                { "-", "Független jelöltek" }
            };

            foreach (string part in szavazatok.Keys)
            {
                double sz = (double)szavazatok[part] / s * 100;
                Console.WriteLine($"{nevek[part]}= {sz:0.00}%");
            }
        }

        static void F2(List<Jelolt> jeloltek)
        {
            Console.WriteLine("2. feladat");
            Console.WriteLine($"A helyhatósági választáson {jeloltek.Count} képviselőjelölt indult.");
        }

        static void Beolvas(List<Jelolt> jeloltek)
        {
            StreamReader sr = new StreamReader("szavazatok.txt");
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(' ');
                Jelolt jelolt = new Jelolt
                {
                    kerulet = int.Parse(sor[0]),
                    szavazatok = int.Parse(sor[1]),
                    nev = sor[2] + " " + sor[3],
                    part = sor[4]
                };
                jeloltek.Add(jelolt);
            }
            sr.Close();
        }
    }
}
