using System;
using System.Collections.Generic;

namespace Listak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tömb (statikus)
            int[] tomb = new int[] { 5, 12, -7, 3, 8 };
            Kiir(tomb);

            string[] autok = { "Audi", "BMW", "Skoda", "Smart" };
            Kiir(autok);

            // Lista (dinamikus tömb)
            List<int> lista = new List<int> { 5, 12, -7, 3, 8 };
            Console.WriteLine($"Elemek száma: {lista.Count}");
            lista.Add(23); // végéhez adunk hozzá
            Console.WriteLine($"Elemek száma: {lista.Count}");
            Kiir(lista);

            List<string> cars = new List<string>();
            cars.Add("Audi"); //0
            cars.Add("BMW"); //1
            cars.Add("Skoda"); //2
            cars.Add("Smart"); //3
            Kiir(cars);
            cars.Insert(1, "Citroen"); // adott indexű helyre beszúrunk
            cars.Add("BMW");
            Kiir(cars);
            cars.Remove("BMW"); // az első ilyen elemet veszi ki
            cars.Remove("Renault");
            Kiir(cars);
            Console.WriteLine(cars.IndexOf("Ford"));

            List<bool> x = new List<bool> { true, 1 < 2, false, true, false, cars.Contains("Smart") };
            Kiir(x);
        }

        // T: template (sablonja a függvénynek)
        static void Kiir<T>(List<T> list)
        {
            Console.Write("Lista elemei: ");
            foreach (T elem in list)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }

        /*
        static void Kiir(List<int> lista)
        {
            Console.Write("Lista elemei: ");
            //for (int i = 0; i < lista.Count; i++)
            //{
            //    Console.Write(lista[i] + " ");
            //}
            foreach (int elem in lista)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }
        */

        static void Kiir(string[] autok)
        {
            Console.Write("Tömb elemei: ");
            foreach (string auto in autok)
            {
                Console.Write(auto + " ");
            }
            Console.WriteLine();
        }

        static void Kiir(int[] tomb)
        {
            Console.Write("Tömb elemei: ");
            //for (int i = 0; i < tomb.Length; i++)
            //{
            //    Console.Write($"{i+1}. {tomb[i]}\t");
            //}
            foreach (int elem in tomb)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }
    }
}
