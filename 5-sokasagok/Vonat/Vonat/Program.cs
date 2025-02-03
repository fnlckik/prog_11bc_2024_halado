using System;
using System.Collections.Generic;

namespace Vonat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
        }

        static void Feladat3()
        {
            Console.WriteLine("3. feladat");
            HashSet<string> v1 = new HashSet<string> { "Budapest-Nyugati", "Zugló", "Kőbánya alsó", "Kőbánya-Kispest", "Ferihegy", "Monor", "Monorierdő", "Pilis", "Albertirsa", "Ceglédbercel", "Ceglédbercel-Cserő", "Budai út", "Cegléd" };
            HashSet<string> v2 = new HashSet<string> { "Budapest-Nyugati", "Zugló", "Kőbánya-Kispest", "Ferihegy", "Cegléd", "Nagykőrös", "Kecskemét", "Kiskunfélegyháza", "Kistelek", "Szatymaz", "Szeged" };
            HashSet<string> csakelso = CsakElsoAllomasok(v1, v2);
        }

        static HashSet<string> CsakElsoAllomasok(HashSet<string> v1, HashSet<string> v2)
        {
            HashSet<string> kulonbseg = new HashSet<string>();
            foreach (string allomas in v1)
            {
                if (!v2.Contains(allomas))
                {
                    kulonbseg.Add(allomas);
                }
            }
            return kulonbseg;
        }

        static void Feladat2()
        {
            Console.WriteLine("2. feladat");
            List<List<int>> buntetesek = Feltolt();

            int s = 0;
            foreach (List<int> ut in buntetesek)
            {
                foreach (int buntetes in ut)
                {
                    s += buntetes;
                    Console.Write(buntetes + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Összes büntetés: " + s);
        }

        static List<List<int>> Feltolt()
        {
            List<List<int>> buntetesek = new List<List<int>>();
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                // m: adott vonaton kiosztott büntetések száma
                int m = r.Next(2, 11);
                List<int> ut = new List<int>();
                for (int j = 0; j < m; j++)
                {
                    int buntetes = r.Next(20, 51) * 1000;
                    ut.Add(buntetes);
                }
                buntetesek.Add(ut);
            }
            return buntetesek;
        }

        static void Feladat1()
        {
            Console.WriteLine("1. feladat");
            Dictionary<string, int> kesesek = new Dictionary<string, int>();
            Beolvas(kesesek);
            Kiir(kesesek);
        }

        static void Kiir(Dictionary<string, int> kesesek)
        {
            foreach (string telepules in kesesek.Keys)
            {
                Console.WriteLine(telepules + ": " + kesesek[telepules]);
            }
        }

        static void Beolvas(Dictionary<string, int> kesesek)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] sor = Console.ReadLine().Split(' ');
                string telepules = sor[0];
                int keses = int.Parse(sor[1]);
                if (!kesesek.ContainsKey(telepules)) // nem volt még a település
                {
                    kesesek.Add(telepules, keses);
                }
                else if (keses > kesesek[telepules]) // találtunk nagyobb késést
                {
                    kesesek[telepules] = keses;
                }
            }
        }
    }
}
