using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Szamok
{
    internal class Program
    {
        struct Feladat // Kerdes
        {
            public string kerdes; // szoveg
            public int valasz;
            public byte pontszam; // 0 - 255
            public string temakor;
        }

        static void Main(string[] args)
        {
            List<Feladat> feladatok = new List<Feladat>();
            Beolvas(feladatok);
            F2(feladatok);
            F3(feladatok);
            F4(feladatok);
            F5(feladatok);
            //F6(feladatok);
            //F7Ricsi(feladatok);
            //F7Balazs(feladatok);
            F7(feladatok);
        }

        static void F7(List<Feladat> feladatok)
        {
            Random r = new Random();
            StreamWriter sw = new StreamWriter("tesztfel3.txt");
            int pont = 0;
            for (int i = 0; i < 10; i++)
            {
                int k = r.Next(i, feladatok.Count);
                (feladatok[i], feladatok[k]) = (feladatok[k], feladatok[i]);
                Feladat f = feladatok[i];
                sw.WriteLine($"{f.pontszam} {f.valasz} {f.kerdes}");
                pont += f.pontszam;
            }
            sw.WriteLine($"A feladatsorra osszesen {pont} pont adhato.");
            sw.Close();
        }

        static void F7Balazs(List<Feladat> feladatok)
        {
            List<Feladat> masolat = new List<Feladat>(feladatok);
            StreamWriter sw = new StreamWriter("tesztfel2.txt");
            Random r = new Random();
            int pont = 0;
            for (int i = 0; i < 10; i++)
            {
                int k = r.Next(masolat.Count);
                Feladat f = masolat[k];
                masolat.RemoveAt(k);
                sw.WriteLine($"{f.pontszam} {f.valasz} {f.kerdes}");
                pont += f.pontszam;
            }
            sw.WriteLine($"A feladatsorra osszesen {pont} pont adhato.");
            sw.Close();
        }

        static void F7Ricsi(List<Feladat> feladatok)
        {
            StreamWriter w = new StreamWriter("tesztfel.txt");
            HashSet<int> seged = new HashSet<int>();
            Random r = new Random();
            int pontok = 0;
            while (seged.Count < 10)
            {
                int szam = r.Next(feladatok.Count);
                if (!seged.Contains(szam))
                {
                    pontok += feladatok[szam].pontszam;
                    w.WriteLine($"{feladatok[szam].pontszam} {feladatok[szam].valasz} {feladatok[szam].kerdes}");
                    seged.Add(szam);
                }
            }
            w.WriteLine($"A feladatsorra osszesen {pontok} pont adhato.");
            w.Close();
        }

        static void F6(List<Feladat> feladatok)
        {
            // Kiválogatjuk az adott témakörbe tartozó feladatokat.
            List<Feladat> valogatottak = new List<Feladat>();

            Console.Write("Milyen temakorbol szeretne kerdest kapni? ");
            string temakor = Console.ReadLine();
            foreach (Feladat f in feladatok)
            {
                if (f.temakor == temakor)
                {
                    valogatottak.Add(f);
                }
            }
            Random r = new Random();
            Feladat kivalasztott = valogatottak[r.Next(valogatottak.Count)];

            Console.Write(kivalasztott.kerdes + " ");
            int valasz = int.Parse(Console.ReadLine());

            if (kivalasztott.valasz == valasz)
            {
                Console.WriteLine($"A valasz {kivalasztott.pontszam} pontot er.");
            }
            else
            {
                Console.WriteLine("A valasz 0 pontot er.");
                Console.WriteLine($"A helyes valasz: {kivalasztott.valasz}");
            }
        }

        static void F5(List<Feladat> feladatok)
        {
            HashSet<string> temakorok = new HashSet<string>();
            foreach (Feladat f in feladatok)
            {
                temakorok.Add(f.temakor);
            }
            Console.WriteLine("5. feladat");
            foreach (string temakor in temakorok)
            {
                Console.WriteLine(temakor);
            }
        }

        static void F4(List<Feladat> feladatok)
        {
            Console.WriteLine("4. feladat");
            int mine = feladatok[0].valasz;
            int maxe = feladatok[0].valasz;
            foreach (Feladat f in feladatok)
            {
                if (f.valasz > maxe) maxe = f.valasz;
                if (f.valasz < mine) mine = f.valasz;
            }
            Console.WriteLine($"A válaszok {mine}-től {maxe}-ig terjednek.");
        }

        static void F3(List<Feladat> feladatok)
        {
            // 1 => 10, 2 => 6, 3 => 4
            Dictionary<byte, int> darabok = new Dictionary<byte, int>
            {
                { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }
            };
            //int[] darabok = new int[4];
            foreach (Feladat f in feladatok)
            {
                if (f.temakor == "matematika")
                {
                    darabok[0]++;
                    darabok[f.pontszam]++;
                }
            }
            Console.WriteLine("3. feladat");
            Console.WriteLine($"Az adatfajlban {darabok[0]} matematika feladat van, " +
                $"1 pontot er {darabok[1]} feladat, " +
                $"2 pontot er {darabok[2]} feladat, " +
                $"3 pontot er {darabok[3]} feladat.");
        }

        static void F2(List<Feladat> feladatok)
        {
            Console.WriteLine("2. feladat");
            Console.WriteLine("Feladatok száma: " + feladatok.Count);
        }

        static void Beolvas(List<Feladat> feladatok)
        {
            StreamReader sr = new StreamReader("felszam.txt");
            while (!sr.EndOfStream)
            {
                Feladat f;
                f.kerdes = sr.ReadLine();
                string[] sor = sr.ReadLine().Split(' ');
                f.valasz = int.Parse(sor[0]);
                f.pontszam = byte.Parse(sor[1]);
                f.temakor = sor[2];
                feladatok.Add(f);
            }
            sr.Close();
        }
    }
}
