using System;
using System.Collections.Generic;
using System.IO;

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
