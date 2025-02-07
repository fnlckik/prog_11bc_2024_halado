using System;
using System.Collections.Generic;

namespace Rendezes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int> { 3, 6, 2, 3, 5 };
            Kiir(lista, "Eredeti lista: ");

            List<int> a = new List<int>(lista);
            a.Sort(); // Gyors rendezés (quick sort)
            Kiir(a, "Sort rendezés: ");

            List<int> b = new List<int>(lista);
            Minkival(b);
            Kiir(b, "Minkival rendezés: ");

            List<int> c = new List<int>(lista);
            Buborekos(c);
            Kiir(c, "Buborékos rendezés: ");

            //List<string> nevek = new List<string> { "Bence", "Zsolt", "Álex", "Kata", "Máté" };
            //nevek.Sort();
            //Kiir(nevek, "Nevek rendezve: ");

            //SortedSet<int> rendezettHalmaz = new SortedSet<int> { 3, 6, 2, 3, 5 };
            //Kiir(rendezettHalmaz);
        }

        static void Buborekos(List<int> lista)
        {
            // i: Hány elem rendezett már?
            for (int i = 0; i < lista.Count; i++)
            {
                // j: Melyik elemeket vizsgáljuk még?
                for (int j = 0; j < lista.Count - i - 1; j++)
                {
                    if (lista[j] > lista[j+1])
                    {
                        Csere(lista, j, j + 1);
                    }
                }
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
