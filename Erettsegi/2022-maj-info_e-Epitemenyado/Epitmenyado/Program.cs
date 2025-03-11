using System;
using System.Collections.Generic;
using System.IO;

namespace Epitmenyado
{
    internal class Program
    {
        struct Epulet
        {
            public string adoszam;
            public string utca;
            public string hsz;
            public char tipus; // adó típusa
            public int terulet;
        }

        struct Statisztika
        {
            public int darab; // Hány telek esik ide?
            public int osszeg; // Mennyi az ilyen telkek adója?
        }

        static void Main(string[] args)
        {
            List<Epulet> epuletek = new List<Epulet>();
            Dictionary<char, int> adok = new Dictionary<char, int>();
            Beolvas(epuletek, adok);
            F2(epuletek);
            //F3(epuletek);
            //Console.WriteLine(Ado('C', 180, adok));
            F5(epuletek, adok);
            //F5Struct(epuletek, adok);
            F6(epuletek);
            F7(epuletek, adok);
        }

        static void F7(List<Epulet> epuletek, Dictionary<char, int> adok)
        {
            Dictionary<string, int> fizetendok = new Dictionary<string, int>();
            foreach (Epulet epulet in epuletek)
            {
                if (!fizetendok.ContainsKey(epulet.adoszam))
                {
                    fizetendok.Add(epulet.adoszam, Ado(epulet.tipus, epulet.terulet, adok));
                }
                else
                {
                    fizetendok[epulet.adoszam] += Ado(epulet.tipus, epulet.terulet, adok);
                }
            }
            StreamWriter sw = new StreamWriter("fizetendo.txt");
            foreach (string adoszam in fizetendok.Keys)
            {
                sw.WriteLine($"{adoszam} {fizetendok[adoszam]}");
            }
            sw.Close();
        }

        static void F6(List<Epulet> epuletek)
        {
            HashSet<string> utcak = new HashSet<string>();
            for (int i = 0; i < epuletek.Count - 1; i++)
            {
                Epulet e1 = epuletek[i];
                Epulet e2 = epuletek[i + 1];
                if (e1.utca == e2.utca && e1.tipus != e2.tipus)
                {
                    utcak.Add(e1.utca);
                }
            }
            Console.WriteLine("6. feladat. A több sávba sorolt utcák:");
            foreach (string utca in utcak)
            {
                Console.WriteLine(utca);
            }
        }

        static void F5Struct(List<Epulet> epuletek, Dictionary<char, int> adok)
        {
            Dictionary<char, Statisztika> stat = new Dictionary<char, Statisztika>
            {
                { 'A', new Statisztika { darab = 0, osszeg = 0 } },
                { 'B', new Statisztika { darab = 0, osszeg = 0 } },
                { 'C', new Statisztika { darab = 0, osszeg = 0 } }
            };
            Console.WriteLine("5. feladat");
            foreach (Epulet epulet in epuletek)
            {
                //Console.WriteLine(epulet.tipus + " " + stat[epulet.tipus].darab);
                Statisztika aktualis = stat[epulet.tipus];
                aktualis.darab++;
                aktualis.osszeg += Ado(epulet.tipus, epulet.terulet, adok);
                stat[epulet.tipus] = aktualis;
                //stat[epulet.tipus].darab++; // Hogyan lehetne javítani? (Microsoft Docs)
            }
            foreach (char tipus in stat.Keys)
            {
                Console.WriteLine($"{tipus} sávba {stat[tipus].darab} telek esik, az adó {stat[tipus].osszeg} Ft.");
            }
        }

        static void F5Magic(List<Epulet> epuletek, Dictionary<char, int> adok)
        {
            Dictionary<char, Dictionary<string, int>> epitmenySavok =
            new Dictionary<char, Dictionary<string, int>>();

            Dictionary<string, int> defaultDict = new Dictionary<string, int>();
            Dictionary<string, int> defaultDictB = new Dictionary<string, int>();
            Dictionary<string, int> defaultDictC = new Dictionary<string, int>();

            defaultDict.Add("szum", 0);
            defaultDict.Add("count", 0);
            defaultDictB.Add("szum", 0);
            defaultDictB.Add("count", 0);
            defaultDictC.Add("szum", 0);
            defaultDictC.Add("count", 0);

            epitmenySavok.Add('A', defaultDict);
            epitmenySavok.Add('B', defaultDictB);
            epitmenySavok.Add('C', defaultDictC);

            foreach (Epulet item in epuletek)
            {
                epitmenySavok[item.tipus]["szum"] += Ado(item.tipus, item.terulet, adok);
                epitmenySavok[item.tipus]["count"]++;
            }

            foreach (char key in epitmenySavok.Keys)
            {
                Console.WriteLine($"{key} sávba {epitmenySavok[key]["count"]} telek esik, az adó {epitmenySavok[key]["szum"]} Ft.");
            }
        }

