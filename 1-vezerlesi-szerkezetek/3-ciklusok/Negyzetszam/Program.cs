using System;

namespace Negyzetszam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            // a) N darab négyzetszám
            Console.WriteLine("a) feladat:");
            for (int i = 0; i < n; i++)
            {
                //Console.Write($"{i*i} ");
                Console.Write(i*i + " ");
            }

            // b) N-ig a négyzetszámok
            Console.WriteLine("\nb) feladat:");
            int j = 0;
            while (j*j < n)
            {
                Console.Write(j*j + " ");
                j++;
            }
            // Kevesebb memória ("hatékonyabb") => Lasabb futás

            // c) N-ig a négyzetszámok
            Console.WriteLine("\nc) feladat:");
            int k = 0;
            int negyzet = 0;
            while (negyzet < n)
            {
                Console.Write(negyzet + " ");
                k++;
                negyzet = k * k;
            }
            // Kisebb futási idő ("hatékonyabb") => Több memória!

            Console.ReadKey();
        }
    }
}
