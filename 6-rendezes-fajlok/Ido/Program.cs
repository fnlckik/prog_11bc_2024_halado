using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ido
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 53266669;
            
            Stopwatch ora = new Stopwatch();
            //Console.WriteLine("Frekvencia: " + Stopwatch.Frequency + " Hz"); // 10 MHz

            ora.Start();
            //DateTime kezdes = DateTime.Now;
            int[] tomb = new int[n];
            Feltolt(n, tomb);
            //DateTime vege = DateTime.Now;
            ora.Stop();
            long tombFeltolt = ora.ElapsedTicks;

            //Console.WriteLine(vege.Ticks - kezdes.Ticks);

            ora.Restart();
            Kiir(tomb);
            ora.Stop();
            long tombForeach = ora.ElapsedTicks;

            ora.Restart();
            Kiir2(tomb);
            ora.Stop();
            long tombFor = ora.ElapsedTicks;

            // ---------------------------------

            List<int> lista = new List<int>();
            ora.Restart();
            Feltolt(n, lista);
            ora.Stop();
            long listaFeltolt = ora.ElapsedTicks;

            ora.Restart();
            Kiir(lista);
            ora.Stop();
            long listaForeach = ora.ElapsedTicks;

            ora.Restart();
            Kiir2(lista);
            ora.Stop();
            long listaFor = ora.ElapsedTicks;

            // ---------------------------------

            Console.Clear();
            Console.WriteLine($"Tömb feltöltése: {tombFeltolt:000 000 000}");
            Console.WriteLine($"Tömb kiírása (foreach): {tombForeach:000 000 000}");
            Console.WriteLine($"Tömb kiírása (for): {tombFor:000 000 000}");
            Console.WriteLine();
            Console.WriteLine($"Lista feltöltése: {listaFeltolt:000 000 000}");
            Console.WriteLine($"Lista kiírása (foreach): {listaForeach:000 000 000}");
            Console.WriteLine($"Lista kiírása (for): {listaFor:000 000 000}");
        }

        static void Feltolt(int n, List<int> lista)
        {
            for (int i = 0; i < n; i++)
            {
                lista.Add(i + 1);
            }
        }

        static void Kiir2(List<int> lista)
        {
            Console.WriteLine("Lista: ");
            for (int i = 0; i < lista.Count; i++)
            {
                //Console.Write(lista[i] + " ");
            }
            Console.WriteLine();
        }

        static void Kiir(List<int> lista)
        {
            Console.WriteLine("Lista: ");
            foreach (int elem in lista)
            {
                //Console.Write(elem + " ");
            }
            Console.WriteLine();
        }

        static void Kiir2(int[] tomb)
        {
            Console.WriteLine("Tömb: ");
            for (int i = 0; i < tomb.Length; i++)
            {
                //Console.Write(tomb[i] + " ");
            }
            Console.WriteLine();
        }

        static void Kiir(int[] tomb)
        {
            Console.WriteLine("Tömb: ");
            foreach (int elem in tomb)
            {
                //Console.Write(elem + " ");
            }
            Console.WriteLine();
        }

        static void Feltolt(int n, int[] tomb)
        {
            for (int i = 0; i < n; i++)
            {
                tomb[i] = i+1;
            }
        }
    }
}