        static void F5(List<Epulet> epuletek, Dictionary<char, int> adok)
        {
            Console.WriteLine("5. feladat");
            Dictionary<char, int> mennyisegek = new Dictionary<char, int>
            {
                { 'A', 0 },
                { 'B', 0 },
                { 'C', 0 }
            };
            Dictionary<char, int> osszegek = new Dictionary<char, int>
            {
                { 'A', 0 },
                { 'B', 0 },
                { 'C', 0 }
            };
            foreach (Epulet epulet in epuletek)
            {
                mennyisegek[epulet.tipus]++;
                osszegek[epulet.tipus] += Ado(epulet.tipus, epulet.terulet, adok);
            }
            foreach (char tipus in mennyisegek.Keys)
            {
                Console.WriteLine($"{tipus} sávba {mennyisegek[tipus]} telek esik, az adó {osszegek[tipus]} Ft.");
            }
        }

        static void F5Hatvaltozo(List<Epulet> epuletek, Dictionary<char, int> adok)
        {
            Console.WriteLine("5. feladat");
            int dbA = 0, dbB = 0, dbC = 0; // megszámolás
            int adoA = 0, adoB = 0, adoC = 0; // összegzés
            foreach (Epulet epulet in epuletek)
            {
                if (epulet.tipus == 'A')
                {
                    dbA++;
                    adoA += Ado(epulet.tipus, epulet.terulet, adok);
                }
                else if (epulet.tipus == 'B')
                {
                    dbB++;
                    adoB += Ado(epulet.tipus, epulet.terulet, adok);
                }
                else
                {
                    dbC++;
                    adoC += Ado(epulet.tipus, epulet.terulet, adok);
                }
            }
            Console.WriteLine($"A sávba { dbA } telek esik, az adó { adoA } Ft.");
            Console.WriteLine($"B sávba { dbB } telek esik, az adó { adoB } Ft.");
            Console.WriteLine($"C sávba { dbC } telek esik, az adó { adoC } Ft.");
        }

        // 'C', 180 + Dictionary
        static int Ado(char adosav, int alapterulet, Dictionary<char, int> adok)
        {
            //int ado;
            //if (adosav == 'A')
            //{
            //    ado = adok['A'] * alapterulet;
            //}
            //else if (adosav == 'B')
            //{
            //    ado = adok['B'] * alapterulet;
            //}
            //else
            //{
            //    ado = adok['C'] * alapterulet;
            //}
            //if (ado < 10000) ado = 0;
            //return ado;
            int ado = adok[adosav] * alapterulet;
            return ado >= 10000 ? ado : 0;
        }

        static void F3(List<Epulet> epuletek)
        {
            // 68396
            Console.Write("3. feladat. Egy tulajdonos adószáma: ");
            string adoszam = Console.ReadLine();
            int db = 0;
            foreach (Epulet epulet in epuletek)
            {
                if (epulet.adoszam == adoszam)
                {
                    Console.WriteLine($"{epulet.utca} utca {epulet.hsz}");
                    db++;
                }
            }
            if (db == 0)
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }
        }

        static void F2(List<Epulet> epuletek)
        {
            Console.WriteLine($"2. feladat. A mintában {epuletek.Count} telek szerepel.");
        }

        static void Beolvas(List<Epulet> epuletek, Dictionary<char, int> adok)
        {
            StreamReader sr = new StreamReader("utca.txt");
            string[] sor = sr.ReadLine().Split(' '); // { "800", "600", "100" }
            adok.Add('A', int.Parse(sor[0]));
            adok.Add('B', int.Parse(sor[1]));
            adok.Add('C', int.Parse(sor[2]));
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine().Split(' ');
                Epulet epulet;
                epulet.adoszam = sor[0];
                epulet.utca = sor[1];
                epulet.hsz = sor[2];
                epulet.tipus = char.Parse(sor[3]);
                epulet.terulet = int.Parse(sor[4]);
                epuletek.Add(epulet);
            }
            sr.Close();
        }
    }
}
