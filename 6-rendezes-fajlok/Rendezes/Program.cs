using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Rendezes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch ora = new Stopwatch();

            //List<int> lista = new List<int> { 3, 6, 2, 3, 5 };
            const int n = 20000;
            List<int> lista = Feltolt(n);
            //List<int> lista = FeltoltRendezett(n);
            Console.WriteLine("Elemek száma: " + n);
            //Kiir(lista, "Eredeti lista: ");

            List<int> a = new List<int>(lista);
            ora.Start();
            a.Sort(); // Gyors rendezés (quick sort)
            ora.Stop();
            Console.WriteLine("Sort rendezés idő: " + ora.ElapsedTicks);
            //Kiir(a, "Sort rendezés: ");

            List<int> b = new List<int>(lista);
            ora.Restart(); // ora.Reset() + ora.Start()
            Minkival(b);
            ora.Stop();
            Console.WriteLine("Minkival rendezés idő: " + ora.ElapsedTicks);
            //Kiir(b, "Minkival rendezés: ");

            List<int> c = new List<int>(lista);
            ora.Restart();
            Buborekos(c);
            ora.Stop();
            Console.WriteLine("Buborékos rendezés idő: " + ora.ElapsedTicks);
            //Kiir(c, "Buborékos rendezés: ");

            List<int> d = new List<int>(lista);
            ora.Restart();
            Beszurasos(ref d);
            ora.Stop();
            Console.WriteLine("Beszúrásos rendezés idő: " + ora.ElapsedTicks);
            //Kiir(d, "Beszúrásos rendezés: ");

            //List<string> nevek = new List<string> { "Bence", "Zsolt", "Álex", "Kata", "Máté" };
            //nevek.Sort();
            //Kiir(nevek, "Nevek rendezve: ");

            //SortedSet<int> rendezettHalmaz = new SortedSet<int> { 3, 6, 2, 3, 5 };
            //Kiir(rendezettHalmaz);

        }

        static void Beszurasos(ref List<int> lista)
        {
            List<int> rendezett = new List<int>();
            foreach (int elem in lista)
            {
                // Keresünk egy elemet, ami nagyobb a mostaninál! Elé beszúrható!
                int i = 0;
                while (i < rendezett.Count && !(rendezett[i] >= elem))
                {
                    i++;
                }
                if (i < rendezett.Count)
                {
                    rendezett.Insert(i, elem);
                }
                else
                {
                    rendezett.Add(elem);
                }
            }
            lista = rendezett;
        }

        static List<int> FeltoltRendezett(int n)
        {
            List<int> eredmeny = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                eredmeny.Add(i);
            }
            return eredmeny;
        }

        static List<int> Feltolt(int n)
        {
            List<int> eredmeny = new List<int>();
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                eredmeny.Add(r.Next(1, 101)); // 1..100
            }
            return eredmeny;
        }

        static void Buborekos(List<int> lista)
        {
            // i: Hány elem rendezett már?
            for (int i = 0; i < lista.Count; i++)
            {
                bool csere = false;
                // j: Melyik elemeket vizsgáljuk még?
                for (int j = 0; j < lista.Count - i - 1; j++)
                {
                    if (lista[j] > lista[j+1])
                    {
                        Csere(lista, j, j + 1);
                        csere = true;
                    }
                }
                if (!csere) return;
            }
        }

        static void Minkival(List<int> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                // Hol van az i. elemtől kezdve a legkisebb elem?
                int minindex = i;
                for (int j = i + 1; j < lista.Count; j++)
                {
                    if (lista[j] < lista[minindex])
                    {
                        minindex = j;
                    }
                }
                Csere(lista, i, minindex);
            }
        }

        static void Csere(List<int> lista, int i, int j)
        {
            //int seged = lista[i];
            //lista[i] = lista[j];
            //lista[j] = seged;
            (lista[j], lista[i]) = (lista[i], lista[j]);
        }

        static void Kiir(SortedSet<int> rendezettHalmaz)
        {
            Console.WriteLine("Rendezett halmaz: ");
            foreach (int elem in rendezettHalmaz)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }

        static void Kiir<T>(List<T> lista, string szoveg)
        {
            Console.WriteLine(szoveg);
            foreach (T elem in lista)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }
    }
}
